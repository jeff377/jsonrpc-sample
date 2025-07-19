using Bee.Api.Core;
using Bee.Base;
using Bee.Cache;
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

        /// <summary>
        /// Endpoint for the API service.
        /// </summary>
        private string Endpoint { get; set; } = string.Empty;

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            SysInfo.LogWriter = new FormLogWriter(this);
        }

        /// <summary>
        /// Display a log entry in the form.
        /// </summary>
        public void AppendLog(LogEntry entry)
        {
            string message = $"{entry.Timestamp:yyyy-MM-dd HH:mm:ss}\n{entry.Message}";
            edtLog.AppendText(message + Environment.NewLine);
        }

        /// <summary>
        /// Initialize the system settings and API service options.
        /// </summary>
        private void btnInitialize_Click(object sender, EventArgs e)
        {
            // �P�_�A�Ⱥ��I��m�����a���|�κ��}�A�Ǧ^�������s�u�覡
            string endpoint = edtEndpoint.Text;
            var validator = new ApiConnectValidator();
            var connectType = validator.Validate(endpoint);

            // �]�m�s�u�覡
            SetConnectType(connectType, endpoint);

            // ��l�� API �A�ȿﶵ�A�]�w�ǦC�ƾ��B���Y���P�[�K������@
            var connector = CreateSystemApiConnector();
            connector.ApiServiceOptionsInitialize();

            MessageBox.Show("�t�γ]�w��l�Ƨ����C");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // ���� RSA ��٪��_
            RsaCryptor.GenerateRsaKeyPair(out var publicKeyXml, out var privateKeyXml);

            var connector = CreateSystemApiConnector();
            var args = new LoginArgs()
            {
                UserId = "jeff",
                Password = "1234",
                ClientPublicKey = publicKeyXml
            };
            var result = connector.Execute<LoginResult>("Login", args, PayloadFormat.Encoded);
            // �Ψp�_�ѱK EncryptedSessionKey
            string sessionKey = RsaCryptor.DecryptWithPrivateKey(result.EncryptedSessionKey, privateKeyXml);
            FrontendInfo.ApiEncryptionKey = Convert.FromBase64String(sessionKey); ;
        }

        /// <summary>
        /// �]�m�s�u�覡�A�s�u�]�w�ɨϥΡC
        /// </summary>
        /// <param name="connectType">�A�ȳs�u�覡�C</param>
        /// <param name="endpoint">�A�ݺ��I�A���ݳs�u�����}�A��ݳs�u�����a���|�C</param>
        private void SetConnectType(ConnectType connectType, string endpoint)
        {
            Endpoint = endpoint;
            if (connectType == ConnectType.Local)
            {
                // �]�w��ݳs�u�����ݩ�
                FrontendInfo.ConnectType = ConnectType.Local;
                FrontendInfo.Endpoint = string.Empty;
                BackendInfo.DefinePath = endpoint;

                // �Y����ݳs�u�A�ݦb�Τ�ݼ������A�ݪ���l��
                var settings = CacheFunc.GetSystemSettings();
                settings.Initialize();
                // �]�w�e�� API ���_
                FrontendInfo.ApiEncryptionKey = BackendInfo.ApiEncryptionKey;
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
        /// �إߨt�μh�� API �A�ȳs�����C 
        /// </summary>
        private SystemApiConnector CreateSystemApiConnector()
        {
            if (FrontendInfo.ConnectType == ConnectType.Local)
                return new SystemApiConnector(Guid.Empty);  // �s�ݳs�u
            else
                return new SystemApiConnector(Endpoint, Guid.Empty);
        }

        /// <summary>
        /// �إߪ��h�� API �A�ȳs�����C
        /// </summary>
        /// <param name="progId">�{���N�X�C</param>
        private FormApiConnector CreateFormApiConnector(string progId)
        {
            Guid accessToken = Guid.NewGuid();
            if (FrontendInfo.ConnectType == ConnectType.Local)
                return new FormApiConnector(accessToken, progId);  // �s�ݳs�u
            else
                return new FormApiConnector(Endpoint, accessToken, progId);
        }

        private void btnHello_Click(object sender, EventArgs e)
        {
            // �إߪ��h�ųs����AProgId=Employee ������ TEmployeeBusinessObject �~���޿誫��
            var connector = CreateFormApiConnector("Employee");

            // ������h�ŷ~���޿誫�� Hello ��k�A�Y�� TEmployeeBusinessObject.Hello ��k
            var args = new HelloArgs() { UserName = "Jeff" };
            var result = connector.Execute<HelloResult>("Hello", args);
            MessageBox.Show($"Message: {result.Message}");
        }
    }
}
