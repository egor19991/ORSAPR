using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ModelParameters;
using ModelBuilder;

namespace LampPluginUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Словарь для хранения сведений о TextBox
        /// </summary>
        private readonly Dictionary<TextBox, Action<LampParameters, string>>
            _textBoxDictionary;

        /// <summary>
        /// Поле хранящее данные о лампе
        /// </summary>
        private LampParameters _lamp = new LampParameters{};

        /// <summary>
        /// Поле для хранения данных о билдере
        /// </summary>
        private LampBuilder _build = new LampBuilder();

        /// <summary>
        /// Лист параметров
        /// </summary>
        private readonly List<Parameter> _parameters;

        /// <summary>
        /// Лист c текстбоксами
        /// </summary>
        private readonly List<TextBox> _textBoxList;

        /// <summary>
        /// Лист c текстбоксами
        /// </summary>
        private readonly List<Label> _labelList;

        /// <summary>
        /// Лист c текстбоксами
        /// </summary>
        private readonly List<string> _sizeParameters;

        public MainForm()
        {
            InitializeComponent();
            _textBoxDictionary = new Dictionary<TextBox, Action<LampParameters, string>>()
            {
                {
                    BodyDiameterTextBox,
                    (LampParameters lamp, string text) =>
                    {
                        lamp.BodyDiameter.Value = double.Parse(text);
                    }
                },
                {
                    BodyHeightTextBox,
                    (LampParameters lamp, string text) =>
                    {
                        lamp.BodyHeight.Value = double.Parse(text);
                    }
                },
                {
                    TubeDiameterTextBox,
                    (LampParameters lamp, string text) =>
                    {
                        lamp.TubeDiameter.Value = double.Parse(text);
                    }
                },
                {
                    TubeHeightTextBox,
                    (LampParameters lamp, string text) =>
                    {
                        lamp.TubeHeight.Value = double.Parse(text);
                    }
                },
                {
                    SocketPlatformDiameterTextBox,
                    (LampParameters lamp, string text) =>
                    {
                        lamp.SocketPlatformDiameter.Value = double.Parse(text);
                    }
                },
                {
                    SocketPlatformHeightTextBox,
                    (LampParameters lamp, string text) =>
                    {
                        lamp.SocketPlatformHeight.Value = double.Parse(text);
                    }
                }
            };

            _parameters = new List<Parameter>
            {
                _lamp.BodyDiameter,
                _lamp.BodyHeight,
                _lamp.TubeDiameter,
                _lamp.TubeHeight,
                _lamp.SocketPlatformDiameter,
                _lamp.SocketPlatformHeight
            };

            _textBoxList = new List<TextBox>
            {
                BodyDiameterTextBox,
                BodyHeightTextBox,
                TubeDiameterTextBox,
                TubeHeightTextBox,
                SocketPlatformDiameterTextBox,
                SocketPlatformHeightTextBox
            };

            _labelList = new List<Label>
            {
                BodyDiameterLabel,
                BodyHeightLabel,
                TubeDiameterLabel,
                TubeHeightLabel,
                SocketPlatformDiameterLabel,
                SocketPlatformHeightLabel
            };

            _sizeParameters = new List<string>
            {
                "Maximum value",
                "Minimum value",
                "Default value"
            };

           // SizeComboBox.Items.AddRange( CollectionConverter sizeParameters );
           SizeComboBox.Items.AddRange(_sizeParameters.ToArray());
            //foreach (var parameter in sizeParameters)
            //{
            //    SizeComboBox.Items.Add(parameter);
            //}
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
            if (!String.IsNullOrEmpty(currentTextBox.Text))
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
            var smallestUpperBound = Math.Min(_textBoxList.Count, _parameters.Count);
            for (var index = 0; index < smallestUpperBound; index++)
            {
                if (_textBoxList[index].Text.ToString() != _parameters[index].Value.ToString())
                {
                    return false;
                }
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
            var smallestUpperBound = Math.Min(_textBoxList.Count, _parameters.Count);
            for (var index = 0; index < smallestUpperBound; index++)
            {
                _textBoxList[index].Text = _parameters[index].Value.ToString();
            }
        }

        /// <summary>
        /// Метод для проброса минимальных и максимальных параметров в label формы
        /// </summary>
        private void SetLimits()
        {
            var smallestUpperBound = Math.Min(_labelList.Count, _parameters.Count);
            for (var index = 0; index < smallestUpperBound; index++)
            {
                _labelList[index].Text = Convert.ToString($"{_parameters[index].NameParameter} " +
                                                         $"({_parameters[index].MinimumValue} - " +
                                                         $"{_parameters[index].MaximumValue}) mm");
            }
        }

        /// <summary>
        /// Метод, присваивающий белый цвет BackColor для TextBox
        /// </summary>
        private void WhiteColorTextBox()
        {
            foreach (var currentTextBox in _textBoxList)
            {
                currentTextBox.BackColor = Color.White;
            }
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

            var tmpDictionary = new Dictionary<string, Action>()
            {
                {_sizeParameters[0], () => _lamp.MaxValue()},
                {_sizeParameters[1], () => _lamp.MinValue()},
                {_sizeParameters[2], () => _lamp.DefaultValue()},
            };

            tmpDictionary[SizeComboBox.SelectedItem.ToString()].Invoke();

            UpdateFormFields();
            WhiteColorTextBox();
            BuildButton.Enabled = true;
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

        /// <summary>
        /// Кнопка для построения плагина
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            _build.BuildLamp(_lamp);
        }

        private void FloorLampCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FloorLampCheckBox.Checked)
            {
                _lamp.EnableFloorLamp = true;
            }
        }
    }
}
