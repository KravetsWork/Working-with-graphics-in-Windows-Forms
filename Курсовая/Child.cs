using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace Coursework
{
    public partial class Child : Form
    {
        public string URLnew { get; set; } = null; // требуется для сохранения копии image
        public string URLold { get; set; } = null;// путь к image

        public bool SaveChangesFromMDI { get; set; } = false; // требуется для сохранения в ActiveMdiChild

        public int CoordXGetPixel { get; set; } // отвечает за координаты GetPixel
        public int CoordYGeyPixel { get; set; }

        public int CoordX1GetPixel { get; set; } // отвечает за координаты при нажатии левой клавиши мыши в режиме PixelValue 
        public int CoordY1GetPixel { get; set; }
        public bool DistancePixel { get; set; } // отвечает за нажатие левой клавиши мыши в pictureBox

        public bool MoveLabelDistance { get; set; } // отвечает за нажатие левой клавиши мыши на labelDistance
        private bool PixelVisible { get; set; } // видимость pixelValue

        public string Word { get; set; } = ""; // надпись

        private Bitmap MyImage { get; set; } // создан для оригинальной картинки
        private Bitmap MyImageCopy { get; set; } // создан для копии

        private int CountChangesSizeForm { get; set; } = 0; // создан для количества изминений 

        private double ResizeImage { get; set; } // отвечает за коэфициент изменения размеров изображения при загрузке в pictureBox

        public Graphics Graphic { get; set; } // объект для рисования
        private int X1Painting { get; set; } = -1; // коэфициенты для рисования
        private int Y1Painting { get; set; } = -1;
        private int X2Painting { get; set; } = -1;
        private int Y2Painting { get; set; } = -1; 
        public int countChangePainting = 0; // счетчик изменений при рисовании

        public Child(Coursework.Conteiner parent, string caption)
        {
            InitializeComponent();
            this.MdiParent = parent;
            this.Text = caption;
        }

        private void MenuItemOpen_Click(object sender, EventArgs e) // открыть файл
        {
            var ofd = new OpenFileDialog();
            ofd.Title = "Выбор картинки";
            ofd.Filter = "jpg files (*.jpg)|*.jpg|bmp files (*.bmp)|*.bmp|png files (*.png)|*.png|gif files (*.gif)|*.gif|tiff files (*.tiff)|*.tiff";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                URLold = ofd.FileName;  // получить путь к файлу
                groupBoxPixelValue.Visible = false;
                ShowMyImage(URLold, this.Width, this.Height);
            }
        }

        public void ShowMyImage(string fileName, int xSize, int ySize) // вывести картинку в picturebox
        {
            if (MyImage != null)
            {
                MyImage.Dispose(); // Dispose() - очистка 
            }
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // масштабировать картинку
            MyImage = new Bitmap(fileName);

            pictureBox.ClientSize = new Size(xSize, ySize - 40);
            var wfactor = (double)MyImage.Width / pictureBox.ClientSize.Width;
            var hfactor = (double)MyImage.Height / pictureBox.ClientSize.Height;
            var resizeFactor = Math.Max(wfactor, hfactor);

            ResizeImage = resizeFactor; // получить коэфициент изменения размеров изображения

            int newImageSizeWidth = (int)(MyImage.Width / resizeFactor);
            int newImageSizeHeight = (int)(MyImage.Height / resizeFactor);

            pictureBox.Height = newImageSizeHeight;
            pictureBox.Width = newImageSizeWidth;
            pictureBox.Location = new Point((((this.Width - pictureBox.Width) / 2) - 7), 0); // разместить по центру формы
            pictureBox.Image = MyImage;
            
            EnabledSave(); // видимость кнопок 
        }
  
        public void SaveImage()
        {
            pictureBox.Image = null;
            URLnew = Path.GetFileName(URLold); // имя файла
            MyImage.Save(URLnew);              // создать копию картинки
            MyImage.Dispose();                 // очистить bitmap с изначальной картинкой 

            MyImageCopy = new Bitmap(URLnew);
            pictureBox.Image = MyImageCopy;      // загрузить копию картинки          
            pictureBox.Image.Save(URLold);     // заменить изначальную картинку 
            MyImageCopy.Dispose();
         
            File.Delete(URLnew);  // удалить копию картинки
        }

        public void PaintSizeForm(int w, int h) // сохранить временную картинку при перерисовании формы
        {
            pictureBox.Image.Save(CountChangesSizeForm.ToString()); // сохранить картинку по номеру количества изменений
            ShowMyImage(CountChangesSizeForm.ToString(), w, h);

            int count = CountChangesSizeForm;
            while (count-- >= 0) // удалить все предыдущие промежуточные изображения
            {
                try { File.Delete(count.ToString()); }
                catch { continue; }
            }
            CountChangesSizeForm++;
        }

        private void Child_Resize(object sender, EventArgs e) // масштабировать pictureBox
        {
            Control control = (Control)sender;

            if (9 * control.Size.Height != 16 * control.Size.Width) // позволяет плавно растягивать форму 16:9
            {
                control.Size = new Size(control.Size.Width, Convert.ToInt32(Width * 9 / 16));
            }

            if (URLold != null && pictureBox.Image != null) // работаем с временным изображением
            {
                {
                    if (!groupBoxPixelValue.Visible) { PaintSizeForm(this.Width, this.Height); }
                    else
                    {
                        PaintSizeForm(this.Width, this.Height - groupBoxPixelValue.Height);
                        groupBoxLocation();
                    }
                }
            }
        }

        private void MenuItemSave_Click(object sender, EventArgs e) // сохранить изображение в том же формате 
        {
            if (pictureBox.Image != null && URLold != null && countChangePainting != 0)
            {
                MessageBox.Show("Изображение сохранено");
                Graphic.Dispose();
                SaveImage();                                        // сохранить изображение и открыть его                  
                countChangePainting = 0;
                if (groupBoxPixelValue.Visible)                     // загрузить изображение
                    ShowMyImage(URLold, this.Width, this.Height - groupBoxPixelValue.Height);
                else
                    ShowMyImage(URLold, this.Width, this.Height);
            }
        }

        private void MenuItemSaveAs_Click(object sender, EventArgs e) // сохранить изображение как
        {
            if (pictureBox.Image != null && URLold != null)
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                //отобразить предупреждение, если пользователь указал имя уже существующего файла
                savedialog.OverwritePrompt = true;
                //отобразить предупреждение, если пользователь указал несуществующий путь
                savedialog.CheckPathExists = true;
                savedialog.Filter = "jpg files (*.jpg)|*.jpg|bmp files (*.bmp)|*.bmp|png files (*.png)|*.png|gif files (*.gif)|*.gif|tiff files (*.tiff)|*.tiff";
                if (savedialog.ShowDialog() == DialogResult.OK) // нажата кнопка "ОК"
                {
                    MessageBox.Show("Изображение сохранено");
                    if (Graphic != null) { Graphic.Dispose(); }
                    if (savedialog.FileName == URLold) { SaveImage(); } // при совпадении сохраняем через копию
                    else { pictureBox.Image.Save(savedialog.FileName); } // если имена не совпадают,проблем нет 

                    if (groupBoxPixelValue.Visible)
                        ShowMyImage(URLold, this.Width, this.Height - groupBoxPixelValue.Height);
                    else
                        ShowMyImage(URLold, this.Width, this.Height);
                    countChangePainting = 0;
                }
            }
        }

        private void Child_FormClosing(object sender, FormClosingEventArgs e) // запрос при закрытии формы
        {
            if (SaveChangesFromMDI) // значение true - если мы сохраняем определенную форму child
            {
                if (pictureBox.Image != null && URLold != null && countChangePainting != 0) // проверить на пустоту
                {
                    string message = "Сохранить \"" + URLold + "\" после выхода?";
                    const string caption = "Form Closing";
                    // создать вопрос при закрытии формы 
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show("Изображение сохранено");
                        Graphic.Dispose();
                        SaveImage(); // сохранить изображение
                    }
                }
            }
        }

        public void EnabledSave() // видимость кнопок 
        {
            if (pictureBox.Image != null)
            {
                MenuItemImageInfo.Enabled = true;
                MenuItemSave.Enabled = true;
                MenuItemSaveAs.Enabled = true;
                MenuItemPixelValue.Enabled = true;
                MenuItemPaint.Enabled = true;
            }
            else
            {
                MenuItemImageInfo.Enabled = false;
                MenuItemSave.Enabled = false;
                MenuItemSaveAs.Enabled = false;
                MenuItemPixelValue.Enabled = false;
                MenuItemPaint.Enabled = false;
            }
        }

        private void MenuItemImageInfo_Click(object sender, EventArgs e) // получить информацию об изображении
        {
            string formatImage = "Не определено";
            // массив с форматами изображения
            ImageFormat[] imageFormats = new ImageFormat[] { ImageFormat.Jpeg, ImageFormat.Bmp, ImageFormat.Png, ImageFormat.Gif, ImageFormat.Tiff };
            for (int format = 0; format < imageFormats.Length; format++)
            {
                // Guid - представляет глобальный уникальный идентификатор
                if (pictureBox.Image.RawFormat.Guid == imageFormats[format].Guid)
                    // записать информацию о формате изображения
                    formatImage = imageFormats[format].ToString();
            }

            MessageBox.Show("Имя файла - " + Path.GetFileName(URLold) + ";\n" +
                            "Путь к файлу - \"" + URLold + "\";\n" +
                            "Формат файла - " + formatImage + ";\n" +
                            "Размер изображения - " + pictureBox.Image.Width + " x " + pictureBox.Image.Height + ";\n" +
                            "Вертикальное разрешение - " + pictureBox.Image.VerticalResolution + " точки(-ек) на см;\n" +
                            "Горизонтальное разрешение - " + pictureBox.Image.HorizontalResolution + " точки(-ек) на см;\n" +
                            "Физические размеры - " + Math.Round(pictureBox.Image.Width / pictureBox.Image.HorizontalResolution * 2.54, 2) +
                            " x " + Math.Round(pictureBox.Image.Height / pictureBox.Image.VerticalResolution * 2.54, 2) + " (см);\n" +
                            "Используемый формат пикселов - " + pictureBox.Image.PixelFormat + ";\n" +
                            "Использование бита или байта прозрачности - " + Image.IsAlphaPixelFormat(pictureBox.Image.PixelFormat) + ";\n" +
                            "Число бит на пиксель - " + Image.GetPixelFormatSize(pictureBox.Image.PixelFormat) + ";");
        }

        private void MenuItemPixelValue_Click(object sender, EventArgs e) // При нажатии на PixelValue
        {
            if (pictureBox.Image != null && URLold != null) // проверка на пустоту
            {
                if (!groupBoxPixelValue.Visible)
                {
                    if (countChangePainting != 0) // проверить были ли изменения на форме
                    {
                        string message = "Сохранить изменения?";
                        const string caption = "Pixel value";
                        var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            Graphic.Dispose();
                            SaveImage(); // сохранить изображение
                        }
                    }
                    groupBoxPixelValue.Visible = true;
                    ShowMyImage(URLold, this.Width, this.Height - groupBoxPixelValue.Height);
                    groupBoxLocation();
                    CoordXGetPixel = pictureBox.Width / 2;
                    CoordYGeyPixel = pictureBox.Height / 2;
                    labelCoord.Text = "Центр изображения";
                    GetPixel(CoordXGetPixel, CoordYGeyPixel); // передать центр изображения
                }
                else
                {
                    groupBoxPixelValue.Visible = false;
                    ShowMyImage(URLold, this.Width, this.Height);
                }
                PixelVisible = groupBoxPixelValue.Visible;
                countChangePainting = 0;
            }
        }

        public void GetPixel(int X, int Y) // функция для получения значения пиксела
        {
            Green.Text = "Green : " + MyImage.GetPixel(X, Y).G.ToString();
            Red.Text = "Red : " + MyImage.GetPixel(X, Y).R.ToString();
            Blue.Text = "Blue : " + MyImage.GetPixel(X, Y).B.ToString();
            labelAlpha.Text = "Alpha : " + MyImage.GetPixel(X, Y).A.ToString();

            progressBarAlpha.Value = MyImage.GetPixel(X, Y).A;
            progressBarBlue.Value = MyImage.GetPixel(X, Y).B;
            progressBarGreen.Value = MyImage.GetPixel(X, Y).G;
            progressBarRed.Value = MyImage.GetPixel(X, Y).R;
        }

        public void groupBoxLocation()  // вывод информации блока PixelValue по центру формы 
        {
            groupBoxPixelValue.Location = new Point(((this.Width - groupBoxPixelValue.Width) / 2) - 7, this.Height - groupBoxPixelValue.Height - 40);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            CoordXGetPixel = e.X; // относительно родителя
            CoordYGeyPixel = e.Y;
            if (pictureBox.Image != null && groupBoxPixelValue.Visible)
            {
                CoordXGetPixel = e.X; // относительно родителя
                CoordYGeyPixel = e.Y;
                // блокировать соординаты за пределами pictureBox
                if (CoordXGetPixel < 0) CoordXGetPixel = 0;
                if (CoordYGeyPixel < 0) CoordYGeyPixel = 0;
                if (CoordXGetPixel >= pictureBox.Width) CoordXGetPixel = pictureBox.Width;
                if (CoordYGeyPixel >= pictureBox.Height) CoordYGeyPixel = pictureBox.Height - 1;
                //получить оригинальные координаты пикселя с использованием коэфициента
                GetPixel(Convert.ToInt32(CoordXGetPixel * ResizeImage), Convert.ToInt32(CoordYGeyPixel * ResizeImage));

                if (e.Button == MouseButtons.Left) // если левая кнопка мыши нажата
                {
                    Graphics gr = Graphics.FromImage(this.pictureBox.Image);
                    Pen p = new Pen(Color.Blue, 5);// цвет линии и ширина
                    //рисуем линию
                    gr.DrawLine(p, Convert.ToInt32(CoordX1GetPixel * ResizeImage), Convert.ToInt32(CoordY1GetPixel * ResizeImage), Convert.ToInt32(CoordXGetPixel * ResizeImage), Convert.ToInt32(CoordYGeyPixel * ResizeImage));

                    // Refresh() - Принудительно создает условия, при которых элемент управления делает недоступной свою клиентскую область
                    // и немедленно перерисовывает себя и все дочерние элементы.
                    groupBoxPixelValue.Refresh();

                    labelCoord.Text = "Coord X : " + CoordXGetPixel + ", Coord Y : " + CoordYGeyPixel;
                    double distance = Math.Sqrt(Math.Pow(CoordX1GetPixel - CoordXGetPixel, 2) + Math.Pow(CoordY1GetPixel - CoordYGeyPixel, 2));
                    labelDistance.Text = $"Coord X1 : {CoordX1GetPixel} -> Coord X : {CoordXGetPixel}\nCoord Y1 : {CoordY1GetPixel} -> Coord Y : {CoordYGeyPixel}\nDistance : {Math.Round(distance, 2)} px";
                    pictureBox.Refresh();
                    gr.Dispose();
                    ShowMyImage(URLold, this.Width, this.Height - groupBoxPixelValue.Height);
                }
                else
                {
                    labelCoord.Text = "Coord X : " + CoordXGetPixel + ", Coord Y : " + CoordYGeyPixel;
                }
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e) // нажать клавишу
        {
            var wfactor = (double)MyImage.Width / pictureBox.ClientSize.Width;
            var hfactor = (double)MyImage.Height / pictureBox.ClientSize.Height;
            var resizeFactor = Math.Max(wfactor, hfactor);
            ResizeImage = resizeFactor;
         
            if (e.Button == MouseButtons.Left) // Проверить какая кнопка нажата
            {
                X1Painting = Convert.ToInt32(e.X * ResizeImage);
                Y1Painting = Convert.ToInt32(e.Y * ResizeImage);
            }

            if (e.Button == MouseButtons.Right && X1Painting != -1 && Y1Painting != -1) // проверить была ли нажата левая кнопка изначально 
            {
                X2Painting = Convert.ToInt32(e.X * ResizeImage);
                Y2Painting =  Convert.ToInt32(e.Y * ResizeImage);
            } 
            
            if (X1Painting > -1 && Y1Painting > -1 && X2Painting > -1 && Y2Painting > -1) // если кнопки нажаты координаты >= 0
            {
                if (MenuItemLine.Checked) // рисуем
                {
                    if(Graphic != null)
                        Graphic.Dispose();
                    Pen BackPen = new Pen(Color.Red, (float)(2 * ResizeImage));
                    Graphic = Graphics.FromImage(this.pictureBox.Image);
                    Graphic.DrawLine(BackPen, X1Painting, Y1Painting, X2Painting, Y2Painting);
                    X1Painting = Y1Painting = X2Painting = Y2Painting = -1;
                    countChangePainting++;
                }

                if (MenuItemEllipse.Checked)
                {
                    if (Graphic != null)
                        Graphic.Dispose();
                    Pen BackPen = new Pen(Color.Blue, (float)(2 * ResizeImage));
                    Graphic = Graphics.FromImage(this.pictureBox.Image);
                    Graphic.DrawEllipse(BackPen, X1Painting, Y1Painting, X2Painting - X1Painting, Y2Painting - Y1Painting);
                    X1Painting = Y1Painting = X2Painting = Y2Painting = -1;
                    countChangePainting++;
                }

                if (MenuItemRectangle.Checked)
                {
                    if (Graphic != null)
                        Graphic.Dispose();
                    Pen BackPen = new Pen(Color.Lime, (float)(2 * ResizeImage));
                    Graphic = Graphics.FromImage(this.pictureBox.Image);
                    Graphic.DrawRectangle(BackPen, X1Painting, Y1Painting, X2Painting - X1Painting, Y2Painting - Y1Painting);
                    X1Painting = Y1Painting = X2Painting = Y2Painting = -1;
                    countChangePainting++;
                }
            }  
            
            if (e.Button == MouseButtons.Left && groupBoxPixelValue.Visible) // Проверить какая кнопка нажата
            {
                CoordX1GetPixel = e.X;
                CoordY1GetPixel = e.Y;
                DistancePixel = true;
            }
            pictureBox.Invalidate();
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e) // отпустить клавишу
        {
            if (e.Button == MouseButtons.Left && groupBoxPixelValue.Visible) // Проверить какая кнопка нажата
            {
                labelDistance.Text = "Distance\nнажмите левую кнопку мыши\nдля перемещения";
                DistancePixel = false;
                ShowMyImage(URLold, this.Width, this.Height - groupBoxPixelValue.Height);
                groupBoxLocation();
            }
        }

        private void labelDistance_MouseDown(object sender, MouseEventArgs e)
        {
            MoveLabelDistance = true;  // перемещение label
        }

        private void labelDistance_MouseUp(object sender, MouseEventArgs e)
        {
            MoveLabelDistance = false;
        }

        private void labelDistance_MouseMove(object sender, MouseEventArgs e) // запрещаем перемещение за пределами groupBox
        {          
            if (e.Button == MouseButtons.Left && MoveLabelDistance) 
            {
                if (labelDistance.Location.X < 0) labelDistance.Location = new Point(0, labelDistance.Location.Y + e.Y);
                if (labelDistance.Location.Y < 0) labelDistance.Location = new Point(labelDistance.Location.X + e.X, 0);
                if (labelDistance.Location.X + 200 > groupBoxPixelValue.Width) labelDistance.Location = new Point(groupBoxPixelValue.Width - 200, labelDistance.Location.Y + e.Y);
                if (labelDistance.Location.Y + 30 > groupBoxPixelValue.Height) labelDistance.Location = new Point(labelDistance.Location.X + e.X, groupBoxPixelValue.Height - 30);

                if (labelDistance.Location.X >= 0 && labelDistance.Location.Y >= 0 && labelDistance.Location.X + 200 <= groupBoxPixelValue.Width && labelDistance.Location.Y + 30 <= groupBoxPixelValue.Height)
                {
                    labelDistance.Location = new Point(labelDistance.Location.X + e.X, labelDistance.Location.Y + e.Y);
                }
            }
        }

        private void labelCoord_DoubleClick(object sender, EventArgs e) // возвращение лейбла на место при 2-ном клике 
        {
            labelDistance.Location = new Point(groupBoxPixelValue.Width / 2, groupBoxPixelValue.Height / 2 - 30);
        }

        private void MenuItemInscriprion_Click(object sender, EventArgs e) // текст который будет наноситься на изображение
        {
            DialogBox dialogBox = new DialogBox();
            if (dialogBox.ShowDialog(this) == DialogResult.OK)
            {
                Word = dialogBox.textBoxText.Text;
            }
        }

        private void MenuItemFont_Click(object sender, EventArgs e) // выбор шрифта
        {
            fontDialog1.ShowDialog();
        }
      
        private void pictureBox_DoubleClick(object sender, EventArgs e) // рисование текста при двойном клике 
        {
            if (Graphic != null)
                Graphic.Dispose();

            var wfactor = (double)MyImage.Width / pictureBox.ClientSize.Width;
            var hfactor = (double)MyImage.Height / pictureBox.ClientSize.Height;
            var resizeFactor = Math.Max(wfactor, hfactor);
            ResizeImage = resizeFactor;

            Graphic = Graphics.FromImage(this.pictureBox.Image);
            string name = fontDialog1.Font.Name;
            float size = fontDialog1.Font.Size*(float)ResizeImage; // выбираем нужный шрифт, размер и т.д.
            Font drawFont = new Font(name, size);

            Graphic.DrawString(Word, drawFont, new SolidBrush(Color.White), new PointF(Convert.ToInt32(CoordXGetPixel * ResizeImage), Convert.ToInt32(CoordYGeyPixel * ResizeImage)));
            countChangePainting++;
            pictureBox.Invalidate();
        }

        private void MenuItemWrite_Click(object sender, EventArgs e) 
        {
            if (Word.Length != 0)
            {
                if (!MenuItemWrite.Checked)
                {
                    MenuItemWrite.Checked = true;
                    MenuItemLine.Checked = false;
                    MenuItemEllipse.Checked = false;
                    MenuItemRectangle.Checked = false;
                }
                else
                {
                    MenuItemWrite.Checked = false;
                }
            }
            // блокируем wite, если не выбран текст для нанесения 
            else
                MenuItemInscriprion.ForeColor = Color.Red;
        }

        private void MenuItemPaint_MouseHover(object sender, EventArgs e) // регулирование функций которые мы можем задействовать в данный момент
        {
            if (Word.Length == 0 || PixelVisible)
            {
                MenuItemWrite.Checked = false;
                MenuItemWrite.Enabled = false;
                MenuItemInscriprion.ForeColor = Color.Red;
            }
            else
            {
                MenuItemInscriprion.ForeColor = Color.Black;
                MenuItemWrite.Enabled = true;
            }
            if (PixelVisible)
            {
                MenuItemEllipse.Enabled = false;
                MenuItemRectangle.Enabled = false;
                MenuItemLine.Enabled = false;
                MenuItemEllipse.Checked = false;
                MenuItemRectangle.Checked = false;
                MenuItemLine.Checked = false;
            }
            else
            {
                MenuItemEllipse.Enabled = true;
                MenuItemRectangle.Enabled = true;
                MenuItemLine.Enabled = true;
            }
        }
        
        // выбор функций рисования
        private void MenuItemLine_Click(object sender, EventArgs e)
        {
            if (!MenuItemLine.Checked)
            {
                MenuItemLine.Checked = true;
                MenuItemEllipse.Checked = false;
                MenuItemRectangle.Checked = false;
                MenuItemWrite.Checked = false;
            }
            else
            {
                MenuItemLine.Checked = false;
            }
            X1Painting = Y1Painting = X2Painting = Y2Painting = -1; 
        }

        private void MenuItemEllipse_Click(object sender, EventArgs e)
        {
            if (!MenuItemEllipse.Checked)
            {
                MenuItemEllipse.Checked = true;
                MenuItemLine.Checked = false;
                MenuItemRectangle.Checked = false;
                MenuItemWrite.Checked = false;
            }
            else
            {
                MenuItemEllipse.Checked = false;
            }
            X1Painting = Y1Painting = X2Painting = Y2Painting = -1;
        }

        private void MenuItemRectangle_Click(object sender, EventArgs e)
        {
            if (!MenuItemRectangle.Checked)
            {
                MenuItemRectangle.Checked = true;
                MenuItemLine.Checked = false;
                MenuItemEllipse.Checked = false;
                MenuItemWrite.Checked = false;
            }
            else
            {
                MenuItemRectangle.Checked = false;
            }
            X1Painting = Y1Painting = X2Painting = Y2Painting = -1;
        }
    }
}
