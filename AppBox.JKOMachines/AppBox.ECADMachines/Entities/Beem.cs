using System.Collections.Generic;
using System.Drawing;

namespace AppBox.JKOMachines.Entities
{
    public class Beem
    {
        public int Id;
        public int Lenght;
        public List<Operation> operations;
        public int angle1;
        public int angle2;
        public string Barcode;

        public Beem()
        {
            this.operations = new List<Operation>();
        }
        public Bitmap GetBitmap(int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                Pen pen = new Pen(Color.Black, 1);

                //Размер изображения = Длинна заготовки + 20 см (10 на сторону)
                int picWidth = this.Lenght + 200;
                double k = (double)width / (double)picWidth;

                int picHeight = (int)(height / k);

                Point startPoint = new Point((int)(100 * k), (int)((picHeight - 100) * k));

                graphics.DrawRectangle(pen, new Rectangle(startPoint.X, startPoint.Y, (int)(this.Lenght * k), 10));

                using (Font arialFont = new Font("Arial", 8))
                {
                    graphics.DrawString("XXX", arialFont, Brushes.Blue, startPoint);
                }

                DrawOperation(new Operation() { CoordX = 500, code = "100", name = "Test" }, graphics, startPoint.Y);

                

            }
            return bitmap;
        }

        private void DrawOperation(Operation operation, Graphics graphics, int axe)
        {
            graphics.DrawLine(new Pen(Brushes.Blue, 1), new Point(100, axe - 30), new Point(100, axe));

            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            //using (Font arialFont = new Font("Arial", 8))
            //{
            //    graphics.DrawString("123", arialFont, Brushes.Blue, new Point(100, axe - 30), drawFormat);
            //}


            SizeF textImageSize = graphics.MeasureString("ТЕСТ 112345678", new Font("Arial", 8));

            Bitmap str = new Bitmap((int)textImageSize.Width + 10, (int)textImageSize.Height + 5);
            Graphics strgr = Graphics.FromImage(str);
            //рисуем строку
            strgr.DrawString("ТЕСТ 112345678", new Font("Arial", 8), Brushes.Black, 1, 1);
            strgr.Save();
            //а потом поворачиваем на 270 градусов (так чтобы текст читался снизу вверх)
            str.RotateFlip(RotateFlipType.Rotate270FlipNone);
            //и рисуем на основно изображении
            graphics.DrawImage(str, 100, axe - 100, str.Width, str.Height);

        }
    }
}
