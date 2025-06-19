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
            btnConnector_Ping = new Button();
            btnShowConnect = new Button();
            btnHello = new Button();
            groupBox1 = new GroupBox();
            label2 = new Label();
            btnConnector_Hello = new Button();
            edtEndpoint = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInitialize
            // 
            btnInitialize.Location = new Point(20, 47);
            btnInitialize.Name = "btnInitialize";
            btnInitialize.Size = new Size(100, 23);
            btnInitialize.TabIndex = 0;
            btnInitialize.Text = "Initialize";
            btnInitialize.UseVisualStyleBackColor = true;
            btnInitialize.Click += this.btnInitialize_Click;
            // 
            // btnConnector_Ping
            // 
            btnConnector_Ping.Location = new Point(20, 80);
            btnConnector_Ping.Name = "btnConnector_Ping";
            btnConnector_Ping.Size = new Size(100, 23);
            btnConnector_Ping.TabIndex = 1;
            btnConnector_Ping.Text = "Ping";
            btnConnector_Ping.UseVisualStyleBackColor = true;
            btnConnector_Ping.Click += this.btnConnector_Ping_Click;
            // 
            // btnShowConnect
            // 
            btnShowConnect.Location = new Point(134, 47);
            btnShowConnect.Name = "btnShowConnect";
            btnShowConnect.Size = new Size(100, 23);
            btnShowConnect.TabIndex = 2;
            btnShowConnect.Text = "ShowConnect";
            btnShowConnect.UseVisualStyleBackColor = true;
            btnShowConnect.Click += this.btnShowConnect_Click;
            // 
            // btnHello
            // 
            btnHello.Location = new Point(250, 47);
            btnHello.Name = "btnHello";
            btnHello.Size = new Size(100, 23);
            btnHello.TabIndex = 3;
            btnHello.Text = "Hello";
            btnHello.UseVisualStyleBackColor = true;
            btnHello.Click += this.btnHello_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnConnector_Hello);
            groupBox1.Controls.Add(edtEndpoint);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnConnector_Ping);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(497, 121);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "使用 Bee.Connect 套件";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(85, 51);
            label2.Name = "label2";
            label2.Size = new Size(283, 15);
            label2.TabIndex = 5;
            label2.Text = "備註 : Endpoint 輸入 DefinePath 路徑即為近端連線";
            // 
            // btnConnector_Hello
            // 
            btnConnector_Hello.Location = new Point(134, 80);
            btnConnector_Hello.Name = "btnConnector_Hello";
            btnConnector_Hello.Size = new Size(100, 23);
            btnConnector_Hello.TabIndex = 4;
            btnConnector_Hello.Text = "Hello";
            btnConnector_Hello.UseVisualStyleBackColor = true;
            btnConnector_Hello.Click += this.btnConnector_Hello_Click;
            // 
            // edtEndpoint
            // 
            edtEndpoint.Location = new Point(85, 25);
            edtEndpoint.Name = "edtEndpoint";
            edtEndpoint.Size = new Size(391, 23);
            edtEndpoint.TabIndex = 3;
            edtEndpoint.Text = "http://localhost:5000/api";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 28);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 2;
            label1.Text = "Endpoint";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnHello);
            groupBox2.Controls.Add(btnInitialize);
            groupBox2.Controls.Add(btnShowConnect);
            groupBox2.Location = new Point(12, 155);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(497, 115);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "使用 Bee.UI.WinForms 套件";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(523, 279);
            this.Controls.Add(groupBox2);
            this.Controls.Add(groupBox1);
            this.Name = "Form1";
            this.Text = "JSON-RPC Client";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Button btnInitialize;
        private Button btnConnector_Ping;
        private Button btnShowConnect;
        private Button btnHello;
        private GroupBox groupBox1;
        private TextBox edtEndpoint;
        private Label label1;
        private GroupBox groupBox2;
        private Button btnConnector_Hello;
        private Label label2;
    }
}
