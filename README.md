# jsonrpc-sample

## 專案概述
`jsonrpc-sample` 是一個基於 JSON-RPC 的範例方案，展示如何使用 .NET 技術實現用戶端與伺服器端的互動。此方案包含以下主要功能：
- JSON-RPC 伺服端初始化。
- JSON-RPC 用戶端使用遠端連線，用於實際運行環境。
- JSON-RPC 用戶端使用近端連線，用於開發階段偵錯。
- 使用 JSON-RPC 方法進行業務邏輯操作（如 `Ping` 和 `Hello` 方法）。
- 支援系統層級與表單層級的業務邏輯物件。
- JSON-RPC 傳遞資料進行編碼（序列化 + 壓縮 + 加密）。

---

## 專案架構
此方案包含以下主要模組：
1. **DefinePath**:
   - 定義資料存放路徑，如 `System.Settings.xml`、`Database.Settings.xml` 等。
   - 此範例只會使用到 `System.Settings.xml`。

2. **Custom.Define**:
   - 定義業務邏輯參數與結果類型，例如 `THelloArgs` 和 `THelloResult`。
   - 業務邏輯參數與結果類別。
   - JSON-RPC 的用戶端及伺服器端皆需引用此組件。

3. **Custom.Business**:
   - 定義業務邏輯物件，如 `TEmployeeBusinessObject`，並實現具體的業務邏輯方法（如 `Hello` 方法）。
   - JSON-RPC 伺服端的必要組件。
   - JSON-RPC 用戶端在開發階段使用近端連線時，需引用此組件。
   - 支援 JSON-RPC 呼叫的業務邏輯方法，傳入參數及傳出結果皆為類別，例如 `Hello` 的傳入參數為 `THelloArgs`，傳出結果為 `THelloResult`。

4. **JsonRpcServer**:
   - 提供伺服器端的擴充方法與 API 定義。
   - 使用 `BackendExtensions` 進行伺服器初始化，設定 `DefinePath` 和 API 服務選項。

5. **JsonRpcClient**:
   - 提供 Windows Forms 應用程式，展示如何使用 JSON-RPC 與伺服器互動。
   - 使用 `Bee.Connect` 套件的 Connector 執行 JSON-RPC 方法。
   - 使用 `Bee.UI.WinForms` 套件的 ClientInfo 建立 Connector 執行 JSON-RPC 方法。

---

## JSON-RPC 請求範例
`method` 的格式為 `{ProgID}.{Method}`。
`"$type"` 為 Method 傳入參數型別。
{
  "jsonrpc": "2.0",
  "method": "Employee.Hello",
  "params": {
    "value": {
      "$type": "Custom.Define.THelloArgs, Custom.Define",
      "userName": "Jeff"
    }
  },
  "id": "e942952b-6450-412c-bb24-c6ab7c804789"
}
---

## 開發者指南
1. **設置 System.Settings.xml**:
   - 設定 `AllowedTypeNamespaces` 為 JSON 反序列化的命名空間白名單。
   - 設定 `ApiPayloadOptions` 為編碼方式（序列化 + 壓縮 + 加密）。
   - 指定 `BusinessObjectProvider` 為業務邏輯物件提供者。

2. **擴展業務邏輯**:
   - 在 `Custom.Business` 專案中新增業務邏輯物件，並實現相關方法。
   - 在 `Custom.Define` 專案中定義業務邏輯方法的傳入參數及傳出結果類別。

3. **啟動伺服器**:
   - 啟動 `JsonRpcServer` 專案，使用 `BackendExtensions.BackendInitialize` 方法進行伺服器初始化：
     - 設定 `DefinePath`，確保目錄存在。
     - 初始化系統設定與 API 服務選項。
   - 使用 `jsonrpc.http` 文件測試 JSON-RPC 方法，確認伺服端正常運行。

4. **啟動客戶端**:
   - 啟動 `JsonRpcClient` 專案，使用遠端或近端連線執行 JSON-RPC 方法。

---

## 系統需求
- **.NET 8**: 用於客戶端應用程式。
- **.NET Standard 2.0**: 用於業務邏輯模組。

---

## 聯絡方式
如有任何問題，請聯絡開發者團隊。