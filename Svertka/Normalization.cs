using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Svertka
{
    public class Normalization
    {
        double[,] matrix;
        int n;
        int m;
        double[,] MaxMatrix;
        List<String> vectorOptimization;

        public Normalization(DataSet Matrix)
        {
            n = Matrix.Tables["Лист 1"].Rows.Count;
            m = Matrix.Tables["Лист 1"].Columns.Count;

            object[] vector = Matrix.Tables["Лист 1"].Rows[0].ItemArray;
            Matrix.Tables["Лист 1"].Rows.RemoveAt(0);

            for (int k = 0; k < vector.Length; k++)
            {
                vectorOptimization.Add(vector[k].ToString());
            }

            int i = 0;
            int j = 0;
            foreach(DataRow row in Matrix.Tables["Лист 1"].Rows)
            {
                foreach(DataColumn column in Matrix.Tables["Лист 1"].Columns)
                {
                    matrix[i, j] = double.Parse(row[column].ToString());
                    j++;
                }
                i++;
            }
        }

        public double[,] AllMaximization()
        {
            for (int j = 0; j < m; j++)
            {
                for(int i = 0; i < n; i++)
                {
                    if (vectorOptimization[j] == "min")
                    {
                        MaxMatrix[i, j] = (-1) * matrix[i,j];
                    }
                }
            }
            return MaxMatrix;
        }
    }
}
