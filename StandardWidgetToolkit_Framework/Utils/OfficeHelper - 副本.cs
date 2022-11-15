using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;

namespace Utils
{
    public class ExcelHelper
    {
        public static bool GetCellRangeValue(string filePath, out Dictionary<int[], string> outDic, int sheetIndex = 1, int cellMin = 1, int cellMax = 1, int rowMin = 1, int rowMax = 1)
        {
            try
            {
                Excel.Application xlApp = new Excel.Application() { Visible = true };
                if (xlApp != null)
                {
                    Excel.Workbooks workbooks = xlApp.Workbooks;
                    Excel.Workbook workbook = xlApp.Workbooks.Open(filePath);
                    Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[sheetIndex];

                    outDic = new Dictionary<int[], string>();
                    for (int row = rowMin; row <= rowMax; row++)
                    {
                        for (int cell = cellMin; cell <= cellMax; cell++)
                        {
                            outDic.Add(new int[2] { row, cell }, worksheet.Cells[row, cell].Text.ToString());
                        }
                    }
                    workbook.Close(false);
                    workbooks.Close();
                    xlApp.Quit();
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            outDic = null;
            return false;
        }

        public static bool InsertPictures(string saveFilePath, Dictionary<int[], string> pictureDic, int sheetIndex = 1)
        {
            Excel.Application xlApp = new Excel.Application() { Visible = true };
            if (xlApp == null) { return false; }

            Excel.Workbooks workbooks = xlApp.Workbooks;
            Excel.Workbook workbook = xlApp.Workbooks.Open(saveFilePath);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[sheetIndex];

            foreach (int[] key in pictureDic.Keys)
            {
                Excel.Range range = worksheet.Cells[key[0], key[1]];
                range.Select();

                float PicLeft, PicTop;
                PicLeft = Convert.ToSingle(range.Left);
                PicTop = Convert.ToSingle(range.Top);
                //参数含义： 
                //图片路径  
                //是否链接到文件 
                //图片插入时是否随文档一起保存  
                //图片在文档中的坐标位置（单位：points） 
                //图片显示的宽度和高度（单位：points） 
                //参数详细信息参见：http://msdn2.microsoft.com/zh-cn/library/aa221765(office.11).aspx  
                worksheet.Shapes.AddPicture(pictureDic[key], MsoTriState.msoFalse, MsoTriState.msoTrue, PicLeft, PicTop, 128, 128);
            }
            workbook.Close(true, saveFilePath);
            workbooks.Close();
            xlApp.Quit();
            return true;
        }

        public static bool InsertPictures(string saveFilePath, Dictionary<string, string> pictureDic)
        {
            Excel.Application xlApp = new Excel.Application() { Visible = true };
            if (xlApp == null) { return false; }

            Excel.Workbooks workbooks = xlApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);

            int sheetIndex = 0;
            foreach (string key in pictureDic.Keys)
            {
                sheetIndex += 1;
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[sheetIndex];

                Excel.Range range = worksheet.get_Range(key, Missing.Value);
                range.Select();
                Excel.Pictures pics = (Excel.Pictures)worksheet.Pictures(Missing.Value);
                pics.Insert(pictureDic[key], Missing.Value);
            }
            workbook.Close(true, saveFilePath);
            workbooks.Close();
            xlApp.Quit();
            return true;
        }

        public static bool ExportToExcel(string saveFilePath, Dictionary<string, List<Dictionary<string, string>>> exportExcelDict)
        {
            Excel.Application xlApp = new Excel.Application() { Visible = true };
            if (xlApp == null) { return false; }

            Excel.Workbooks workbooks = xlApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);

            int sheetIndex = 0;
            foreach (string nameKey in exportExcelDict.Keys)
            {
                sheetIndex += 1;
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[sheetIndex];
                worksheet.Name = nameKey;

                List<Dictionary<string, string>> tempList = exportExcelDict[nameKey];
                Dictionary<string, string> tempDict = tempList[0];

                int rowIndex = 1, columnIndex = 0;
                Excel.Range range = worksheet.get_Range(worksheet.Cells[rowIndex, 1], worksheet.Cells[tempDict.Values.Count + 1, tempDict.Keys.Count]);
                range.Font.Size = 10;
                range.NumberFormatLocal = "@";
                foreach (string key in tempDict.Keys)
                {
                    columnIndex += 1;
                    worksheet.Cells[1, columnIndex] = key;
                }

                for (int i = 0; i < tempList.Count; i++)
                {
                    rowIndex += 1;
                    columnIndex = 0;
                    tempDict = tempList[i];
                    foreach (string value in tempDict.Values)
                    {
                        columnIndex += 1;
                        worksheet.Cells[rowIndex, columnIndex] = value;
                    }
                }
            }
            workbook.Close(true, saveFilePath);
            workbooks.Close();
            xlApp.Quit();
            return true;
        }
    }
}
