
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
            this.label2 = new System.Windows.Forms.Label();
            this.LampTubeLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DiametrTubeTextBox = new System.Windows.Forms.TextBox();
            this.HeightTubeTextBox = new System.Windows.Forms.TextBox();
            this.SocketPlatformLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.HeightSocketPlatformTextBox = new System.Windows.Forms.TextBox();
            this.DiametrSocketPlatformTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.BuildButton = new System.Windows.Forms.Button();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.SizeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // LampBodyLabel
            // 
            this.LampBodyLabel.AutoSize = true;
            this.LampBodyLabel.Location = new System.Drawing.Point(15, 39);
            this.LampBodyLabel.Name = "LampBodyLabel";
            this.LampBodyLabel.Size = new System.Drawing.Size(60, 13);
            this.LampBodyLabel.TabIndex = 0;
            this.LampBodyLabel.Text = "Lamp Body";
            // 
            // DiametrBodyTextBox
            // 
            this.DiametrBodyTextBox.Location = new System.Drawing.Point(141, 36);
            this.DiametrBodyTextBox.Name = "DiametrBodyTextBox";
            this.DiametrBodyTextBox.Size = new System.Drawing.Size(45, 20);
            this.DiametrBodyTextBox.TabIndex = 1;
            this.DiametrBodyTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAllowOnlyNumbers);
            this.DiametrBodyTextBox.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // HeightBodyTextBox
            // 
            this.HeightBodyTextBox.Location = new System.Drawing.Point(214, 36);
            this.HeightBodyTextBox.Name = "HeightBodyTextBox";
            this.HeightBodyTextBox.Size = new System.Drawing.Size(47, 20);
            this.HeightBodyTextBox.TabIndex = 2;
            this.HeightBodyTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAllowOnlyNumbers);
            this.HeightBodyTextBox.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "H";
            // 
            // LampTubeLabel
            // 
            this.LampTubeLabel.AutoSize = true;
            this.LampTubeLabel.Location = new System.Drawing.Point(15, 69);
            this.LampTubeLabel.Name = "LampTubeLabel";
            this.LampTubeLabel.Size = new System.Drawing.Size(61, 13);
            this.LampTubeLabel.TabIndex = 4;
            this.LampTubeLabel.Text = "Lamp Tube";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "D";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "H";
            // 
            // DiametrTubeTextBox
            // 
            this.DiametrTubeTextBox.Location = new System.Drawing.Point(141, 66);
            this.DiametrTubeTextBox.Name = "DiametrTubeTextBox";
            this.DiametrTubeTextBox.Size = new System.Drawing.Size(45, 20);
            this.DiametrTubeTextBox.TabIndex = 7;
            this.DiametrTubeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAllowOnlyNumbers);
            this.DiametrTubeTextBox.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // HeightTubeTextBox
            // 
            this.HeightTubeTextBox.Location = new System.Drawing.Point(214, 66);
            this.HeightTubeTextBox.Name = "HeightTubeTextBox";
            this.HeightTubeTextBox.Size = new System.Drawing.Size(47, 20);
            this.HeightTubeTextBox.TabIndex = 8;
            this.HeightTubeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAllowOnlyNumbers);
            this.HeightTubeTextBox.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // SocketPlatformLabel
            // 
            this.SocketPlatformLabel.AutoSize = true;
            this.SocketPlatformLabel.Location = new System.Drawing.Point(15, 102);
            this.SocketPlatformLabel.Name = "SocketPlatformLabel";
            this.SocketPlatformLabel.Size = new System.Drawing.Size(82, 13);
            this.SocketPlatformLabel.TabIndex = 9;
            this.SocketPlatformLabel.Text = "Socket Platform";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(120, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "D";
            // 
            // HeightSocketPlatformTextBox
            // 
            this.HeightSocketPlatformTextBox.Location = new System.Drawing.Point(214, 99);
            this.HeightSocketPlatformTextBox.Name = "HeightSocketPlatformTextBox";
            this.HeightSocketPlatformTextBox.Size = new System.Drawing.Size(47, 20);
            this.HeightSocketPlatformTextBox.TabIndex = 14;
            this.HeightSocketPlatformTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAllowOnlyNumbers);
            this.HeightSocketPlatformTextBox.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // DiametrSocketPlatformTextBox
            // 
            this.DiametrSocketPlatformTextBox.Location = new System.Drawing.Point(141, 99);
            this.DiametrSocketPlatformTextBox.Name = "DiametrSocketPlatformTextBox";
            this.DiametrSocketPlatformTextBox.Size = new System.Drawing.Size(45, 20);
            this.DiametrSocketPlatformTextBox.TabIndex = 13;
            this.DiametrSocketPlatformTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAllowOnlyNumbers);
            this.DiametrSocketPlatformTextBox.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(192, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "H";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(120, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "D";
            // 
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(111, 126);
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
            this.SizeLabel.Location = new System.Drawing.Point(15, 9);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(27, 13);
            this.SizeLabel.TabIndex = 16;
            this.SizeLabel.Text = "Size";
            // 
            // SizeComboBox
            // 
            this.SizeComboBox.FormattingEnabled = true;
            this.SizeComboBox.Location = new System.Drawing.Point(123, 5);
            this.SizeComboBox.Name = "SizeComboBox";
            this.SizeComboBox.Size = new System.Drawing.Size(138, 21);
            this.SizeComboBox.TabIndex = 17;
            this.SizeComboBox.SelectedIndexChanged += new System.EventHandler(this.SizeComboBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 161);
            this.Controls.Add(this.SizeComboBox);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.BuildButton);
            this.Controls.Add(this.HeightSocketPlatformTextBox);
            this.Controls.Add(this.DiametrSocketPlatformTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SocketPlatformLabel);
            this.Controls.Add(this.HeightTubeTextBox);
            this.Controls.Add(this.DiametrTubeTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LampTubeLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HeightBodyTextBox);
            this.Controls.Add(this.DiametrBodyTextBox);
            this.Controls.Add(this.LampBodyLabel);
            this.MaximumSize = new System.Drawing.Size(310, 200);
            this.MinimumSize = new System.Drawing.Size(310, 200);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LampTubeLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DiametrTubeTextBox;
        private System.Windows.Forms.TextBox HeightTubeTextBox;
        private System.Windows.Forms.Label SocketPlatformLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox HeightSocketPlatformTextBox;
        private System.Windows.Forms.TextBox DiametrSocketPlatformTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.ComboBox SizeComboBox;
    }
}

