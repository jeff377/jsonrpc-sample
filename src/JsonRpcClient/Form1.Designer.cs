namespace JsonRpcClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnInitialize = new Button();
            this.SuspendLayout();
            // 
            // btnInitialize
            // 
            btnInitialize.Location = new Point(279, 72);
            btnInitialize.Name = "btnInitialize";
            btnInitialize.Size = new Size(75, 23);
            btnInitialize.TabIndex = 0;
            btnInitialize.Text = "Initialize";
            btnInitialize.UseVisualStyleBackColor = true;
            btnInitialize.Click += this.btnInitialize_Click;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(442, 309);
            this.Controls.Add(btnInitialize);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        #endregion

        private Button btnInitialize;
    }
}
