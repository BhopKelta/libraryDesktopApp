using System.Windows.Forms;

namespace library.UI
{
    partial class Form2
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
            this.textBoxBook2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAuthor2 = new System.Windows.Forms.TextBox();
            this.comboBoxGenre2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPublisher2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDate2 = new System.Windows.Forms.TextBox();
            this.buttonUpdate2 = new System.Windows.Forms.Button();
            this.textBoxId2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Book name";
            // 
            // textBoxBook2
            // 
            this.textBoxBook2.Location = new System.Drawing.Point(190, 86);
            this.textBoxBook2.Name = "textBoxBook2";
            this.textBoxBook2.Size = new System.Drawing.Size(100, 20);
            this.textBoxBook2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Author";
            // 
            // textBoxAuthor2
            // 
            this.textBoxAuthor2.Location = new System.Drawing.Point(190, 129);
            this.textBoxAuthor2.Name = "textBoxAuthor2";
            this.textBoxAuthor2.Size = new System.Drawing.Size(100, 20);
            this.textBoxAuthor2.TabIndex = 3;
            // 
            // comboBoxGenre2
            // 
            this.comboBoxGenre2.FormattingEnabled = true;
            this.comboBoxGenre2.Location = new System.Drawing.Point(190, 173);
            this.comboBoxGenre2.Name = "comboBoxGenre2";
            this.comboBoxGenre2.Size = new System.Drawing.Size(100, 21);
            this.comboBoxGenre2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Genre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(126, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Publisher";
            // 
            // textBoxPublisher2
            // 
            this.textBoxPublisher2.Location = new System.Drawing.Point(190, 223);
            this.textBoxPublisher2.Name = "textBoxPublisher2";
            this.textBoxPublisher2.Size = new System.Drawing.Size(100, 20);
            this.textBoxPublisher2.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(106, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Release date";
            // 
            // textBoxDate2
            // 
            this.textBoxDate2.Location = new System.Drawing.Point(190, 271);
            this.textBoxDate2.Name = "textBoxDate2";
            this.textBoxDate2.Size = new System.Drawing.Size(100, 20);
            this.textBoxDate2.TabIndex = 9;
            // 
            // buttonUpdate2
            // 
            this.buttonUpdate2.Location = new System.Drawing.Point(199, 309);
            this.buttonUpdate2.Name = "buttonUpdate2";
            this.buttonUpdate2.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate2.TabIndex = 10;
            this.buttonUpdate2.Text = "Update";
            this.buttonUpdate2.UseVisualStyleBackColor = true;
            this.buttonUpdate2.Click += new System.EventHandler(this.buttonUpdate2_Click);
            // 
            // textBoxId2
            // 
            this.textBoxId2.Location = new System.Drawing.Point(343, 181);
            this.textBoxId2.Name = "textBoxId2";
            this.textBoxId2.Size = new System.Drawing.Size(100, 20);
            this.textBoxId2.TabIndex = 11;
            this.textBoxId2.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 450);
            this.Controls.Add(this.textBoxId2);
            this.Controls.Add(this.buttonUpdate2);
            this.Controls.Add(this.textBoxDate2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxPublisher2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxGenre2);
            this.Controls.Add(this.textBoxAuthor2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxBook2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "UpdateForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxBook2;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxAuthor2;
        public System.Windows.Forms.ComboBox comboBoxGenre2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBoxPublisher2;
        public System.Windows.Forms.Label label5;
        public TextBox textBoxDate2;
        public System.Windows.Forms.Button buttonUpdate2;
        public TextBox textBoxId2;
    }
}