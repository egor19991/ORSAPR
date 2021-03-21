﻿using System;
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

        public MainForm()
        {
            InitializeComponent();
            _lamp.Avg();
            UpdateFormFields();
            _textBoxDictionary = new Dictionary<TextBox, Action<Lamp, string>>()
            {
                {
                    DiametrBodyTextBox, 
                    (Lamp lamp, string text) => {lamp.Body.Diametr = Int32.Parse(text);}
                },
                {
                    HeightBodyTextBox, 
                    (Lamp lamp, string text) => {lamp.Body.Height = Int32.Parse(text);}
                },
                {
                    DiametrTubeTextBox,
                    (Lamp lamp, string text) => {lamp.Tube.Diametr = Int32.Parse(text);}
                },
                {
                    HeightTubeTextBox,
                    (Lamp lamp, string text) => {lamp.Tube.Height = Int32.Parse(text);}
                },
                {
                    DiametrSocketPlatformTextBox,
                    (Lamp lamp, string text) => {lamp.SocketPlatform.Diametr = Int32.Parse(text);}
                },
                {
                    HeightSocketPlatformTextBox,
                    (Lamp lamp, string text) => {lamp.SocketPlatform.Height = Int32.Parse(text);}
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
        /// Обработчик, который позволяет вводить только цифры в TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxAllowOnlyNumbers(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Метод, присваивающий значение TextBox
        /// </summary>
        private void UpdateFormFields()
        {
            DiametrBodyTextBox.Text = _lamp.Body.Diametr.ToString();
            HeightBodyTextBox.Text = _lamp.Body.Height.ToString();
            DiametrTubeTextBox.Text = _lamp.Tube.Diametr.ToString();
            HeightTubeTextBox.Text = _lamp.Tube.Height.ToString();
            DiametrSocketPlatformTextBox.Text = _lamp.SocketPlatform.Diametr.ToString();
            HeightSocketPlatformTextBox.Text = _lamp.SocketPlatform.Height.ToString();
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

        private LampBuild _build = new LampBuild();
        private void BuildButton_Click(object sender, EventArgs e)
        {
            _build.SvinRT(_lamp);
        }

       
    }
}
