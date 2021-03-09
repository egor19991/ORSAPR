using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using LampParameters;
using LampBuilder;

namespace LampPluginUI
{
    public partial class MainForm : Form
    {

        private readonly Dictionary<TextBox, Action<Lamp, string>> _textBoxDictionary;

        public MainForm()
        {
            InitializeComponent();
            //_lamp.Avg();
            //Спросить 1
            _lamp.Tube.Height = 180;
            try
            {
                MessageBox.Show(_lamp.HoleLength().ToString());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                MessageBox.Show(e.Message);
                //throw;
            }
            _textBoxDictionary = new Dictionary<TextBox, Action<Lamp, string>>()
            {
                {
                    DiametrBodyTextBox, 
                    (Lamp lamp, string text) => {lamp.Body.Diametr = Int32.Parse(text);}
                },
                {
                    textBox3, 
                    (Lamp lamp, string text) => {lamp.Body.Height = Int32.Parse(text);}
                }
            }; 
        }

        private Lamp _lamp = new Lamp{};
        // Тест PropertyInfo  propertyInfo = typeof(Lamp).GetProperty("Body");

        

        /// <summary>
        /// Метод при смене текстбокса присваивает значение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiametrBodyTextBox_Leave(object sender, EventArgs e)
        {
            var currentTextBox = (TextBox)sender;
            var currentAction = _textBoxDictionary[currentTextBox];

            //Svin(DiametrBodyTextBox,  _lamp.Body.Diametr);
            if (currentTextBox.Text != String.Empty)
            {
                try
                {
                    currentAction.Invoke(_lamp, currentTextBox.Text);
                    currentTextBox.BackColor = Color.White;
                }
                catch (ArgumentException exception) //по идее должно быть ArgumentException, но Exception- защита от букв и точек!
                {
                    currentTextBox.BackColor = Color.LightCoral;
                    MessageBox.Show(exception.Message);
                }
            }
        }

        //!!!!!!! Tessstt !!!!!! Спросить 2
        public void Svin(TextBox svin1, int svin2)
        {
            if (svin1.Text != String.Empty)
            {
                try
                {
                    svin2 = Int32.Parse(svin1.Text);
                    svin1.BackColor = Color.White;
                    MessageBox.Show(svin2.ToString());
                }
                catch (ArgumentException exception) //по идее должно быть ArgumentException, но Exception- защита от букв и точек!
                {

                    // Console.WriteLine(exception.Message);
                    //throw;
                    svin1.BackColor = Color.LightCoral;
                    MessageBox.Show(exception.Message);
                }
            }
        }



        private void DiametrBodyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           Number(e);
        }


        /// <summary>
        /// Метод, отображающий в TextBox только цифры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Number(KeyPressEventArgs e)
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

        private void BuildButton_Click(object sender, EventArgs e)
        {
            LampBuild.SvinRT();
        }
    }
}
