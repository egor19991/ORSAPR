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
        /// <summary>
        /// Словарь, хранящий сведения о TextBox
        /// </summary>
        private readonly Dictionary<TextBox, Action<Lamp, string>> _textBoxDictionary;

        /// <summary>
        /// Поле хранящее данные о лампе
        /// </summary>
        private Lamp _lamp = new Lamp{};

        private LampBuild _build = new LampBuild();

        public MainForm()
        {
            InitializeComponent();
            _lamp.MaxValue();
            UpdateFormFields();
            _textBoxDictionary = new Dictionary<TextBox, Action<Lamp, string>>()
            {
                {
                    DiametrBodyTextBox, 
                    (Lamp lamp, string text) => {lamp.BodyDiametr = Double.Parse(text);}
                },
                {
                    HeightBodyTextBox, 
                    (Lamp lamp, string text) => {lamp.BodyHeight = Double.Parse(text);}
                },
                {
                    DiametrTubeTextBox,
                    (Lamp lamp, string text) => {lamp.TubeDiametr = Double.Parse(text);}
                },
                {
                    HeightTubeTextBox,
                    (Lamp lamp, string text) => {lamp.TubeHeight = Double.Parse(text);}
                },
                {
                    DiametrSocketPlatformTextBox,
                    (Lamp lamp, string text) => {lamp.SocketPlatformDiametr = Double.Parse(text);}
                },
                {
                    HeightSocketPlatformTextBox,
                    (Lamp lamp, string text) => {lamp.SocketPlatformHeight = Double.Parse(text);}
                }
            }; 
        }

        /// <summary>
        /// Обработчик для присваивания значений из TextBox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxLeave(object sender, EventArgs e)
        {
            var currentTextBox = (TextBox)sender;
            var currentAction = _textBoxDictionary[currentTextBox];
            if (currentTextBox.Text != String.Empty)
            {
                try
                {
                    currentAction.Invoke(_lamp, currentTextBox.Text);
                    currentTextBox.BackColor = Color.White;
                }
                catch (ArgumentException exception)
                {
                    currentTextBox.BackColor = Color.LightCoral;
                    MessageBox.Show(exception.Message);
                }
            }
        }

        /// <summary>
        /// Обработчик, который позволяет вводить только цифры и запятую в TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxAllowOnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                TextBox txt = (TextBox)sender;
                if (txt.Text.Contains(","))
                {
                    e.Handled = true;
                }
                return;
            }
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if ((e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Метод, присваивающий значение TextBox
        /// </summary>
        private void UpdateFormFields()
        {
            DiametrBodyTextBox.Text = _lamp.BodyDiametr.ToString();
            HeightBodyTextBox.Text = _lamp.BodyHeight.ToString();
            DiametrTubeTextBox.Text = _lamp.TubeDiametr.ToString();
            HeightTubeTextBox.Text = _lamp.TubeHeight.ToString();
            DiametrSocketPlatformTextBox.Text = _lamp.SocketPlatformDiametr.ToString();
            HeightSocketPlatformTextBox.Text = _lamp.SocketPlatformHeight.ToString();
        }

        /// <summary>
        /// Закрытие плагина
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _build.Exit();
            Environment.Exit(0);
        }

        
        private void BuildButton_Click(object sender, EventArgs e)
        {
            _build.BuildLamp(_lamp);
        }

        private void SizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
