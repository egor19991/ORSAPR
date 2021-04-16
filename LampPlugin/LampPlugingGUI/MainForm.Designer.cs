
namespace LampPluginUI
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.LampBodyLabel = new System.Windows.Forms.Label();
            this.BodyDiameterTextBox = new System.Windows.Forms.TextBox();
            this.BodyHeightTextBox = new System.Windows.Forms.TextBox();
            this.BodyHeightLabel = new System.Windows.Forms.Label();
            this.LampTubeLabel = new System.Windows.Forms.Label();
            this.TubeDiameterLabel = new System.Windows.Forms.Label();
            this.TubeHeightLabel = new System.Windows.Forms.Label();
            this.TubeDiameterTextBox = new System.Windows.Forms.TextBox();
            this.TubeHeightTextBox = new System.Windows.Forms.TextBox();
            this.SocketPlatformLabel = new System.Windows.Forms.Label();
            this.BodyDiameterLabel = new System.Windows.Forms.Label();
            this.SocketPlatformHeightTextBox = new System.Windows.Forms.TextBox();
            this.SocketPlatformDiameterTextBox = new System.Windows.Forms.TextBox();
            this.SocketPlatformHeightLabel = new System.Windows.Forms.Label();
            this.SocketPlatformDiameterLabel = new System.Windows.Forms.Label();
            this.BuildButton = new System.Windows.Forms.Button();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.SizeComboBox = new System.Windows.Forms.ComboBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.FloorLampLabel = new System.Windows.Forms.Label();
            this.FloorLampCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LampBodyLabel
            // 
            this.LampBodyLabel.AutoSize = true;
            this.LampBodyLabel.Location = new System.Drawing.Point(8, 11);
            this.LampBodyLabel.Name = "LampBodyLabel";
            this.LampBodyLabel.Size = new System.Drawing.Size(0, 13);
            this.LampBodyLabel.TabIndex = 0;
            // 
            // BodyDiameterTextBox
            // 
            this.BodyDiameterTextBox.Location = new System.Drawing.Point(203, 8);
            this.BodyDiameterTextBox.Name = "BodyDiameterTextBox";
            this.BodyDiameterTextBox.Size = new System.Drawing.Size(45, 20);
            this.BodyDiameterTextBox.TabIndex = 1;
            this.BodyDiameterTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAllowOnlyNumbers);
            this.BodyDiameterTextBox.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // BodyHeightTextBox
            // 
            this.BodyHeightTextBox.Location = new System.Drawing.Point(203, 86);
            this.BodyHeightTextBox.Name = "BodyHeightTextBox";
            this.BodyHeightTextBox.Size = new System.Drawing.Size(45, 20);
            this.BodyHeightTextBox.TabIndex = 2;
            this.BodyHeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAllowOnlyNumbers);
            this.BodyHeightTextBox.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // BodyHeightLabel
            // 
            this.BodyHeightLabel.AutoSize = true;
            this.BodyHeightLabel.Location = new System.Drawing.Point(8, 89);
            this.BodyHeightLabel.Name = "BodyHeightLabel";
            this.BodyHeightLabel.Size = new System.Drawing.Size(94, 13);
            this.BodyHeightLabel.TabIndex = 3;
            this.BodyHeightLabel.Text = "Lamp Body Height";
            // 
            // LampTubeLabel
            // 
            this.LampTubeLabel.AutoSize = true;
            this.LampTubeLabel.Location = new System.Drawing.Point(8, 45);
            this.LampTubeLabel.Name = "LampTubeLabel";
            this.LampTubeLabel.Size = new System.Drawing.Size(0, 13);
            this.LampTubeLabel.TabIndex = 4;
            // 
            // TubeDiameterLabel
            // 
            this.TubeDiameterLabel.AutoSize = true;
            this.TubeDiameterLabel.Location = new System.Drawing.Point(8, 37);
            this.TubeDiameterLabel.Name = "TubeDiameterLabel";
            this.TubeDiameterLabel.Size = new System.Drawing.Size(106, 13);
            this.TubeDiameterLabel.TabIndex = 5;
            this.TubeDiameterLabel.Text = "Lamp Tube Diameter";
            // 
            // TubeHeightLabel
            // 
            this.TubeHeightLabel.AutoSize = true;
            this.TubeHeightLabel.Location = new System.Drawing.Point(8, 115);
            this.TubeHeightLabel.Name = "TubeHeightLabel";
            this.TubeHeightLabel.Size = new System.Drawing.Size(95, 13);
            this.TubeHeightLabel.TabIndex = 6;
            this.TubeHeightLabel.Text = "Lamp Tube Height";
            // 
            // TubeDiameterTextBox
            // 
            this.TubeDiameterTextBox.Location = new System.Drawing.Point(203, 34);
            this.TubeDiameterTextBox.Name = "TubeDiameterTextBox";
            this.TubeDiameterTextBox.Size = new System.Drawing.Size(45, 20);
            this.TubeDiameterTextBox.TabIndex = 7;
            this.TubeDiameterTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAllowOnlyNumbers);
            this.TubeDiameterTextBox.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // TubeHeightTextBox
            // 
            this.TubeHeightTextBox.Location = new System.Drawing.Point(203, 112);
            this.TubeHeightTextBox.Name = "TubeHeightTextBox";
            this.TubeHeightTextBox.Size = new System.Drawing.Size(45, 20);
            this.TubeHeightTextBox.TabIndex = 8;
            this.TubeHeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAllowOnlyNumbers);
            this.TubeHeightTextBox.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // SocketPlatformLabel
            // 
            this.SocketPlatformLabel.AutoSize = true;
            this.SocketPlatformLabel.Location = new System.Drawing.Point(8, 68);
            this.SocketPlatformLabel.Name = "SocketPlatformLabel";
            this.SocketPlatformLabel.Size = new System.Drawing.Size(0, 13);
            this.SocketPlatformLabel.TabIndex = 9;
            // 
            // BodyDiameterLabel
            // 
            this.BodyDiameterLabel.AutoSize = true;
            this.BodyDiameterLabel.Location = new System.Drawing.Point(8, 11);
            this.BodyDiameterLabel.Name = "BodyDiameterLabel";
            this.BodyDiameterLabel.Size = new System.Drawing.Size(105, 13);
            this.BodyDiameterLabel.TabIndex = 10;
            this.BodyDiameterLabel.Text = "Lamp Body Diameter";
            // 
            // SocketPlatformHeightTextBox
            // 
            this.SocketPlatformHeightTextBox.Location = new System.Drawing.Point(203, 138);
            this.SocketPlatformHeightTextBox.Name = "SocketPlatformHeightTextBox";
            this.SocketPlatformHeightTextBox.Size = new System.Drawing.Size(45, 20);
            this.SocketPlatformHeightTextBox.TabIndex = 14;
            this.SocketPlatformHeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAllowOnlyNumbers);
            this.SocketPlatformHeightTextBox.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // SocketPlatformDiameterTextBox
            // 
            this.SocketPlatformDiameterTextBox.Location = new System.Drawing.Point(203, 60);
            this.SocketPlatformDiameterTextBox.Name = "SocketPlatformDiameterTextBox";
            this.SocketPlatformDiameterTextBox.Size = new System.Drawing.Size(45, 20);
            this.SocketPlatformDiameterTextBox.TabIndex = 13;
            this.SocketPlatformDiameterTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAllowOnlyNumbers);
            this.SocketPlatformDiameterTextBox.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // SocketPlatformHeightLabel
            // 
            this.SocketPlatformHeightLabel.AutoSize = true;
            this.SocketPlatformHeightLabel.Location = new System.Drawing.Point(8, 141);
            this.SocketPlatformHeightLabel.Name = "SocketPlatformHeightLabel";
            this.SocketPlatformHeightLabel.Size = new System.Drawing.Size(111, 13);
            this.SocketPlatformHeightLabel.TabIndex = 12;
            this.SocketPlatformHeightLabel.Text = "Lamp Socket Platform";
            // 
            // SocketPlatformDiameterLabel
            // 
            this.SocketPlatformDiameterLabel.AutoSize = true;
            this.SocketPlatformDiameterLabel.Location = new System.Drawing.Point(8, 63);
            this.SocketPlatformDiameterLabel.Name = "SocketPlatformDiameterLabel";
            this.SocketPlatformDiameterLabel.Size = new System.Drawing.Size(153, 13);
            this.SocketPlatformDiameterLabel.TabIndex = 11;
            this.SocketPlatformDiameterLabel.Text = "LampSocket Platform Diameter";
            // 
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(96, 222);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(75, 23);
            this.BuildButton.TabIndex = 15;
            this.BuildButton.Text = "Build";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Location = new System.Drawing.Point(8, 193);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(82, 13);
            this.SizeLabel.TabIndex = 16;
            this.SizeLabel.Text = "Size parameters";
            // 
            // SizeComboBox
            // 
            this.SizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SizeComboBox.FormattingEnabled = true;
            this.SizeComboBox.IntegralHeight = false;
            this.SizeComboBox.Location = new System.Drawing.Point(96, 189);
            this.SizeComboBox.Name = "SizeComboBox";
            this.SizeComboBox.Size = new System.Drawing.Size(96, 21);
            this.SizeComboBox.TabIndex = 17;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(204, 188);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(48, 23);
            this.ApplyButton.TabIndex = 18;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // FloorLampLabel
            // 
            this.FloorLampLabel.AutoSize = true;
            this.FloorLampLabel.Location = new System.Drawing.Point(8, 165);
            this.FloorLampLabel.Name = "FloorLampLabel";
            this.FloorLampLabel.Size = new System.Drawing.Size(95, 13);
            this.FloorLampLabel.TabIndex = 19;
            this.FloorLampLabel.Text = "Enable Floor Lamp";
            // 
            // FloorLampCheckBox
            // 
            this.FloorLampCheckBox.AutoSize = true;
            this.FloorLampCheckBox.Location = new System.Drawing.Point(218, 164);
            this.FloorLampCheckBox.Name = "FloorLampCheckBox";
            this.FloorLampCheckBox.Size = new System.Drawing.Size(15, 14);
            this.FloorLampCheckBox.TabIndex = 20;
            this.FloorLampCheckBox.UseVisualStyleBackColor = true;
            this.FloorLampCheckBox.CheckedChanged += new System.EventHandler(this.FloorLampCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(264, 251);
            this.Controls.Add(this.FloorLampCheckBox);
            this.Controls.Add(this.FloorLampLabel);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.SizeComboBox);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.BuildButton);
            this.Controls.Add(this.SocketPlatformHeightTextBox);
            this.Controls.Add(this.SocketPlatformDiameterTextBox);
            this.Controls.Add(this.SocketPlatformHeightLabel);
            this.Controls.Add(this.SocketPlatformDiameterLabel);
            this.Controls.Add(this.BodyDiameterLabel);
            this.Controls.Add(this.SocketPlatformLabel);
            this.Controls.Add(this.TubeHeightTextBox);
            this.Controls.Add(this.TubeDiameterTextBox);
            this.Controls.Add(this.TubeHeightLabel);
            this.Controls.Add(this.TubeDiameterLabel);
            this.Controls.Add(this.LampTubeLabel);
            this.Controls.Add(this.BodyHeightLabel);
            this.Controls.Add(this.BodyHeightTextBox);
            this.Controls.Add(this.BodyDiameterTextBox);
            this.Controls.Add(this.LampBodyLabel);
            this.MaximumSize = new System.Drawing.Size(280, 290);
            this.MinimumSize = new System.Drawing.Size(280, 290);
            this.Name = "MainForm";
            this.Text = "Lamp Plugin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LampBodyLabel;
        private System.Windows.Forms.TextBox BodyDiameterTextBox;
        private System.Windows.Forms.TextBox BodyHeightTextBox;
        private System.Windows.Forms.Label BodyHeightLabel;
        private System.Windows.Forms.Label LampTubeLabel;
        private System.Windows.Forms.Label TubeDiameterLabel;
        private System.Windows.Forms.Label TubeHeightLabel;
        private System.Windows.Forms.TextBox TubeDiameterTextBox;
        private System.Windows.Forms.TextBox TubeHeightTextBox;
        private System.Windows.Forms.Label SocketPlatformLabel;
        private System.Windows.Forms.Label BodyDiameterLabel;
        private System.Windows.Forms.TextBox SocketPlatformHeightTextBox;
        private System.Windows.Forms.TextBox SocketPlatformDiameterTextBox;
        private System.Windows.Forms.Label SocketPlatformHeightLabel;
        private System.Windows.Forms.Label SocketPlatformDiameterLabel;
        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.ComboBox SizeComboBox;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Label FloorLampLabel;
        private System.Windows.Forms.CheckBox FloorLampCheckBox;
    }
}

