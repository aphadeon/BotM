using System;

namespace BotM
{
    partial class FormMods
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMods));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxNotInstalled = new BotM.ListBoxMods();
            this.listBoxInstalled = new BotM.ListBoxMods();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBoxHelp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 477);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add From File...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(112, 477);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Open Mods Folder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(671, 477);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please be careful - actions here may not be simple to undo.";
            // 
            // listBoxNotInstalled
            // 
            this.listBoxNotInstalled.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxNotInstalled.FormattingEnabled = true;
            this.listBoxNotInstalled.IntegralHeight = false;
            this.listBoxNotInstalled.ItemHeight = 70;
            this.listBoxNotInstalled.Location = new System.Drawing.Point(15, 48);
            this.listBoxNotInstalled.Name = "listBoxNotInstalled";
            this.listBoxNotInstalled.Size = new System.Drawing.Size(216, 420);
            this.listBoxNotInstalled.TabIndex = 4;
            this.listBoxNotInstalled.Click += new System.EventHandler(this.OnModClick);
            // 
            // listBoxInstalled
            // 
            this.listBoxInstalled.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxInstalled.FormattingEnabled = true;
            this.listBoxInstalled.IntegralHeight = false;
            this.listBoxInstalled.ItemHeight = 70;
            this.listBoxInstalled.Location = new System.Drawing.Point(265, 48);
            this.listBoxInstalled.Name = "listBoxInstalled";
            this.listBoxInstalled.Size = new System.Drawing.Size(216, 420);
            this.listBoxInstalled.TabIndex = 5;
            this.listBoxInstalled.Click += new System.EventHandler(this.OnModClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Not Installed:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(262, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Installed:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(236, 214);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 36);
            this.button3.TabIndex = 8;
            this.button3.Text = "> >";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(236, 256);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(25, 36);
            this.button4.TabIndex = 9;
            this.button4.Text = "< <";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBoxHelp
            // 
            this.textBoxHelp.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxHelp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxHelp.Location = new System.Drawing.Point(502, 12);
            this.textBoxHelp.Multiline = true;
            this.textBoxHelp.Name = "textBoxHelp";
            this.textBoxHelp.ReadOnly = true;
            this.textBoxHelp.Size = new System.Drawing.Size(244, 456);
            this.textBoxHelp.TabIndex = 10;
            this.textBoxHelp.TabStop = false;
            // 
            // FormMods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 512);
            this.Controls.Add(this.textBoxHelp);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxInstalled);
            this.Controls.Add(this.listBoxNotInstalled);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMods";
            this.ShowInTaskbar = false;
            this.Text = "Mod Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label1;
        private ListBoxMods listBoxNotInstalled;
        private ListBoxMods listBoxInstalled;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBoxHelp;
    }
}