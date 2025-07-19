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
            btnConnector_Ping = new Button();
            label2 = new Label();
            btnConnector_Hello = new Button();
            edtEndpoint = new TextBox();
            label1 = new Label();
            edtLog = new TextBox();
            this.SuspendLayout();
            // 
            // btnConnector_Ping
            // 
            btnConnector_Ping.Location = new Point(15, 89);
            btnConnector_Ping.Margin = new Padding(4, 4, 4, 4);
            btnConnector_Ping.Name = "btnConnector_Ping";
            btnConnector_Ping.Size = new Size(129, 29);
            btnConnector_Ping.TabIndex = 1;
            btnConnector_Ping.Text = "Ping";
            btnConnector_Ping.UseVisualStyleBackColor = true;
            btnConnector_Ping.Click += this.btnConnector_Ping_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(99, 41);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(309, 19);
            label2.TabIndex = 5;
            label2.Text = "Note: Enter DefinePath for local connection.";
            // 
            // btnConnector_Hello
            // 
            btnConnector_Hello.Location = new Point(15, 125);
            btnConnector_Hello.Margin = new Padding(4, 4, 4, 4);
            btnConnector_Hello.Name = "btnConnector_Hello";
            btnConnector_Hello.Size = new Size(129, 29);
            btnConnector_Hello.TabIndex = 4;
            btnConnector_Hello.Text = "Hello";
            btnConnector_Hello.UseVisualStyleBackColor = true;
            btnConnector_Hello.Click += this.btnConnector_Hello_Click;
            // 
            // edtEndpoint
            // 
            edtEndpoint.Location = new Point(99, 8);
            edtEndpoint.Margin = new Padding(4, 4, 4, 4);
            edtEndpoint.Name = "edtEndpoint";
            edtEndpoint.Size = new Size(325, 27);
            edtEndpoint.TabIndex = 3;
            edtEndpoint.Text = "https://localhost:7056/api";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 11);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(72, 19);
            label1.TabIndex = 2;
            label1.Text = "Endpoint";
            // 
            // edtLog
            // 
            edtLog.Location = new Point(451, 15);
            edtLog.Margin = new Padding(4, 4, 4, 4);
            edtLog.Multiline = true;
            edtLog.Name = "edtLog";
            edtLog.ScrollBars = ScrollBars.Both;
            edtLog.Size = new Size(607, 445);
            edtLog.TabIndex = 6;
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1075, 504);
            this.Controls.Add(edtLog);
            this.Controls.Add(btnConnector_Hello);
            this.Controls.Add(label2);
            this.Controls.Add(btnConnector_Ping);
            this.Controls.Add(label1);
            this.Controls.Add(edtEndpoint);
            this.Margin = new Padding(4, 4, 4, 4);
            this.Name = "frmMainForm";
            this.Text = "JSON-RPC Client";
            this.Load += this.frmMainForm_Load;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private Button btnConnector_Ping;
        private TextBox edtEndpoint;
        private Label label1;
        private Button btnConnector_Hello;
        private Label label2;
        private TextBox edtLog;
    }
}
