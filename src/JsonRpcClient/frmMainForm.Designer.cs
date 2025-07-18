namespace JsonRpcClient
{
    partial class frmMainForm
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
            btnInitialize.Location = new Point(26, 60);
            btnInitialize.Margin = new Padding(4);
            btnInitialize.Name = "btnInitialize";
            btnInitialize.Size = new Size(129, 29);
            btnInitialize.TabIndex = 0;
            btnInitialize.Text = "Initialize";
            btnInitialize.UseVisualStyleBackColor = true;
            btnInitialize.Click += this.btnInitialize_Click;
            // 
            // btnConnector_Ping
            // 
            btnConnector_Ping.Location = new Point(26, 101);
            btnConnector_Ping.Margin = new Padding(4);
            btnConnector_Ping.Name = "btnConnector_Ping";
            btnConnector_Ping.Size = new Size(129, 29);
            btnConnector_Ping.TabIndex = 1;
            btnConnector_Ping.Text = "Ping";
            btnConnector_Ping.UseVisualStyleBackColor = true;
            btnConnector_Ping.Click += this.btnConnector_Ping_Click;
            // 
            // btnShowConnect
            // 
            btnShowConnect.Location = new Point(172, 60);
            btnShowConnect.Margin = new Padding(4);
            btnShowConnect.Name = "btnShowConnect";
            btnShowConnect.Size = new Size(129, 29);
            btnShowConnect.TabIndex = 2;
            btnShowConnect.Text = "ShowConnect";
            btnShowConnect.UseVisualStyleBackColor = true;
            btnShowConnect.Click += this.btnShowConnect_Click;
            // 
            // btnHello
            // 
            btnHello.Location = new Point(321, 60);
            btnHello.Margin = new Padding(4);
            btnHello.Name = "btnHello";
            btnHello.Size = new Size(129, 29);
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
            groupBox1.Location = new Point(15, 15);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(499, 153);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Using Bee.Connect Package";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(109, 65);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(309, 19);
            label2.TabIndex = 5;
            label2.Text = "Note: Enter DefinePath for local connection.";
            // 
            // btnConnector_Hello
            // 
            btnConnector_Hello.Location = new Point(172, 101);
            btnConnector_Hello.Margin = new Padding(4);
            btnConnector_Hello.Name = "btnConnector_Hello";
            btnConnector_Hello.Size = new Size(129, 29);
            btnConnector_Hello.TabIndex = 4;
            btnConnector_Hello.Text = "Hello";
            btnConnector_Hello.UseVisualStyleBackColor = true;
            btnConnector_Hello.Click += this.btnConnector_Hello_Click;
            // 
            // edtEndpoint
            // 
            edtEndpoint.Location = new Point(109, 32);
            edtEndpoint.Margin = new Padding(4);
            edtEndpoint.Name = "edtEndpoint";
            edtEndpoint.Size = new Size(326, 27);
            edtEndpoint.TabIndex = 3;
            edtEndpoint.Text = "http://localhost:5000/api";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 35);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(72, 19);
            label1.TabIndex = 2;
            label1.Text = "Endpoint";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnHello);
            groupBox2.Controls.Add(btnInitialize);
            groupBox2.Controls.Add(btnShowConnect);
            groupBox2.Location = new Point(15, 196);
            groupBox2.Margin = new Padding(4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4);
            groupBox2.Size = new Size(499, 146);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Using Bee.UI.WinForms Package";
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(879, 476);
            this.Controls.Add(groupBox2);
            this.Controls.Add(groupBox1);
            this.Margin = new Padding(4);
            this.Name = "frmMainForm";
            this.Text = "JSON-RPC Client";
            this.Load += this.frmMainForm_Load;
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
