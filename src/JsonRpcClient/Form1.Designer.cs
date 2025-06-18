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
            btnPing = new Button();
            btnShowConnect = new Button();
            btnHello = new Button();
            this.SuspendLayout();
            // 
            // btnInitialize
            // 
            btnInitialize.Location = new Point(81, 114);
            btnInitialize.Name = "btnInitialize";
            btnInitialize.Size = new Size(75, 23);
            btnInitialize.TabIndex = 0;
            btnInitialize.Text = "Initialize";
            btnInitialize.UseVisualStyleBackColor = true;
            btnInitialize.Click += this.btnInitialize_Click;
            // 
            // btnPing
            // 
            btnPing.Location = new Point(127, 32);
            btnPing.Name = "btnPing";
            btnPing.Size = new Size(75, 23);
            btnPing.TabIndex = 1;
            btnPing.Text = "Ping";
            btnPing.UseVisualStyleBackColor = true;
            btnPing.Click += this.btnPing_Click;
            // 
            // btnShowConnect
            // 
            btnShowConnect.Location = new Point(186, 123);
            btnShowConnect.Name = "btnShowConnect";
            btnShowConnect.Size = new Size(128, 23);
            btnShowConnect.TabIndex = 2;
            btnShowConnect.Text = "ShowConnect";
            btnShowConnect.UseVisualStyleBackColor = true;
            btnShowConnect.Click += this.btnShowConnect_Click;
            // 
            // btnHello
            // 
            btnHello.Location = new Point(332, 123);
            btnHello.Name = "btnHello";
            btnHello.Size = new Size(105, 23);
            btnHello.TabIndex = 3;
            btnHello.Text = "Hello";
            btnHello.UseVisualStyleBackColor = true;
            btnHello.Click += this.btnHello_Click;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(690, 420);
            this.Controls.Add(btnHello);
            this.Controls.Add(btnShowConnect);
            this.Controls.Add(btnPing);
            this.Controls.Add(btnInitialize);
            this.Name = "Form1";
            this.Text = "JSON-RPC Client";
            this.ResumeLayout(false);
        }

        #endregion

        private Button btnInitialize;
        private Button btnPing;
        private Button btnShowConnect;
        private Button btnHello;
    }
}
