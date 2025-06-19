using System.Threading.Tasks.Sources;
using Bee.Api.Core;
using Bee.Base;
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
        /// �]�m�s�u�覡�A�s�u�]�w�ɨϥΡC
        /// </summary>
        /// <param name="connectType">�A�ȳs�u�覡�C</param>
        /// <param name="endpoint">�A�ݺ��I�A���ݳs�u�����}�A��ݳs�u�����a���|�C</param>
        private void SetConnectType(EConnectType connectType, string endpoint)
        {
            if (connectType == EConnectType.Local)
            {
                // �]�w��ݳs�u�����ݩ�
                FrontendInfo.ConnectType = EConnectType.Local;
                FrontendInfo.Endpoint = string.Empty;
                BackendInfo.DefinePath = endpoint;
            }
            else
            {
                // �]�w���ݳs�u�����ݩ�
                FrontendInfo.ConnectType = EConnectType.Remote;
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
            var validator = new TApiConnectValidator();
            var connectType = validator.Validate(endpoint);

            // �]�m�s�u�覡
            SetConnectType(connectType, endpoint);

            // �t�μh�� API �A�ȳs����
            TSystemConnector connector;
            if (connectType == EConnectType.Local)
                connector = new TSystemConnector(Guid.Empty);  // �s�ݳs�u
            else
                connector = new TSystemConnector(endpoint, Guid.Empty);

            // ����t�μh�ŷ~���޿誫�� Ping ��k
            var args = new TPingArgs();
            var result = connector.Execute<TPingResult>(SystemActions.Ping, args, false);
            if (result.Status == "ok")
            {
                MessageBox.Show($"Version : {result.Version} \nServer Time : {result.ServerTime}");
            }
            else
            {
                MessageBox.Show("Ping ��k���楢��");
            }
        }

        /// <summary>
        /// �z�L TFormConnector ���� Hello ��k�C
        /// </summary>
        private void btnConnector_Hello_Click(object sender, EventArgs e)
        {
            // �P�_�A�Ⱥ��I��m�����a���|�κ��}�A�Ǧ^�������s�u�覡
            string endpoint = edtEndpoint.Text;
            var validator = new TApiConnectValidator();
            var connectType = validator.Validate(endpoint);

            // �]�m�s�u�覡
            SetConnectType(connectType, endpoint);

            // �{���N�X Employee ������ TEmployeeBusinessObject �~���޿誫��
            string progId = "Employee";
            // ���h�� API �A�ȳs����
            TFormConnector connector;            
            if (connectType == EConnectType.Local)
                connector = new TFormConnector(Guid.Empty, progId);  // �s�ݳs�u
            else
                connector = new TFormConnector(endpoint, Guid.Empty, progId);

            // ������h�ŷ~���޿誫�� Hello ��k�A�Y�� TEmployeeBusinessObject.Hello ��k
            var args = new THelloArgs() { UserName = "Jeff" }; 
            var result = connector.Execute<THelloResult>("Hello", args);
            MessageBox.Show($"Message : {result.Message}");
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            // �Τ�ݪ�l�ơA�����I�s Ping ��k���Ҧ��A�ݬO�_�ॿ�`�s�u           
            // �Ĥ@���|��ܳs�u�]�w�����A�]�m������|�N Endpoint �x�s������ɸ��|�U�� Client.Settings.xml
            // �Y�G���|�� Client.Settings.xml ���o Endpoint�A�i���l��
            // �Y�n���s�]�w�s�u�A�ЩI�s ShowConnect ��k
            if (ClientInfo.Initialize(new TUIViewService(), ESupportedConnectTypes.Both, true))
            {
                // �Y����ݿ�u�A�ݦb�Τ�ݼ������A�ݪ���l��
                if (FrontendInfo.ConnectType == EConnectType.Local)
                {
                    // �t�γ]�w��l��
                    var settings = ClientInfo.DefineAccess.GetSystemSettings();
                    settings.Initialize();
                    // ��l�� API �A�ȿﶵ�A�]�w�ǦC�ƾ��B���Y���P�[�K������@
                    ApiServiceOptions.Initialize(settings.CommonConfiguration.ApiPayloadOptions);
                    // ��ܪ�ݳs�u�]�w�� DefinePath ���|
                    MessageBox.Show($"ConnectType : {FrontendInfo.ConnectType}\nDefinePath : {BackendInfo.DefinePath}");
                }
                else
                {
                    // ��ܻ��ݺݳs�u�]�w�� Endpoint
                    MessageBox.Show($"ConnectType : {FrontendInfo.ConnectType}\nEndpoint : {FrontendInfo.Endpoint}");
                }
            }
            else
            {
                MessageBox.Show("��l�ƥ���");
            }
        }

        /// <summary>
        /// ��ܳs�u�]�w�����A���s�]�w�s�u���A�Ⱥ��I�C
        /// </summary>
        private void btnShowConnect_Click(object sender, EventArgs e)
        {
            if (ClientInfo.UIViewService == null)
            {
                MessageBox.Show("�Х����� Initialize ��k");
                return;
            }
            ClientInfo.UIViewService.ShowConnect();
        }

        private void btnHello_Click(object sender, EventArgs e)
        {
            var connecotr = ClientInfo.CreateFormConnector("Employee");
            var args = new THelloArgs()
            {
                UserName = "Jeff"
            };
            var result = connecotr.Execute<THelloResult>("Hello", args);
            MessageBox.Show($"Message : {result.Message}");
        }



    }
}
