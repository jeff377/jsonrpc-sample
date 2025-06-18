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
            // 用戶端初始化
            if (ClientInfo.Initialize(new TUIViewService(), ESupportedConnectTypes.Both, true))
            {
                MessageBox.Show("初始化成功");
            }
            else
            {
                MessageBox.Show("初始化失敗");
            }
        }

        /// <summary>
        /// 使用 Connector 執行 Ping 方法。
        /// </summary>
        private void btnPing_Click(object sender, EventArgs e)
        {
            var connector = new TSystemConnector("http://localhost:5000/api", Guid.Empty);
            var args = new TPingArgs();
            var result = connector.Execute<TPingResult>(SystemActions.Ping, args, false);
            if (result.Status != "ok")
                MessageBox.Show("Ping 方法執行成功");
            else
                MessageBox.Show("Ping 方法執行成功");
        }

        /// <summary>
        /// 顯示連線設定介面，重新設定連線的服務端點。
        /// </summary>
        private void btnShowConnect_Click(object sender, EventArgs e)
        {            
            ClientInfo.UIViewService.ShowConnect();
        }
    }
}
