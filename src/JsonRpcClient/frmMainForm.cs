using System.Threading.Tasks;
using Bee.Api.Core;
using Bee.Base;
using Bee.Cache;
using Bee.Connect;
using Bee.Define;
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
        private string _endpoint = string.Empty;

        /// <summary>
        /// Indicates whether the object has been initialized.
        /// </summary>
        private bool _isInitialized = false;

        /// <summary>
        /// Load event handler for the main form.
        /// </summary>
        private void frmMainForm_Load(object sender, EventArgs e)
        {
            SysInfo.LogWriter = new FormLogWriter(this);
            SysInfo.LogOptions = new LogOptions()
            {
                ApiConnector = new ApiConnectorLogOptions(true, true)
            };
        }

        /// <summary>
        /// Display a log entry in the form.
        /// </summary>
        public void AppendLog(LogEntry entry)
        {
            string message = $"{entry.Timestamp:yyyy-MM-dd HH:mm:ss}\r\n{entry.Message}\r\n" +
                                            "-------------------------------------------------------------------------\r\n";
            edtLog.AppendText(message + Environment.NewLine);
        }

        /// <summary>
        /// Initialize the system settings and API service options.
        /// </summary>
        private async void btnInitialize_Click(object sender, EventArgs e)
        {
            edtLog.Text = string.Empty;
            if (!ValidateAndApplyEndpoint()) { return; }

            try
            {
                // Retrieve general parameters and environment settings, and initialize the system
                var connector = CreateSystemApiConnector();
                await connector.InitializeAsync();
                _isInitialized = true;
                MessageBox.Show("Initialization complete.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Login to the system.
        /// </summary>
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            edtLog.Text = string.Empty;
            if (!ValidateInitialize()) { return; }

            try
            {
                // Log in to the system; no real credential validation here, for demonstration purposes only
                var connector = CreateSystemApiConnector();
                await connector.LoginAsync("jeff", "1234");
                MessageBox.Show($"AccessToken : {FrontendInfo.AccessToken}\nApiEncryptionKey : {Convert.ToBase64String(FrontendInfo.ApiEncryptionKey)}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Public hello test method (no login, no encoding/encryption).
        /// </summary>
        private async void btnHello_Click(object sender, EventArgs e)
        {
            edtLog.Text = string.Empty;
            if (!ValidateInitialize()) { return; }

            try
            {
                // Create a form-level API connector. ProgId = "Employee" corresponds to the TEmployeeBusinessObject logic class.
                var connector = CreateFormApiConnector("Employee");

                // Execute the Hello method of the form-level business logic object, which maps to TEmployeeBusinessObject.Hello
                var args = new HelloArgs() { UserName = "Jeff" };
                var result = await connector.ExecuteAsync<HelloResult>("Hello", args, PayloadFormat.Plain);
                MessageBox.Show($"Message: {result.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        /// <summary>
        /// Validates whether initialization has been completed.
        /// </summary>
        private bool ValidateInitialize()
        {
            if (!_isInitialized)
            {
                MessageBox.Show("Please initialize first.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate and apply the endpoint. Used during initialization.
        /// </summary>
        /// <returns>True if applied successfully, otherwise false.</returns>
        private bool ValidateAndApplyEndpoint()
        {
            string endpoint = edtEndpoint.Text;
            if (string.IsNullOrWhiteSpace(endpoint))
            {
                MessageBox.Show("Please enter a valid endpoint.");
                return false;
            }

            if (StrFunc.Equals(_endpoint, endpoint))
            {
                return true;
            }

            var validator = new ApiConnectValidator();
            var connectType = validator.Validate(endpoint);

            // Set the connection type
            SetConnectType(connectType, endpoint);
            return true;
        }

        /// <summary>
        /// Set the connection type. Used during initialization.
        /// </summary>
        /// <param name="connectType">Connection type for the service.</param>
        /// <param name="endpoint">Service endpoint. URL for remote, local path for local mode.</param>
        private void SetConnectType(ConnectType connectType, string endpoint)
        {
            _endpoint = endpoint;

            // Set static connection information
            ConnectFunc.SetConnectType(connectType, endpoint);

            // If it is a local connection, simulate server initialization on the client
            if (connectType == ConnectType.Local)
            {
                var settings = CacheFunc.GetSystemSettings();
                settings.Initialize();
            }
        }

        /// <summary>
        /// Create a system-level API connector.
        /// </summary>
        private SystemApiConnector CreateSystemApiConnector()
        {
            if (FrontendInfo.ConnectType == ConnectType.Local)
                return new SystemApiConnector(FrontendInfo.AccessToken);
            else
                return new SystemApiConnector(_endpoint, FrontendInfo.AccessToken);
        }

        /// <summary>
        /// Create a form-level API connector.
        /// </summary>
        /// <param name="progId">Program ID used to identify the function or form.</param>
        private FormApiConnector CreateFormApiConnector(string progId)
        {
            if (FrontendInfo.ConnectType == ConnectType.Local)
                return new FormApiConnector(FrontendInfo.AccessToken, progId);
            else
                return new FormApiConnector(_endpoint, FrontendInfo.AccessToken, progId);
        }

    }
}
