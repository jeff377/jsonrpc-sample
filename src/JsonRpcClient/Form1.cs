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
            if (!ClientInfo.Initialize(new TUIViewService(), ESupportedConnectTypes.Both, true))
            {
                MessageBox.Show("��l�Ʀ��\");
            }
            else
            {
                MessageBox.Show("��l�ƥ���");
            }
        }
    }
}
