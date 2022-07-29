using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NUnit.Framework;
using System;
using System.IO;

namespace SapExcel
{
    public class Tests
    {
        [Test]
        public void ReadingTheDataFromExcel()
        {
            string path = @"G:\SeleniumAutomationCsharp\Sapc1234\AmazonCSharpSharan\ExcelData.xlsx";
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            XSSFWorkbook workbook = new XSSFWorkbook(fs);

            //ISheet sheet = workbook.GetSheet("credential");
            ISheet sheet = workbook.GetSheetAt(0);

            //using for loop how many row coloumns we have

            int rows = sheet.LastRowNum;//no of rows

            int cols = sheet.GetRow(1).LastCellNum;// i want to find number of cells in the particular row

            for(int r=0;r<=rows;r++)//outer loop reprenting rows in excel
            {
                IRow row = sheet.GetRow(r); //return the row object
                for (int c=0;c<cols;c++) //inner loop reprenting cells in a each row
                {
                    ICell cell = row.GetCell(c);//this method will return cell object
                    //how to extract the data from cell object
                    //depends upon the type of the cell we use particular method
                    //cell.CellType()
                    switch (cell.CellType)
                    {
                        case CellType.String: TestContext.Progress.Write(cell.StringCellValue); break;
                        case CellType.Numeric: TestContext.Progress.Write(cell.NumericCellValue); break;
                        case CellType.Boolean: TestContext.Progress.Write(cell.BooleanCellValue); break;
                    }
                    TestContext.Progress.Write(" | ");

                }
                TestContext.Progress.WriteLine();
            }
        }

        [Test]
        public void ReadExcel()
        {
            string path = @"G:\SeleniumAutomationCsharp\Sapc1234\AmazonCSharpSharan\ExcelData.xlsx";
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            XSSFWorkbook workbook = new XSSFWorkbook(file);
            var sheet = workbook.GetSheetAt(0);
            var row = sheet.GetRow(1);
            var value = row.GetCell(0).StringCellValue.Trim();
            TestContext.Progress.WriteLine(value);
        }
    }
}