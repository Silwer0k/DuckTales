using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Svertka;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private string FileLocation;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel files (*.xls)|*.xls";

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileLocation = openFileDialog.FileName;
            }

            InputFromExcelFileService excelService = new InputFromExcelFileService();

            DataSet matrix = excelService.ReadTable(excelService.OpenXLSFile(FileLocation));

            Normalization NormalizationService = new Normalization(matrix);
            double[,] normMatrix = NormalizationService.AllMaximization();

            for (int i = 0; i < normMatrix.GetLength(1); i++)
                for (int j = 0; j < normMatrix.GetLength(2); i++)
                    dataGridView1.Rows[i].Cells[j].Value = normMatrix[i, j];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
