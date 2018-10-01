namespace BotM
{
    partial class FormSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.checkBoxCloseOnRun = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMlc = new System.Windows.Forms.TextBox();
            this.textBoxGamePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Launch Command:";
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.AcceptsTab = true;
            this.textBoxCommand.Location = new System.Drawing.Point(12, 25);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(605, 20);
            this.textBoxCommand.TabIndex = 1;
            this.textBoxCommand.Text = "G:\\cemu_1.13.0\\Cemu.exe -g \"G:\\cemu_1.13.0\\games\\The Legend of Zelda Breath of th" +
    "e Wild\\code\\U-King.rpx\"";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(542, 177);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(461, 177);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // checkBoxCloseOnRun
            // 
            this.checkBoxCloseOnRun.AutoSize = true;
            this.checkBoxCloseOnRun.Location = new System.Drawing.Point(12, 180);
            this.checkBoxCloseOnRun.Name = "checkBoxCloseOnRun";
            this.checkBoxCloseOnRun.Size = new System.Drawing.Size(187, 17);
            this.checkBoxCloseOnRun.TabIndex = 3;
            this.checkBoxCloseOnRun.Text = "Close BotM when launching game";
            this.checkBoxCloseOnRun.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(435, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Update Data Path:       Typically looks like C:\\Cemu\\mlc01\\usr\\title\\00050000\\101" +
    "C9400\\";
            // 
            // textBoxMlc
            // 
            this.textBoxMlc.Location = new System.Drawing.Point(12, 78);
            this.textBoxMlc.Name = "textBoxMlc";
            this.textBoxMlc.Size = new System.Drawing.Size(605, 20);
            this.textBoxMlc.TabIndex = 2;
            this.textBoxMlc.Text = "G:\\cemu_1.13.0\\mlc01";
            // 
            // textBoxGamePath
            // 
            this.textBoxGamePath.Location = new System.Drawing.Point(12, 136);
            this.textBoxGamePath.Name = "textBoxGamePath";
            this.textBoxGamePath.Size = new System.Drawing.Size(605, 20);
            this.textBoxGamePath.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(321, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Game Data Path:        Typically looks like C:\\Cemu\\Games\\BotW\\";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 212);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxGamePath);
            this.Controls.Add(this.textBoxMlc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxCloseOnRun);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxCommand);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxCommand;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        public System.Windows.Forms.CheckBox checkBoxCloseOnRun;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxMlc;
        private System.Windows.Forms.TextBox textBoxGamePath;
        private System.Windows.Forms.Label label3;
    }
}