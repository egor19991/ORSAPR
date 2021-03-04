using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using LampParameters;

namespace LampPluginUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Body _body = new Body();
        private Lamp _lamp = new Lamp{};

        /// <summary>
        /// Метод при смене текстбокса присваивает значение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiametrBodyTextBox_Leave(object sender, EventArgs e)
        {
             
            if ( DiametrBodyTextBox.Text != String.Empty)
            {
                try
                {
                    //_body.Diametr = Int32.Parse(DiametrBodyTextBox.Text);

                    _lamp.Body.Diametr = Int32.Parse(DiametrBodyTextBox.Text);
                    DiametrBodyTextBox.BackColor = Color.White;
                }
                catch (Exception exception) //по идее должно быть ArgumentException, но Exception- защита от букв и точек!
                {

                    // Console.WriteLine(exception.Message);
                    //throw;
                    DiametrBodyTextBox.BackColor = Color.LightCoral;
                    MessageBox.Show(exception.Message);
                }
               
            }
        }

        /// <summary>
        /// Ввод только цифр в поле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiametrBodyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Закрытие плагина
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
