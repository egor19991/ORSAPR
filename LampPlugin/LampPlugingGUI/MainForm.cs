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
        /// Словарь для хранения сведений о TextBox
        /// </summary>
        private readonly Dictionary<TextBox, Action<LampParameters.LampParameters, string>> _textBoxDictionary;

        /// <summary>
        /// Поле хранящее данные о лампе
        /// </summary>
        private LampParameters.LampParameters _lamp = new LampParameters.LampParameters{};

        /// <summary>
        /// Поле для хранения данных о билдере
        /// </summary>
        private LampBuilder.LampBuilder _build = new LampBuilder.LampBuilder();

        public MainForm()
        {
            InitializeComponent();
                // TODO: RSDN
            _textBoxDictionary = new Dictionary<TextBox, Action<LampParameters.LampParameters, string>>()
            {
                {
                    BodyDiameterTextBox,
                    (LampParameters.LampParameters lamp, string text) =>
                    {
                        lamp.BodyDiameter.Value = double.Parse(text);
                    }
                },
                {
                    BodyHeightTextBox, 
                    (LampParameters.LampParameters lamp, string text) => { lamp.BodyHeight.Value = double.Parse(text);}
                },
                {
                    TubeDiameterTextBox,
                    (LampParameters.LampParameters lamp, string text) => { lamp.TubeDiameter.Value = double.Parse(text);}
                },
                {
                    TubeHeightTextBox,
                    (LampParameters.LampParameters lamp, string text) => { lamp.TubeHeight.Value = double.Parse(text);}
                },
                {
                    SocketPlatformDiameterTextBox,
                    (LampParameters.LampParameters lamp, string text) => { lamp.SocketPlatformDiameter.Value = double.Parse(text);}
                },
                {
                    SocketPlatformHeightTextBox,
                    (LampParameters.LampParameters lamp, string text) => { lamp.SocketPlatformHeight.Value = double.Parse(text);}
                }
            };
            SizeComboBox.Items.Add("Maximum value");
            SizeComboBox.Items.Add("Minimum value");
            SizeComboBox.Items.Add("Default value");
            SizeComboBox.SelectedItem = "Default value";
            _lamp.DefaultValue();
            UpdateFormFields();
            SetLimits();
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
                    if (Validate())
                    {
                        BuildButton.Enabled = true;
                    }
                }
                catch (ArgumentException exception)
                {
                    currentTextBox.BackColor = Color.LightCoral;
                    MessageBox.Show(exception.Message);
                    BuildButton.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Метод для проверки на соответствие сохраненных и введенных параметров
        /// </summary>
        /// <returns></returns>
        private bool Validate()
        {
            //TODO
            if (BodyDiameterTextBox.Text.ToString() != _lamp.BodyDiameter.Value.ToString())
            {
                return false;
            }
            if (BodyHeightTextBox.Text.ToString() != _lamp.BodyHeight.Value.ToString())
            {
                return false;
            }
            if (SocketPlatformDiameterTextBox.Text.ToString() != _lamp.SocketPlatformDiameter.Value.ToString())
            {
                return false;
            }
            if (SocketPlatformHeightTextBox.Text.ToString() != _lamp.SocketPlatformHeight.Value.ToString())
            {
                return false;
            }
            if (TubeDiameterTextBox.Text.ToString() != _lamp.TubeDiameter.Value.ToString())
            {
                return false;
            }
            if (TubeHeightTextBox.Text.ToString() != _lamp.TubeHeight.Value.ToString())
            {
                return false;
            }
            return true;
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
        /// Метод, присваивающий значение предустановленных параметров в TextBox
        /// </summary>
        private void UpdateFormFields()
        {
            BodyDiameterTextBox.Text = _lamp.BodyDiameter.Value.ToString();
            BodyHeightTextBox.Text = _lamp.BodyHeight.Value.ToString();
            TubeDiameterTextBox.Text = _lamp.TubeDiameter.Value.ToString();
            TubeHeightTextBox.Text = _lamp.TubeHeight.Value.ToString();
            SocketPlatformDiameterTextBox.Text = _lamp.SocketPlatformDiameter.Value.ToString();
            SocketPlatformHeightTextBox.Text = _lamp.SocketPlatformHeight.Value.ToString();
        }

        /// <summary>
        /// Метод для проброса минимальных и максимальных параметров в форму
        /// </summary>
        private void SetLimits()
        {
            BodyDiameterLabel.Text = Convert.ToString($"Body Diameter ({_lamp.BodyDiameter.MinimumValue} - {_lamp.BodyDiameter.MaximumValue}) mm");
            BodyHeightLabel.Text = Convert.ToString($"Body Height ({_lamp.BodyHeight.MinimumValue} - {_lamp.BodyHeight.MaximumValue}) mm");
            TubeDiameterLabel.Text = Convert.ToString($"Tube Diameter ({_lamp.TubeDiameter.MinimumValue} - {_lamp.TubeDiameter.MaximumValue}) mm");
            TubeHeightLabel.Text = Convert.ToString($"Tube Height ({_lamp.TubeHeight.MinimumValue} - {_lamp.TubeHeight.MaximumValue}) mm");
            SocketPlatformDiameterLabel.Text = Convert.ToString($"Socket Platform Diameter ({_lamp.SocketPlatformDiameter.MinimumValue} - {_lamp.SocketPlatformDiameter.MaximumValue}) mm");
            SocketPlatformHeightLabel.Text = Convert.ToString($"Socket Platform Height ({_lamp.SocketPlatformHeight.MinimumValue} - {_lamp.SocketPlatformHeight.MaximumValue}) mm");
        }

        /// <summary>
        /// Метод, присваивающий белый цвет BackColor для TextBox
        /// </summary>
        private void WhiteColorTextBox()
        {
            BodyDiameterTextBox.BackColor = Color.White;
            BodyHeightTextBox.BackColor = Color.White; 
            TubeDiameterTextBox.BackColor = Color.White;
            TubeHeightTextBox.BackColor = Color.White;
            SocketPlatformHeightTextBox.BackColor = Color.White;
            SocketPlatformDiameterTextBox.BackColor = Color.White;
        }

        /// <summary>
        /// Обработчик кнопки Build
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (SizeComboBox.SelectedIndex == -1)
            {
                return;
            }
            //TODO switch case
            if (SizeComboBox.SelectedItem.ToString() == "Maximum value")
            {
                _lamp.MaxValue();
                UpdateFormFields();
                WhiteColorTextBox();
                BuildButton.Enabled = true;
            }
            if (SizeComboBox.SelectedItem.ToString() == "Default value")
            {
                _lamp.DefaultValue();
                UpdateFormFields();
                WhiteColorTextBox();
                BuildButton.Enabled = true;
            }
            if (SizeComboBox.SelectedItem.ToString() == "Minimum value")
            {
                _lamp.MinValue();
                UpdateFormFields();
                WhiteColorTextBox();
                BuildButton.Enabled = true;
            }
        }

        /// <summary>
        /// Закрытие плагина
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _build.CloseKompas();
            Environment.Exit(0);
        }

        //TODO
        private void BuildButton_Click(object sender, EventArgs e)
        {
            _build.BuildLamp(_lamp);
        }
        
        
    }
}
