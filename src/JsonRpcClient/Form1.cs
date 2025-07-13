using Bee.Api.Core;
using Bee.Connect;
using Bee.Define;
using Bee.UI.Core;
using Bee.UI.WinForms;
using Custom.Define;

namespace JsonRpcClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 設置連線方式，連線設定時使用。
        /// </summary>
        /// <param name="connectType">服務連線方式。</param>
        /// <param name="endpoint">服端端點，遠端連線為網址，近端連線為本地路徑。</param>
        private void SetConnectType(ConnectType connectType, string endpoint)
        {
            if (connectType == ConnectType.Local)
            {
                // 設定近端連線相關屬性
                FrontendInfo.ConnectType = ConnectType.Local;
                FrontendInfo.Endpoint = string.Empty;
                BackendInfo.DefinePath = endpoint;
            }
            else
            {
                // 設定遠端連線相關屬性
                FrontendInfo.ConnectType = ConnectType.Remote;
                FrontendInfo.Endpoint = endpoint;
                BackendInfo.DefinePath = string.Empty;
            }
        }

        /// <summary>
        /// 透過 TSystemConnector 執行 Ping 方法。
        /// </summary>
        private void btnConnector_Ping_Click(object sender, EventArgs e)
        {
            // 判斷服務端點位置為本地路徑或網址，傳回對應的連線方式
            string endpoint = edtEndpoint.Text;
            var validator = new ApiConnectValidator();
            var connectType = validator.Validate(endpoint);

            // 設置連線方式
            SetConnectType(connectType, endpoint);

            // 系統層級 API 服務連接器
            SystemApiConnector connector;
            if (connectType == ConnectType.Local)
                connector = new SystemApiConnector(Guid.Empty);  // 連端連線
            else
                connector = new SystemApiConnector(endpoint, Guid.Empty);

            // 執行系統層級業務邏輯物件的 Ping 方法
            var args = new PingArgs();
            var result = connector.Execute<PingResult>(SystemActions.Ping, args, false);
            if (result.Status == "ok")
            {
                MessageBox.Show($"Ping method executed successfully.\nVersion: {result.Version}\nServer Time: {result.ServerTime}");
            }
            else
            {
                MessageBox.Show("Ping method execution failed.");
            }
        }

        /// <summary>
        /// 透過 TFormConnector 執行 Hello 方法。
        /// </summary>
        private void btnConnector_Hello_Click(object sender, EventArgs e)
        {
            // 判斷服務端點位置為本地路徑或網址，傳回對應的連線方式
            string endpoint = edtEndpoint.Text;
            var validator = new ApiConnectValidator();
            var connectType = validator.Validate(endpoint);

            // 設置連線方式
            SetConnectType(connectType, endpoint);

            // 程式代碼 Employee 對應至 TEmployeeBusinessObject 業務邏輯物件
            string progId = "Employee";
            // 表單層級 API 服務連接器
            FormApiConnector connector;            
            if (connectType == ConnectType.Local)
                connector = new FormApiConnector(Guid.Empty, progId);  // 連端連線
            else
                connector = new FormApiConnector(endpoint, Guid.Empty, progId);

            // 執行表單層級業務邏輯物件的 Hello 方法，即為 TEmployeeBusinessObject.Hello 方法
            var args = new HelloArgs() { UserName = "Jeff" }; 
            var result = connector.Execute<HelloResult>("Hello", args);
            MessageBox.Show($"Message: {result.Message}");
        }

        /// <summary>
        /// 用戶端初始化。
        /// </summary>
        private void btnInitialize_Click(object sender, EventArgs e)
        {
            // 用戶端初始化，內部呼叫 Ping 方法驗證伺服端是否能正常連線           
            // 第一次會顯示連線設定介面，設置完成後會將 Endpoint 儲存於執行檔路徑下的 Client.Settings.xml
            // 若二次會由 Client.Settings.xml 取得 Endpoint，進行初始化
            // 若要重新設定連線，請呼叫 ShowConnect 方法
            if (ClientInfo.Initialize(new UIViewService(), SupportedConnectTypes.Both))
            {
                // 若為近端遲線，需在用戶端模擬伺服端的初始化
                if (FrontendInfo.ConnectType == ConnectType.Local)
                {
                    // 系統設定初始化
                    var settings = ClientInfo.DefineAccess.GetSystemSettings();
                    settings.Initialize();
                    // 初始化 API 服務選項，設定序列化器、壓縮器與加密器的實作
                    ApiServiceOptions.Initialize(settings.CommonConfiguration.ApiPayloadOptions);
                    // 顯示近端連線設定的 DefinePath 路徑
                    MessageBox.Show($"ConnectType: {FrontendInfo.ConnectType}\nDefinePath: {BackendInfo.DefinePath}");
                }
                else
                {
                    // 顯示遠端端連線設定的 Endpoint
                    MessageBox.Show($"ConnectType: {FrontendInfo.ConnectType}\nEndpoint: {FrontendInfo.Endpoint}");
                }
            }
            else
            {
                MessageBox.Show("Initialization failed.");
            }
        }

        /// <summary>
        /// 顯示連線設定介面，重新設定連線的服務端點。
        /// </summary>
        private void btnShowConnect_Click(object sender, EventArgs e)
        {
            if (ClientInfo.UIViewService == null)
            {
                MessageBox.Show("Please execute the Initialize method first.");
                return;
            }
            ClientInfo.UIViewService.ShowApiConnect();
        }

        /// <summary>
        /// 透過 ClientInfo 建立 FormConnector， 執行 Hello 方法。
        /// </summary>
        private void btnHello_Click(object sender, EventArgs e)
        {
            var connector = ClientInfo.CreateFormApiConnector("Employee");
            var args = new HelloArgs()
            {
                UserName = "Jeff"
            };
            var result = connector.Execute<HelloResult>("Hello", args);
            MessageBox.Show($"Message: {result.Message}");
        }



    }
}
