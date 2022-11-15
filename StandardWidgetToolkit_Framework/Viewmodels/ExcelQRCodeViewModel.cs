using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using Utils;
using ZXing.QrCode;

namespace ViewModels
{
    public class ExcelQRCodeViewModel : INotifyPropertyChanged
    {
        #region 属性

        #endregion

        #region 绑定属性

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #region 页面属性

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                NotifyChanged("Title");
            }
        }

        #endregion

        #region 通用属性

        private string _searchCondition;
        public string SearchCondition
        {
            get => _searchCondition;
            set
            {
                _searchCondition = value;
                NotifyChanged("SearchCondition");
            }
        }

        #endregion

        #region EXCEL相关

        /// <summary>
        /// 读取数据列名
        /// </summary>
        private string _CellNameMin = "A1";
        public string CellNameMin
        {
            get => _CellNameMin;
            set
            {
                if (!ExcelHelper.GetColumnNumByName(value, out int cellIndex, out int rowIndex))
                {
                    MessageBox.Show("错误的列名", "错误提示", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                RowMin = rowIndex;
                CellMin = cellIndex + 1;
                _CellNameMin = value;
                NotifyChanged("CellNameMin");
            }
        }

        /// <summary>
        /// 读取数据列名
        /// </summary>
        private string _CellNameMax = "A1";
        public string CellNameMax
        {
            get => _CellNameMax;
            set
            {
                if (!ExcelHelper.GetColumnNumByName(value, out int cellIndex, out int rowIndex))
                {
                    MessageBox.Show("错误的列名", "错误提示", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                RowMax = rowIndex;
                CellMax = cellIndex + 1;
                _CellNameMax = value;
                NotifyChanged("CellNameMax");
            }
        }

        /// <summary>
        /// 存放数据列名
        /// </summary>
        private string _QRCodeImageCellName = "A1";
        public string QRCodeImageCellName
        {
            get => _QRCodeImageCellName;
            set
            {
                if (!ExcelHelper.GetColumnNumByName(value, out int cellIndex, out int rowIndex))
                {
                    MessageBox.Show("错误的列名", "错误提示", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                QRCodeImageCellIndex = cellIndex + 1;
                _QRCodeImageCellName = value;
                NotifyChanged("QRCodeImageCellName");
            }
        }

        /// <summary>
        /// 工作表下标
        /// </summary>
        private int _SheetIndex = 1;
        public int SheetIndex
        {
            get => _SheetIndex;
            set
            {
                _SheetIndex = value;
                NotifyChanged("SheetIndex");
            }
        }

        /// <summary>
        /// 读取数据列最小下标
        /// </summary>
        private int _CellMin = 1;
        public int CellMin
        {
            get => _CellMin;
            set
            {
                _CellMin = value;
                NotifyChanged("CellMin");
            }
        }

        /// <summary>
        /// 读取数据列最大下标
        /// </summary>
        private int _CellMax = 1;
        public int CellMax
        {
            get => _CellMax;
            set
            {
                _CellMax = value;
                NotifyChanged("CellMax");
            }
        }

        /// <summary>
        /// 读取数据行最小下标
        /// </summary>
        private int _RowMin = 1;
        public int RowMin
        {
            get => _RowMin;
            set
            {
                _RowMin = value;
                NotifyChanged("RowMin");
            }
        }

        /// <summary>
        /// 读取数据行最大下标
        /// </summary>
        private int _RowMax = 1;
        public int RowMax
        {
            get => _RowMax;
            set
            {
                _RowMax = value;
                NotifyChanged("RowMax");
            }
        }

        /// <summary>
        /// 生成二维码图片宽度
        /// </summary>
        private int _QRCodeImageWidth = 256;
        public int QRCodeImageWidth
        {
            get => _QRCodeImageWidth;
            set
            {
                _QRCodeImageWidth = value;
                NotifyChanged("QRCodeImageWidth");
            }
        }

        /// <summary>
        /// 生成二维码图片高度
        /// </summary>
        private int _QRCodeImageHeight = 256;
        public int QRCodeImageHeight
        {
            get => _QRCodeImageHeight;
            set
            {
                _QRCodeImageHeight = value;
                NotifyChanged("QRCodeImageHeight");
            }
        }

        /// <summary>
        /// 存放生成二维码图片列
        /// </summary>
        private int _QRCodeImageCellIndex = 1;
        public int QRCodeImageCellIndex
        {
            get => _QRCodeImageCellIndex;
            set
            {
                _QRCodeImageCellIndex = value;
                NotifyChanged("QRCodeImageCellIndex");
            }
        }

        /// <summary>
        /// 二维码图片临时存放路径
        /// </summary>
        private string _TempFilePath;
        public string TempFilePath
        {
            get => _TempFilePath;
            set
            {
                _TempFilePath = value;
                NotifyChanged("TempFilePath");
            }
        }

        /// <summary>
        /// 读取EXCEL文件路径
        /// </summary>
        private string _LoadExcelFilePath;
        public string LoadExcelFilePath
        {
            get => _LoadExcelFilePath;
            set
            {
                _LoadExcelFilePath = value;
                NotifyChanged("LoadExcelFilePath");
                InitProgramData();
            }
        }

        /// <summary>
        /// 保存二维码EXCEL文件路径
        /// </summary>
        private string _SaveExcelFilePath;
        public string SaveExcelFilePath
        {
            get => _SaveExcelFilePath;
            set
            {
                _SaveExcelFilePath = value;
                NotifyChanged("SaveExcelFilePath");
            }
        }

        #endregion

        #endregion

        public ExcelQRCodeViewModel()
        {

        }

        public void InitProgram()
        {
            try
            {
                InitProgramData();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
        }

        public void InitProgramData()
        {
            if (string.IsNullOrWhiteSpace(LoadExcelFilePath))
            {
                LoadExcelFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            SaveExcelFilePath = LoadExcelFilePath;
            TempFilePath = Path.Combine(File.Exists(LoadExcelFilePath) ? Path.GetDirectoryName(LoadExcelFilePath) : LoadExcelFilePath, "QRCodeImage");
        }

        public void HandleExcelFile()
        {
            if (string.IsNullOrWhiteSpace(LoadExcelFilePath))
            {
                MessageBox.Show("请选择EXCEL文件路径", "错误提示", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!File.Exists(LoadExcelFilePath))
            {
                MessageBox.Show("不存在的EXCEL文件", "错误提示", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!File.Exists(SaveExcelFilePath))
            {
                MessageBox.Show("不存在的保存二维码的EXCEL文件", "错误提示", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string extensionName = Path.GetExtension(LoadExcelFilePath);
            if (!new string[] { ".XLS", ".XLSX" }.Contains(extensionName.ToUpper()))
            {
                MessageBox.Show("选择的文件不属于EXCEL文件", "错误提示", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Directory.Exists(TempFilePath))
            {
                Directory.Delete(TempFilePath);
            }
            Directory.CreateDirectory(TempFilePath);

            if (ExcelHelper.GetCellRangeValue(LoadExcelFilePath, out Dictionary<int[], string> outDic, SheetIndex, CellMin, CellMax, RowMin, RowMax))
            {
                Dictionary<int[], string> copyDic = new Dictionary<int[], string>(outDic.Count);
                foreach (int[] key in outDic.Keys)
                {
                    outDic.TryGetValue(key, out string text);
                    if (string.IsNullOrWhiteSpace(text)) { continue; }
                    copyDic.Add(new int[2] { key[0], QRCodeImageCellIndex }, CreateQRCodeImage(text, QRCodeImageWidth, QRCodeImageHeight));
                }
                ExcelHelper.InsertPictures(SaveExcelFilePath, copyDic);
            }
        }

        /// <summary>
        /// 生成二维码图片
        /// </summary>
        /// <param name="text">要生成二维码的字符串</param>
        /// <param name="width">二维码图片宽度</param>
        /// <param name="height">二维码图片高度</param>
        /// <returns></returns>
        private string CreateQRCodeImage(string text, int width, int height)
        {
            if (string.IsNullOrWhiteSpace(text)) { return string.Empty; }
            string fileName = Path.Combine(TempFilePath, Path.GetTempFileName());
            using (Bitmap bitmap = ZxingHelper.GetQRCode(text, width, height))
            {
                bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
            }
            return fileName;
        }
    }
}