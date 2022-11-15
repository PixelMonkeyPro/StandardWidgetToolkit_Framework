using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

namespace Utils
{
    public class ZxingHelper
    {
        /// 生成二维码
        public static Bitmap GetQRCode(string text, int width, int height)
        {
            BarcodeWriter writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE
            };
            QrCodeEncodingOptions options = new QrCodeEncodingOptions()
            {
                DisableECI = true,//设置内容编码
                CharacterSet = "UTF-8",
                Width = width,//设置二维码的宽度和高度
                Height = height,
                Margin = 1//设置二维码的边距,单位不是固定像素
            };

            writer.Options = options;
            Bitmap map = writer.Write(text);
            return map;
        }

        /// 生成一维条形码
        public static Bitmap GetBarCode(string text, int width, int height)
        {
            BarcodeWriter writer = new BarcodeWriter
            {
                //使用ITF 格式，不能被现在常用的支付宝、微信扫出来
                //如果想生成可识别的可以使用 CODE_128 格式
                //writer.Format = BarcodeFormat.ITF;
                Format = BarcodeFormat.CODE_39
            };
            EncodingOptions options = new EncodingOptions()
            {
                Width = width,
                Height = height,
                Margin = 2
            };
            writer.Options = options;
            Bitmap map = writer.Write(text);
            return map;
        }

        /// 生成带Logo的二维码
        public static Bitmap GetQRCodeWithLogo(string text, int width, int height)
        {
            //Logo 图片
            string logoPath = System.AppDomain.CurrentDomain.BaseDirectory + @"zp.bmp";
            Bitmap logo = new Bitmap(logoPath);
            //构造二维码写码器
            MultiFormatWriter writer = new MultiFormatWriter();
            Dictionary<EncodeHintType, object> hint = new Dictionary<EncodeHintType, object>();
            hint.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
            hint.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            //hint.Add(EncodeHintType.MARGIN, 2);//旧版本不起作用，需要手动去除白边

            //生成二维码
            BitMatrix bm = writer.encode(text, BarcodeFormat.QR_CODE, width + 80, height + 80, hint);
            bm = DeleteWhite(bm);
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            Bitmap map = barcodeWriter.Write(bm);

            //获取二维码实际尺寸（去掉二维码两边空白后的实际尺寸）
            int[] rectangle = bm.getEnclosingRectangle();

            //计算插入图片的大小和位置
            int middleW = Math.Min((int)(rectangle[2] / 3.5), logo.Width);
            int middleH = Math.Min((int)(rectangle[3] / 3.5), logo.Height);
            int middleL = (map.Width - middleW) / 2;
            int middleT = (map.Height - middleH) / 2;

            Bitmap bmpimg = new Bitmap(map.Width, map.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bmpimg))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(map, 0, 0, width, height);
                //白底将二维码插入图片
                g.FillRectangle(Brushes.White, middleL, middleT, middleW, middleH);
                g.DrawImage(logo, middleL, middleT, middleW, middleH);
            }
            return bmpimg;
        }

        /// 删除默认对应的空白
        private static BitMatrix DeleteWhite(BitMatrix matrix)
        {
            int[] rec = matrix.getEnclosingRectangle();
            int resWidth = rec[2] + 1;
            int resHeight = rec[3] + 1;

            BitMatrix resMatrix = new BitMatrix(resWidth, resHeight);
            resMatrix.clear();
            for (int i = 0; i < resWidth; i++)
            {
                for (int j = 0; j < resHeight; j++)
                {
                    if (matrix[i + rec[0], j + rec[1]])
                        resMatrix[i, j] = true;
                }
            }
            return resMatrix;
        }

        /*
        //以一个函数调用，text为需要生成的内容  
        public void Normal(string text)
        {
            //调用saveFileDialog选择导出二维码保存位置  
            string filename = saveFileDialog.FileName;
            //初始化  
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            //禁用ECI  
            options.DisableECI = true;
            //内容编码格式  
            options.CharacterSet = cbx_code.Text;
            //二维码的宽高  
            options.Width = int.Parse(tbx_width.Text);
            options.Height = int.Parse(tbx_height.Text);
            //二维码边距  
            options.Margin = int.Parse(tbx_margin.Text);
            writer.Options = options;
            //导出图片  
            Bitmap p = writer.Write(text);
            p.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
            p.Dispose();
            //在程序中加载导出的二维码  
            pictureBox.ImageLocation = filename;
        }

        public void GenerateWithLogo(string text)
        {
            //调用openFileDialog选择要插入的Logo  
            openFileDialog.ShowDialog();
            Bitmap logo = new Bitmap(openFileDialog.FileName);
            //调用saveFileDialog选择保存位置  
            saveFileDialog.ShowDialog();
            //初始化  
            MultiFormatWriter writer = new MultiFormatWriter();
            Dictionary<EncodeHintType, object> hint = new Dictionary<EncodeHintType, object>();
            hint.Add(EncodeHintType.CHARACTER_SET, cbx_code.Text);
            hint.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);

            //生成二维码   
            BitMatrix bm = writer.encode(text, BarcodeFormat.QR_CODE, int.Parse(tbx_width.Text), int.Parse(tbx_height.Text), hint);
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            Bitmap map = barcodeWriter.Write(bm);
            //计算尺寸  
            int[] rectangle = bm.getEnclosingRectangle();

            //计算插入Logo的大小位置  
            int middleW = Math.Min((int)(rectangle[2] / 3.5), logo.Width);
            int middleH = Math.Min((int)(rectangle[3] / 3.5), logo.Height);
            int middleL = (map.Width - middleW) / 2;
            int middleT = (map.Height - middleH) / 2;

            //将img转换成bmp格式，否则后面无法创建Graphics对象  
            Bitmap bmpimg = new Bitmap(map.Width, map.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bmpimg))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(map, 0, 0);
            }
            //将二维码插入图片  
            Graphics myGraphic = Graphics.FromImage(bmpimg);
            //白底  
            myGraphic.FillRectangle(Brushes.White, middleL, middleT, middleW, middleH);
            myGraphic.DrawImage(logo, middleL, middleT, middleW, middleH);

            //保存成图片  
            bmpimg.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
            pictureBox.ImageLocation = saveFileDialog.FileName;
        }

        public void LoadQRC(string filename)
        {
            BarcodeReader reader = new BarcodeReader();
            //设置读取的格式（一般为UTF-8）  
            reader.Options.CharacterSet = cbx_loadcode.Text;
            Bitmap p = new Bitmap(filename);
            Result result = reader.Decode(p);
            rtbx.Text = result.ToString();
        }
        */
    }
}
