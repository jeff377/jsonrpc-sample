using Bee.Api.Core;
using Bee.Base;
using Bee.Connect;
using Bee.Define;
using Bee.UI.Core;
using Bee.UI.WinForms;
using Custom.Define;

namespace JsonRpcClient
{
    /// <summary>
    /// Main form for the JSON-RPC client application.
    /// </summary>
    public partial class frmMainForm : Form, ILogDisplayForm
    {
        public frmMainForm()
        {
            InitializeComponent();
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            SysInfo.LogWriter = new FormLogWriter(this);
        }

        /// <summary>
        /// display a log entry in the form.
        /// </summary>
        public void AppendLog(LogEntry entry)
        {
            string message = $"{entry.Timestamp:yyyy-MM-dd HH:mm:ss} [{entry.EntryType}] {entry.Message}";
            edtLog.AppendText(message + Environment.NewLine);
        }

        /// <summary>
        /// �]�m�s�u�覡�A�s�u�]�w�ɨϥΡC
        /// </summary>
        /// <param name="connectType">�A�ȳs�u�覡�C</param>
        /// <param name="endpoint">�A�ݺ��I�A���ݳs�u�����}�A��ݳs�u�����a���|�C</param>
        private void SetConnectType(ConnectType connectType, string endpoint)
        {
            if (connectType == ConnectType.Local)
            {
                // �]�w��ݳs�u�����ݩ�
                FrontendInfo.ConnectType = ConnectType.Local;
                FrontendInfo.Endpoint = string.Empty;
                BackendInfo.DefinePath = endpoint;
            }
            else
            {
                // �]�w���ݳs�u�����ݩ�
                FrontendInfo.ConnectType = ConnectType.Remote;
                FrontendInfo.Endpoint = endpoint;
                BackendInfo.DefinePath = string.Empty;
            }
        }

        /// <summary>
        /// �z�L TSystemConnector ���� Ping ��k�C
        /// </summary>
        private void btnConnector_Ping_Click(object sender, EventArgs e)
        {
            // �P�_�A�Ⱥ��I��m�����a���|�κ��}�A�Ǧ^�������s�u�覡
            string endpoint = edtEndpoint.Text;
            var validator = new ApiConnectValidator();
            var connectType = validator.Validate(endpoint);

            // �]�m�s�u�覡
            SetConnectType(connectType, endpoint);

            // �Y����ݳs�u�A�ݦb�Τ�ݼ������A�ݪ���l��
            if (connectType == ConnectType.Local)
            {
                // �t�γ]�w��l��
                var settings = ClientInfo.DefineAccess.GetSystemSettings();
                settings.Initialize();
                // ��l�� API �A�ȿﶵ�A�]�w�ǦC�ƾ��B���Y���P�[�K������@
                ApiServiceOptions.Initialize(settings.CommonConfiguration.ApiPayloadOptions);
                // �]�w�e�� API ���_
                FrontendInfo.ApiEncryptionKey = BackendInfo.ApiEncryptionKey;
            }

            // �t�μh�� API �A�ȳs����
            SystemApiConnector connector;
            if (connectType == ConnectType.Local)
                connector = new SystemApiConnector(Guid.Empty);  // �s�ݳs�u
            else
                connector = new SystemApiConnector(endpoint, Guid.Empty);


            // ����t�μh�ŷ~���޿誫�� Ping ��k
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
        /// �z�L TFormConnector ���� Hello ��k�C
        /// </summary>
        private void btnConnector_Hello_Click(object sender, EventArgs e)
        {
            // �P�_�A�Ⱥ��I��m�����a���|�κ��}�A�Ǧ^�������s�u�覡
            string endpoint = edtEndpoint.Text;
            var validator = new ApiConnectValidator();
            var connectType = validator.Validate(endpoint);

            // �]�m�s�u�覡
            SetConnectType(connectType, endpoint);

            // �{���N�X Employee ������ TEmployeeBusinessObject �~���޿誫��
            string progId = "Employee";
            Guid accessToken = Guid.NewGuid();
            // ���h�� API �A�ȳs����
            FormApiConnector connector;
            if (connectType == ConnectType.Local)
                connector = new FormApiConnector(accessToken, progId);  // �s�ݳs�u
            else
                connector = new FormApiConnector(endpoint, accessToken, progId);

            // ������h�ŷ~���޿誫�� Hello ��k�A�Y�� TEmployeeBusinessObject.Hello ��k
            var args = new HelloArgs() { UserName = "Jeff" };
            var result = connector.Execute<HelloResult>("Hello", args);
            MessageBox.Show($"Message: {result.Message}");
        }

        /// <summary>
        /// �Τ�ݪ�l�ơC
        /// </summary>
        private void btnInitialize_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// ��ܳs�u�]�w�����A���s�]�w�s�u���A�Ⱥ��I�C
        /// </summary>
        private void btnShowConnect_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// �z�L ClientInfo �إ� FormConnector�A ���� Hello ��k�C
        /// </summary>
        private void btnHello_Click(object sender, EventArgs e)
        {

        }


    }
}
