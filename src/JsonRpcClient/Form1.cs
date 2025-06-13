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
            // 用戶端初始化
            if (!ClientInfo.Initialize(new TUIViewService(), ESupportedConnectTypes.Both, true))
            {
                MessageBox.Show("初始化成功");
            }
            else
            {
                MessageBox.Show("初始化失敗");
            }
        }
    }
}
