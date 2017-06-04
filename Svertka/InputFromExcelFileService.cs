using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Excel;
using System.IO;

namespace Svertka
{
    public class InputFromExcelFileService
    {
        public IExcelDataReader OpenXLSFile(string pathXLS)
        {
            try
            {
                FileStream streamXLS = File.Open(pathXLS, FileMode.Open, FileAccess.Read);
                IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(streamXLS);
                return excelReader;
            }
            catch (ArgumentException)
            {
                throw new ArgumentException();
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("File not found!");
            }
        }

        public DataSet ReadTable(IExcelDataReader excelReader)
        {
            DataSet Table = excelReader.AsDataSet();
            return Table;
        }
    }
}
