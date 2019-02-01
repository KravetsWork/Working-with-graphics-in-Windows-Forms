using System;
using System.Windows.Forms;

namespace Coursework
{
    public partial class Conteiner : Form
    { 
        private int nextForNumber = 2; // номер дочерней формы
        public Conteiner()
        {
            InitializeComponent();  
            Coursework.Child child = new Coursework.Child(this, "Дочерняя форма номер 1");
            child.Show();

        }

        private void MenuItemNewWindow_Click(object sender, EventArgs e)
        {
            Child newchild = new Child(this, "Дочерняя форма номер " + nextForNumber++);  // Создание нового экземпляра дочерней формы
            newchild.Show(); // Вывод созданной формы
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            Close(); // выход из приложения 
        }
       
        private void MenuItemCloseWindow_Click(object sender, EventArgs e) // закрытие ативной формы
        {
            Child newchild = (Child)this.ActiveMdiChild;
            newchild.SaveChangesFromMDI = true;
            if (newchild != null)
            {
                newchild.Close();
            }
        }

        private void Conteiner_FormClosing(object sender, FormClosingEventArgs e) // закрытие всех дочерних форм
        {
            Child child;
            DialogResult result = 0;
            for (int x = 0; x < this.MdiChildren.Length; x++)
            {
                child = (Child)this.MdiChildren[x];
                if (child.pictureBox.Image != null && child.URLold != null && child.countChangePainting != 0) // ищем форму с информацией
                {
                    string message = "Сохранить все изменения?";
                    const string caption = "Form Closing";
                    // создать вопрос при закрытии формы 
                    result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    break;
                }
            }

            if (result == DialogResult.Yes)
            {
                int x;
                MessageBox.Show("Изменения сохранены");
                for (x = 0; x < this.MdiChildren.Length; x++)
                {
                    child = (Child)this.MdiChildren[x];
                    if (child.pictureBox.Image != null && child.URLold != null && child.countChangePainting != 0)
                    {
                        child.SaveChangesFromMDI = false; // сделать недоступным сохранения в активной форме
                        if (child.Graphic != null) { child.Graphic.Dispose(); }
                        child.SaveImage(); // сохраняем формы в которых есть информация
                    }
                }
            }

            //принудительно позакрывать дочерние формы:
            for (int x = 0; x < this.MdiChildren.Length; x++) 
            {
                child = (Child)this.MdiChildren[x];
                if (child != null) { child.Close(); }
            }
        }
    }
}
