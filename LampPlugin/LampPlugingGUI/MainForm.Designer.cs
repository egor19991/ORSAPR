
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
            this.DiametrBodyTextBox = new System.Windows.Forms.TextBox();
            this.HeightBodyTextBox = new System.Windows.Forms.TextBox();
            this.LampBodyHeightLabel = new System.Windows.Forms.Label();
            this.LampTubeLabel = new System.Windows.Forms.Label();
            this.LampTubeDiameterLabel = new System.Windows.Forms.Label();
            this.LampTubeHeightLabel = new System.Windows.Forms.Label();
            this.DiametrTubeTextBox = new System.Windows.Forms.TextBox();
            this.HeightTubeTextBox = new System.Windows.Forms.TextBox();
            this.SocketPlatformLabel = new System.Windows.Forms.Label();
            this.LampBodyDiameterLabel = new System.Windows.Forms.Label();
            this.HeightSocketPlatformTextBox = new System.Windows.Forms.TextBox();
            this.DiametrSocketPlatformTextBox = new System.Windows.Forms.TextBox();
            this.LampSocketPlatformHeightLabel = new System.Windows.Forms.Label();
            this.LampSocketPlatformDiameterLabel = new System.Windows.Forms.Label();
            this.BuildButton = new System.Windows.Forms.Button();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.SizeComboBox = new System.Windows.Forms.ComboBox();
            this.Фbutton = new System.Windows.Forms.Button();
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
            // DiametrBodyTextBox
            // 
            this.DiametrBodyTextBox.Location = new System.Drawing.Point(204, 8);
            this.DiametrBodyTextBox.Name = "DiametrBodyTextBox";
            this.DiametrBodyTextBox.Size = new System.Drawing.Size(45, 20);
            this.DiametrBodyTextBox.TabIndex = 1;
            this.DiametrBodyTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAllowOnlyNumbers);
            this.DiametrBodyTextBox.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // HeightBodyTextBox
            // 
            this.HeightBodyTextBox.Location = new System.Drawing.Point(204, 86);
            this.HeightBodyTextBox.Name = "HeightBodyTextBox";
            this.HeightBodyTextBox.Size = new System.Drawing.Size(47, 20);
            this.HeightBodyTextBox.TabIndex = 2;
            this.HeightBodyTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAllowOnlyNumbers);
            this.HeightBodyTextBox.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // LampBodyHeightLabel
            // 
            this.LampBodyHeightLabel.AutoSize = true;
            this.LampBodyHeightLabel.Location = new System.Drawing.Point(8, 89);
            this.LampBodyHeightLabel.Name = "LampBodyHeightLabel";
            this.LampBodyHeightLabel.Size = new System.Drawing.Size(94, 13);
            this.LampBodyHeightLabel.TabIndex = 3;
            this.LampBodyHeightLabel.Text = "Lamp Body Height";
            // 
            // LampTubeLabel
            // 
            this.LampTubeLabel.AutoSize = true;
            this.LampTubeLabel.Location = new System.Drawing.Point(8, 45);
            this.LampTubeLabel.Name = "LampTubeLabel";
            this.LampTubeLabel.Size = new System.Drawing.Size(0, 13);
            this.LampTubeLabel.TabIndex = 4;
            // 
            // LampTubeDiameterLabel
            // 
            this.LampTubeDiameterLabel.AutoSize = true;
            this.LampTubeDiameterLabel.Location = new System.Drawing.Point(8, 37);
            this.LampTubeDiameterLabel.Name = "LampTubeDiameterLabel";
            this.LampTubeDiameterLabel.Size = new System.Drawing.Size(106, 13);
            this.LampTubeDiameterLabel.TabIndex = 5;
            this.LampTubeDiameterLabel.Text = "Lamp Tube Diameter";
            // 
            // LampTubeHeightLabel
            // 
            this.LampTubeHeightLabel.AutoSize = true;
            this.LampTubeHeightLabel.Location = new System.Drawing.Point(8, 115);
            this.LampTubeHeightLabel.Name = "LampTubeHeightLabel";
            this.LampTubeHeightLabel.Size = new System.Drawing.Size(95, 13);
            this.LampTubeHeightLabel.TabIndex = 6;
            this.LampTubeHeightLabel.Text = "Lamp Tube Height";
            // 
            // DiametrTubeTextBox
            // 
            this.DiametrTubeTextBox.Location = new System.Drawing.Point(204, 34);
            this.DiametrTubeTextBox.Name = "DiametrTubeTextBox";
            this.DiametrTubeTextBox.Size = new System.Drawing.Size(45, 20);
            this.DiametrTubeTextBox.TabIndex = 7;
            this.DiametrTubeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAllowOnlyNumbers);
            this.DiametrTubeTextBox.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // HeightTubeTextBox
            // 
            this.HeightTubeTextBox.Location = new System.Drawing.Point(204, 112);
            this.HeightTubeTextBox.Name = "HeightTubeTextBox";
            this.HeightTubeTextBox.Size = new System.Drawing.Size(47, 20);
            this.HeightTubeTextBox.TabIndex = 8;
            this.HeightTubeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAllowOnlyNumbers);
            this.HeightTubeTextBox.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // SocketPlatformLabel
            // 
            this.SocketPlatformLabel.AutoSize = true;
            this.SocketPlatformLabel.Location = new System.Drawing.Point(8, 68);
            this.SocketPlatformLabel.Name = "SocketPlatformLabel";
            this.SocketPlatformLabel.Size = new System.Drawing.Size(0, 13);
            this.SocketPlatformLabel.TabIndex = 9;
            // 
            // LampBodyDiameterLabel
            // 
            this.LampBodyDiameterLabel.AutoSize = true;
            this.LampBodyDiameterLabel.Location = new System.Drawing.Point(8, 11);
            this.LampBodyDiameterLabel.Name = "LampBodyDiameterLabel";
            this.LampBodyDiameterLabel.Size = new System.Drawing.Size(105, 13);
            this.LampBodyDiameterLabel.TabIndex = 10;
            this.LampBodyDiameterLabel.Text = "Lamp Body Diameter";
            // 
            // HeightSocketPlatformTextBox
            // 
            this.HeightSocketPlatformTextBox.Location = new System.Drawing.Point(204, 138);
            this.HeightSocketPlatformTextBox.Name = "HeightSocketPlatformTextBox";
            this.HeightSocketPlatformTextBox.Size = new System.Drawing.Size(47, 20);
            this.HeightSocketPlatformTextBox.TabIndex = 14;
            this.HeightSocketPlatformTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAllowOnlyNumbers);
            this.HeightSocketPlatformTextBox.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // DiametrSocketPlatformTextBox
            // 
            this.DiametrSocketPlatformTextBox.Location = new System.Drawing.Point(204, 60);
            this.DiametrSocketPlatformTextBox.Name = "DiametrSocketPlatformTextBox";
            this.DiametrSocketPlatformTextBox.Size = new System.Drawing.Size(45, 20);
            this.DiametrSocketPlatformTextBox.TabIndex = 13;
            this.DiametrSocketPlatformTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAllowOnlyNumbers);
            this.DiametrSocketPlatformTextBox.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // LampSocketPlatformHeightLabel
            // 
            this.LampSocketPlatformHeightLabel.AutoSize = true;
            this.LampSocketPlatformHeightLabel.Location = new System.Drawing.Point(8, 141);
            this.LampSocketPlatformHeightLabel.Name = "LampSocketPlatformHeightLabel";
            this.LampSocketPlatformHeightLabel.Size = new System.Drawing.Size(111, 13);
            this.LampSocketPlatformHeightLabel.TabIndex = 12;
            this.LampSocketPlatformHeightLabel.Text = "Lamp Socket Platform";
            // 
            // LampSocketPlatformDiameterLabel
            // 
            this.LampSocketPlatformDiameterLabel.AutoSize = true;
            this.LampSocketPlatformDiameterLabel.Location = new System.Drawing.Point(8, 63);
            this.LampSocketPlatformDiameterLabel.Name = "LampSocketPlatformDiameterLabel";
            this.LampSocketPlatformDiameterLabel.Size = new System.Drawing.Size(153, 13);
            this.LampSocketPlatformDiameterLabel.TabIndex = 11;
            this.LampSocketPlatformDiameterLabel.Text = "LampSocket Platform Diameter";
            // 
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(96, 207);
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
            this.SizeLabel.Location = new System.Drawing.Point(8, 178);
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
            this.SizeComboBox.Location = new System.Drawing.Point(96, 174);
            this.SizeComboBox.Name = "SizeComboBox";
            this.SizeComboBox.Size = new System.Drawing.Size(96, 21);
            this.SizeComboBox.TabIndex = 17;
            // 
            // Фbutton
            // 
            this.Фbutton.Location = new System.Drawing.Point(204, 173);
            this.Фbutton.Name = "Фbutton";
            this.Фbutton.Size = new System.Drawing.Size(48, 23);
            this.Фbutton.TabIndex = 18;
            this.Фbutton.Text = "Apply";
            this.Фbutton.UseVisualStyleBackColor = true;
            this.Фbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(261, 242);
            this.Controls.Add(this.Фbutton);
            this.Controls.Add(this.SizeComboBox);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.BuildButton);
            this.Controls.Add(this.HeightSocketPlatformTextBox);
            this.Controls.Add(this.DiametrSocketPlatformTextBox);
            this.Controls.Add(this.LampSocketPlatformHeightLabel);
            this.Controls.Add(this.LampSocketPlatformDiameterLabel);
            this.Controls.Add(this.LampBodyDiameterLabel);
            this.Controls.Add(this.SocketPlatformLabel);
            this.Controls.Add(this.HeightTubeTextBox);
            this.Controls.Add(this.DiametrTubeTextBox);
            this.Controls.Add(this.LampTubeHeightLabel);
            this.Controls.Add(this.LampTubeDiameterLabel);
            this.Controls.Add(this.LampTubeLabel);
            this.Controls.Add(this.LampBodyHeightLabel);
            this.Controls.Add(this.HeightBodyTextBox);
            this.Controls.Add(this.DiametrBodyTextBox);
            this.Controls.Add(this.LampBodyLabel);
            this.Name = "MainForm";
            this.Text = "Lamp Plugin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LampBodyLabel;
        private System.Windows.Forms.TextBox DiametrBodyTextBox;
        private System.Windows.Forms.TextBox HeightBodyTextBox;
        private System.Windows.Forms.Label LampBodyHeightLabel;
        private System.Windows.Forms.Label LampTubeLabel;
        private System.Windows.Forms.Label LampTubeDiameterLabel;
        private System.Windows.Forms.Label LampTubeHeightLabel;
        private System.Windows.Forms.TextBox DiametrTubeTextBox;
        private System.Windows.Forms.TextBox HeightTubeTextBox;
        private System.Windows.Forms.Label SocketPlatformLabel;
        private System.Windows.Forms.Label LampBodyDiameterLabel;
        private System.Windows.Forms.TextBox HeightSocketPlatformTextBox;
        private System.Windows.Forms.TextBox DiametrSocketPlatformTextBox;
        private System.Windows.Forms.Label LampSocketPlatformHeightLabel;
        private System.Windows.Forms.Label LampSocketPlatformDiameterLabel;
        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.ComboBox SizeComboBox;
        private System.Windows.Forms.Button Фbutton;
    }
}

