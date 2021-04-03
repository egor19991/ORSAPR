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
using ModelParameters;
using LampBuilder;

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
        private LampBuilder.LampBuilder _build = new LampBuilder.LampBuilder();

         //TODO: RSDN
        /// <summary>
        /// Лист параметров
        /// </summary>
        private readonly List<Parameter> parameters;

        /// <summary>
        /// Лист c текстбоксами
        /// </summary>
        private List<TextBox> textBoxList = new List<TextBox>();

        /// <summary>
        /// Лист c текстбоксами
        /// </summary>
        private List<Label> labelList = new List<Label>();

        /// <summary>
        /// Лист c текстбоксами
        /// </summary>
        private List<string> sizeParameters = new List<string>();

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

            parameters = new List<Parameter>
            {
                _lamp.BodyDiameter,
                _lamp.BodyHeight,
                _lamp.TubeDiameter,
                _lamp.TubeHeight,
                _lamp.SocketPlatformDiameter,
                _lamp.SocketPlatformHeight
            };

            textBoxList.Add(BodyDiameterTextBox);
            textBoxList.Add(BodyHeightTextBox);
            textBoxList.Add(TubeDiameterTextBox);
            textBoxList.Add(TubeHeightTextBox);
            textBoxList.Add(SocketPlatformDiameterTextBox);
            textBoxList.Add(SocketPlatformHeightTextBox);

            labelList.Add(BodyDiameterLabel);
            labelList.Add(BodyHeightLabel);
            labelList.Add(TubeDiameterLabel);
            labelList.Add(TubeHeightLabel);
            labelList.Add(SocketPlatformDiameterLabel);
            labelList.Add(SocketPlatformHeightLabel);

            sizeParameters.Add("Maximum value");
            sizeParameters.Add("Minimum value");
            sizeParameters.Add("Default value");
            //SizeComboBox.Items.AddRange(new[] {sizeParameters});
            
            foreach (var parameter in sizeParameters)
            {
                SizeComboBox.Items.Add(parameter);
            }
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
            var smallestUpperBound = Math.Min(textBoxList.Count, parameters.Count);
            for (var index = 0; index < smallestUpperBound; index++)
            {
                if (textBoxList[index].Text.ToString() != parameters[index].Value.ToString())
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
            var smallestUpperBound = Math.Min(textBoxList.Count, parameters.Count);
            for (var index = 0; index < smallestUpperBound; index++)
            {
                textBoxList[index].Text = parameters[index].Value.ToString();
            }
        }

        /// <summary>
        /// Метод для проброса минимальных и максимальных параметров в label формы
        /// </summary>
        private void SetLimits()
        {
            var smallestUpperBound = Math.Min(labelList.Count, parameters.Count);
            for (var index = 0; index < smallestUpperBound; index++)
            {
                labelList[index].Text = Convert.ToString($"{parameters[index].NameParameter} " +
                                                         $"({parameters[index].MinimumValue} - " +
                                                         $"{parameters[index].MaximumValue}) mm");
            }
        }

        /// <summary>
        /// Метод, присваивающий белый цвет BackColor для TextBox
        /// </summary>
        private void WhiteColorTextBox()
        {
            foreach (var currentTextBox in textBoxList)
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
                {sizeParameters[0], () => _lamp.MaxValue()},
                {sizeParameters[1], () => _lamp.MinValue()},
                {sizeParameters[2], () => _lamp.DefaultValue()},
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
        
        
    }
}
