using Bee.Connect;
using Bee.Define;
using Bee.UI.Core;
using Bee.UI.WinForms;

namespace JsonRpcClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            // �Τ�ݪ�l��
            if (ClientInfo.Initialize(new TUIViewService(), ESupportedConnectTypes.Both, true))
            {
                MessageBox.Show("��l�Ʀ��\");
            }
            else
            {
                MessageBox.Show("��l�ƥ���");
            }
        }

        /// <summary>
        /// �ϥ� Connector ���� Ping ��k�C
        /// </summary>
        private void btnPing_Click(object sender, EventArgs e)
        {
            var connector = new TSystemConnector("http://localhost:5000/api", Guid.Empty);
            var args = new TPingArgs();
            var result = connector.Execute<TPingResult>(SystemActions.Ping, args, false);
            if (result.Status != "ok")
                MessageBox.Show("Ping ��k���榨�\");
            else
                MessageBox.Show("Ping ��k���榨�\");
        }

        /// <summary>
        /// ��ܳs�u�]�w�����A���s�]�w�s�u���A�Ⱥ��I�C
        /// </summary>
        private void btnShowConnect_Click(object sender, EventArgs e)
        {            
            ClientInfo.UIViewService.ShowConnect();
        }
    }
}
