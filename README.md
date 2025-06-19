# jsonrpc-sample

## 專案概述
`jsonrpc-sample` 是一個基於 JSON-RPC 的範例方案，展示如何使用 .NET 技術實現用戶端與伺服器端的互動。此方案包含以下主要功能：
- 客戶端初始化與伺服器端點設定。
- 使用 JSON-RPC 方法進行業務邏輯操作（如 `Ping` 和 `Hello` 方法）。
- 支援系統層級與表單層級的業務邏輯物件。

---

## 專案架構
此方案包含以下主要模組：
1. **DefinePath**:
   - 定義資料存放路徑，如 Sysetm.Settings.xml、Database.Settings.xml 等。
   - 此範例只會使用到 Sysetem.Settings.xml。
	
2. **Custom.Define**:
   - 定義業務邏輯參數與結果類型，例如 `THelloArgs` 和 `THelloResult`。
	- 業務邏輯參數與結果類別，
	- JSON-RPC 的用戶端及伺服端皆需引用此組件。
	
3. **Custom.Business**:
   - 定義業務邏輯物件，如 `TEmployeeBusinessObject`，並實現具體的業務邏輯方法（如 `Hello` 方法）。
	- JSON-RPC 伺服端的必要組件。
	-  JSON-RPC 用戶端在開發階段使用近端連線時，需引用此組件。
   - 支援 JSON-RPC 呼叫的業務邏輯方法，傳入參數及傳出結果皆為類別，例如 Hello 的傳入參教為 THelloArgs，傳出結果為 THelloResult。

4. **JsonRpcServer**:
   - 提供伺服器端的擴充方法與 API 定義。
   - 使用 `BackendExtensions` 進行伺服器初始化，設定 `DefinePath` 和 API 服務選項。

3. **JsonRpcClient**:
   - 提供 Windows Forms 應用程式，展示如何使用 JSON-RPC 與伺服器互動。
   - 使用 Bee.Connect 套件的 Connector 執行 JSON-RPC 方法。
	- 使用 Bee.Connect 套件的 ClientInfo 建立 Connector 執行 JSON-RPC 方法。

---

## 使用方式

### 1. 客戶端操作
#### 初始化
在客戶端應用程式中，點擊「初始化」按鈕執行以下操作：
- 初始化客戶端，並設定支援的連線類型。
- 如果是本地連線，則載入系統設定。

#### Ping 方法
點擊「Ping」按鈕執行伺服器端的 `Ping` 方法，測試伺服器是否正常運作。

#### Hello 方法
點擊「Hello」按鈕執行伺服器端的 `Hello` 方法，並顯示返回的訊息。

---

### 2. 伺服器端操作
#### 初始化
使用 `BackendExtensions.BackendInitialize` 方法進行伺服器初始化：
- 設定 `DefinePath`，確保目錄存在。
- 初始化系統設定與 API 服務選項。

#### JSON-RPC 方法
伺服器端支援以下 JSON-RPC 方法：
- **Ping**: 測試伺服器是否正常運作。
- **Hello**: 返回基於用戶名稱的歡迎訊息。

---

## JSON-RPC 範例
以下是 JSON-RPC 的 HTTP 請求範例：

### Ping 方法

---

## 系統需求
- **.NET 8**: 用於客戶端應用程式。
- **.NET Standard 2.0**: 用於業務邏輯模組。

---

## 開發者指南
1. **設定 DefinePath**:
   - 在伺服器端的 `appsettings.json` 中設定 `DefinePath`，指向業務邏輯定義的目錄。

2. **擴展業務邏輯**:
   - 在 `Custom.Business` 中新增業務邏輯物件，並實現相關方法。

3. **測試 JSON-RPC**:
   - 使用 `jsonrpc.http` 文件測試伺服器端的 JSON-RPC 方法。

---

## 聯絡方式
如有任何問題，請聯絡開發者團隊。