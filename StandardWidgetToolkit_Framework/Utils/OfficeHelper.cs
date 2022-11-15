using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace Utils
{
    public class OfficeHelper
    {

    }

    public class PictureToExcel
    {
        /// <summary>       
        ///打开没有模板的操作。  
        /// </summary>    
        public void Open()
        {
            Open(string.Empty);
        }

        /// <summary>   
        /// 功能：实现Excel应用程序的打开   
        /// </summary>   
        /// <param name="TemplateFilePath">模板文件物理路径</param>   
        public void Open(string TemplateFilePath)
        {
            //打开对象
            m_objExcel = new Excel.Application();
            m_objExcel.Visible = false;
            m_objExcel.DisplayAlerts = false;
            if (m_objExcel.Version != "11.0")
            {
                MessageBox.Show("您的Excel 版本不是11.0 （Office 2003），操作可能会出现问题。");
                m_objExcel.Quit();
                return;
            }
            m_objBooks = m_objExcel.Workbooks;
            if (TemplateFilePath.Equals(string.Empty))
            {
                m_objBook = m_objBooks.Add(m_objOpt);
            }
            else
            {
                m_objBook = m_objBooks.Open(TemplateFilePath, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            }
            m_objSheets = m_objBook.Worksheets;
            m_objSheet = (_Worksheet)m_objSheets.get_Item(1);
            m_objExcel.WorkbookBeforeClose += new AppEvents_WorkbookBeforeCloseEventHandler(m_objExcel_WorkbookBeforeClose);
        }

        private void m_objExcel_WorkbookBeforeClose(Workbook m_objBooks, ref bool _Cancel)
        {
            MessageBox.Show("保存完毕！");
        }

        /// <summary>  
        /// 将图片插入到指定的单元格位置。  
        /// 注意：图片必须是绝对物理路径    /// </summary>  
        /// <param name="RangeName">单元格名称，例如：B4</param>  
        /// <param name="PicturePath">要插入图片的绝对路径。</param> 
        public void InsertPicture(string RangeName, string PicturePath)
        {
            m_objRange = m_objSheet.get_Range(RangeName, m_objOpt);
            m_objRange.Select();
            Pictures pics = (Pictures)m_objSheet.Pictures(m_objOpt);
            pics.Insert(PicturePath, m_objOpt);
        }

        /// <summary> 
        /// 将图片插入到指定的单元格位置，并设置图片的宽度和高度。
        /// 注意：图片必须是绝对物理路径    
        /// </summary>   
        /// <param name="RangeName">单元格名称，例如：B4</param>  
        /// <param name="PicturePath">要插入图片的绝对路径。</param>  
        /// <param name="PictuteWidth">插入后，图片在Excel中显示的宽度。</param>    
        /// <param name="PictureHeight">插入后，图片在Excel中显示的高度。</param>    
        public void InsertPicture(string RangeName, string PicturePath, float PictuteWidth, float PictureHeight)
        {
            m_objRange = m_objSheet.get_Range(RangeName, m_objOpt);
            m_objRange.Select();
            float PicLeft, PicTop;
            PicLeft = Convert.ToSingle(m_objRange.Left);
            PicTop = Convert.ToSingle(m_objRange.Top);
            //参数含义： 
            //图片路径  
            //是否链接到文件 
            //图片插入时是否随文档一起保存  
            //图片在文档中的坐标位置（单位：points） 
            //图片显示的宽度和高度（单位：points） 
            //参数详细信息参见：http://msdn2.microsoft.com/zh-cn/library/aa221765(office.11).aspx  
            m_objSheet.Shapes.AddPicture(PicturePath, MsoTriState.msoFalse, MsoTriState.msoTrue, PicLeft, PicTop, PictuteWidth, PictureHeight);
        }

        /// <summary>  
        /// 将Excel文件保存到指定的目录，目录必须事先存在，文件名称不一定要存在。
        /// </summary>     /// <param name="OutputFilePath">要保存成的文件的全路径。</param>  
        public void SaveFile(string OutputFilePath)
        {
            m_objBook.SaveAs(OutputFilePath, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            Close();
        }

        /// <summary>   
        /// 关闭应用程序
        /// </summary>   
        private void Close()
        {
            m_objBook.Close(false, m_objOpt, m_objOpt);
            m_objExcel.Quit();
        }

        /// <summary>  
        /// 释放所引用的COM对象。注意：这个过程一定要执行。
        /// </summary>   
        public void Dispose()
        {
            ReleaseObj(m_objSheets);
            ReleaseObj(m_objBook);
            ReleaseObj(m_objBooks);
            ReleaseObj(m_objExcel);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        /// <summary> 
        /// /// 释放对象，内部调用
        /// /// </summary> 
        /// /// <param name="o"></param> 

        private void ReleaseObj(object o)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o);

            }
            catch { }

            finally
            {
            }
        }

        private Excel.Application m_objExcel;
        private Workbooks m_objBooks;
        private _Workbook m_objBook;
        private Sheets m_objSheets;
        private _Worksheet m_objSheet;
        private Range m_objRange;
        private object m_objOpt = Missing.Value;
    }

    public class ExcelHelper
    {
        //列名转数字
        public static bool GetColumnNumByName(string columnName, out int cellIndex, out int rowIndex)
        {
            cellIndex = rowIndex = -1;
            try
            {
                Match match = Regex.Match(columnName, @"(?<columnName>(?<cellName>[A-Z]+)(?<rowIndex>[\d]+))", RegexOptions.IgnoreCase);
                if (!match.Success)
                {
                    return false;
                }
                if (!int.TryParse(match.Groups["rowIndex"].Value, out rowIndex))
                {
                    return false;
                }

                int num = 65;// A的Unicode码
                char[] charArray = match.Groups["cellName"].Value.ToCharArray();
                for (int i = 0; i < charArray.Length; i++)
                {
                    char c = charArray[i];
                    cellIndex = ((cellIndex + 1) * 26) + c - num;
                }
                return true;
            }
            catch { }
            return false;
        }

        //数字转列名
        public static void GetColumnNameByNum(int index, out string colName)
        {
            colName = string.Empty;
            if (index < 0) { return; }
            int num = 65;// A的Unicode码
            do
            {
                if (colName.Length > 0)
                {
                    index--;
                }
                int remainder = index % 26;
                colName = $"{(char)(remainder + num)}{colName}";
                index = (index - remainder) / 26;
            } while (index > 0);
        }

        /// <summary>
        /// 获取Excel实际列索引
        /// </summary>
        /// <param name="columnName">Excel列名</param>
        /// <returns>int格式索引</returns>
        public static int GetColumnIndex(string columnName)
        {
            int result = 0;
            // A-Z 转换成 0-25的数字，并反转
            int[] colReverse = Encoding.ASCII.GetBytes(columnName.ToUpper()).Select(x =>
            {
                int aIndex = Encoding.ASCII.GetBytes("A")[0];
                int zIndex = Encoding.ASCII.GetBytes("Z")[0];
                return x < aIndex || x > zIndex ?
                    throw new ArgumentException($"参数有误{nameof(columnName)}") :
                        x - aIndex;
            }).Reverse().ToArray();

            // 当成26进制数，遍历计算
            for (int i = 0; i < colReverse.Count(); i++)
            {
                // 个位(0~25)  其他位(1~26)
                int vReal = colReverse[i] + (i == 0 ? 0 : 1);
                result += vReal * (int)Math.Pow(26, i);
            }
            return result;
        }

        /// <summary>
        /// 用于excel表格中列号字母转成列索引，从1对应A开始
        /// </summary>
        /// <param name="column">列号</param>
        /// <returns>列索引</returns>
        public static int ColumnToIndex(string column)
        {
            if (!Regex.IsMatch(column.ToUpper(), @"[A-Z]+"))
            {
                throw new Exception("Invalid parameter");
            }
            int index = 0;
            char[] chars = column.ToUpper().ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                index += (chars[i] - 'A' + 1) * (int)Math.Pow(26, chars.Length - i - 1);
            }
            return index;
        }

        /// <summary>
        /// 用于将excel表格中列索引转成列号字母，从A对应1开始
        /// </summary>
        /// <param name="index">列索引</param>
        /// <returns>列号</returns>
        public static string IndexToColumn(int index)
        {
            if (index <= 0)
            {
                throw new Exception("Invalid parameter");
            }
            index--;
            string column = string.Empty;
            do
            {
                if (column.Length > 0)
                {
                    index--;
                }
                column = $"{(char)((index % 26) + 'A')}{column}";
                index = (index - (index % 26)) / 26;
            } while (index > 0);
            return column;
        }

        public static bool GetCellRangeValue(string filePath, out Dictionary<int[], string> outDic, int sheetIndex = 1, int cellMin = 1, int cellMax = 1, int rowMin = 1, int rowMax = 1)
        {
            try
            {
                Excel.Application xlApp = new Excel.Application() { Visible = true };
                if (xlApp != null)
                {
                    Workbooks workbooks = xlApp.Workbooks;
                    Workbook workbook = xlApp.Workbooks.Open(filePath);
                    Worksheet worksheet = (Worksheet)workbook.Worksheets[sheetIndex];

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

            Workbooks workbooks = xlApp.Workbooks;
            Workbook workbook = xlApp.Workbooks.Open(saveFilePath);
            Worksheet worksheet = (Worksheet)workbook.Worksheets[sheetIndex];

            foreach (int[] key in pictureDic.Keys)
            {
                Range range = worksheet.Cells[key[0], key[1]];
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

            Workbooks workbooks = xlApp.Workbooks;
            Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);

            int sheetIndex = 0;
            foreach (string key in pictureDic.Keys)
            {
                sheetIndex += 1;
                Worksheet worksheet = (Worksheet)workbook.Worksheets[sheetIndex];

                Range range = worksheet.get_Range(key, Missing.Value);
                range.Select();
                Pictures pics = (Pictures)worksheet.Pictures(Missing.Value);
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

            Workbooks workbooks = xlApp.Workbooks;
            Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);

            int sheetIndex = 0;
            foreach (string nameKey in exportExcelDict.Keys)
            {
                sheetIndex += 1;
                Worksheet worksheet = (Worksheet)workbook.Worksheets[sheetIndex];
                worksheet.Name = nameKey;

                List<Dictionary<string, string>> tempList = exportExcelDict[nameKey];
                Dictionary<string, string> tempDict = tempList[0];

                int rowIndex = 1, columnIndex = 0;
                Range range = worksheet.get_Range(worksheet.Cells[rowIndex, 1], worksheet.Cells[tempDict.Values.Count + 1, tempDict.Keys.Count]);
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
