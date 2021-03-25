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
        private readonly Dictionary<TextBox, Action<LampParameters.LampParameters, string>> _textBoxDictionary;

        /// <summary>
        /// Поле хранящее данные о лампе
        /// </summary>
        private LampParameters.LampParameters _lamp = new LampParameters.LampParameters{};

        private LampBuilder.LampBuilder _build = new LampBuilder.LampBuilder();

        public MainForm()
        {
            InitializeComponent();
            _textBoxDictionary = new Dictionary<TextBox, Action<LampParameters.LampParameters, string>>()
            {
                {
                    DiametrBodyTextBox, 
                    (LampParameters.LampParameters lamp, string text) => { lamp.BodyDiametr.Value = double.Parse(text);}
                },
                {
                    HeightBodyTextBox, 
                    (LampParameters.LampParameters lamp, string text) => { lamp.BodyHeight.Value = double.Parse(text);}
                },
                {
                    DiametrTubeTextBox,
                    (LampParameters.LampParameters lamp, string text) => { lamp.TubeDiametr.Value = double.Parse(text);}
                },
                {
                    HeightTubeTextBox,
                    (LampParameters.LampParameters lamp, string text) => { lamp.TubeHeight.Value = double.Parse(text);}
                },
                {
                    DiametrSocketPlatformTextBox,
                    (LampParameters.LampParameters lamp, string text) => { lamp.SocketPlatformDiametr.Value = double.Parse(text);}
                },
                {
                    HeightSocketPlatformTextBox,
                    (LampParameters.LampParameters lamp, string text) => { lamp.SocketPlatformHeight.Value = double.Parse(text);}
                }
            };
            SizeComboBox.Items.Add("Maximum value");
            SizeComboBox.Items.Add("Average value");
            SizeComboBox.Items.Add("Minimum value");
            SizeComboBox.SelectedItem = "Average value";
            _lamp.AvgValue();
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
            DiametrBodyTextBox.Text = _lamp.BodyDiametr.Value.ToString();
            HeightBodyTextBox.Text = _lamp.BodyHeight.Value.ToString();
            DiametrTubeTextBox.Text = _lamp.TubeDiametr.Value.ToString();
            HeightTubeTextBox.Text = _lamp.TubeHeight.Value.ToString();
            DiametrSocketPlatformTextBox.Text = _lamp.SocketPlatformDiametr.Value.ToString();
            HeightSocketPlatformTextBox.Text = _lamp.SocketPlatformHeight.Value.ToString();
        }

        private void SetLimits()
        {
            LampBodyDiameterLabel.Text = Convert.ToString($"Body Diameter ({_lamp.BodyDiametr.MinimumValue} - {_lamp.BodyDiametr.MaximumValue}) mm");
            LampBodyHeightLabel.Text = Convert.ToString($"Body Height ({_lamp.BodyHeight.MinimumValue} - {_lamp.BodyHeight.MaximumValue}) mm");
            LampTubeDiameterLabel.Text = Convert.ToString($"Tube Diameter ({_lamp.TubeDiametr.MinimumValue} - {_lamp.TubeDiametr.MaximumValue}) mm");
            LampTubeHeightLabel.Text = Convert.ToString($"Tube Height ({_lamp.TubeHeight.MinimumValue} - {_lamp.TubeHeight.MaximumValue}) mm");
            LampSocketPlatformDiameterLabel.Text = Convert.ToString($"Socket Platform Diameter ({_lamp.SocketPlatformDiametr.MinimumValue} - {_lamp.SocketPlatformDiametr.MaximumValue}) mm");
            LampSocketPlatformHeightLabel.Text = Convert.ToString($"Socket Platform Height ({_lamp.SocketPlatformHeight.MinimumValue} - {_lamp.SocketPlatformHeight.MaximumValue}) mm");
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

        private void BuildButton_Click(object sender, EventArgs e)
        {
            _build.BuildLamp(_lamp);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (SizeComboBox.SelectedIndex == -1)
            {
                return;
            }
            if (SizeComboBox.SelectedItem.ToString() == "Maximum value")
            {
                _lamp.MaxValue();
                UpdateFormFields();
            }
            if (SizeComboBox.SelectedItem.ToString() == "Average value")
            {
                _lamp.AvgValue();
                UpdateFormFields();
            }
            if (SizeComboBox.SelectedItem.ToString() == "Minimum value")
            {
                _lamp.MinValue();
                UpdateFormFields();
            }
        }
    }
}
