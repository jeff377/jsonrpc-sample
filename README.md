# jsonrpc-sample

## 專案概述
`jsonrpc-sample` 是一個基於 JSON-RPC 的範例方案，展示如何使用 .NET 技術實現用戶端與伺服器端的互動。此方案包含以下主要功能：
- JSON-RPC 伺服端初始化。
-  JSON-RPC 用戶端使用遠端連線，用於實際運行環境。
 - JSON-RPC 用戶端使用近端連線，用於開發階段偵錯。
- 使用 JSON-RPC 方法進行業務邏輯操作（如 `Ping` 和 `Hello` 方法）。
- 支援系統層級與表單層級的業務邏輯物件。
- JSON-RPC 傳遞資料進行編碼(序列化+壓縮+加密)。

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
	- 使用 Bee.UI.WinForms 套件的 ClientInfo 建立 Connector 執行 JSON-RPC 方法。

---

步驟
1.設置 System.Settings.xml 設定檔。
2.在 Custom.Business 專案建立商業邏輯物件。
3.在 Custom.Define 專案，建立商業邏輯方法的傳入參數及傳出結果類別。
4.啟動 JsonRpcServer 專案，使用 jsonrpc.http 執行 JSON-RPC 方法，確認伺服端正常運行。
5.啟動 JsonRpcClient 專案，使用迼端連線執行JSON-RPC 方法。
6.啟動 JsonRpcClient 專案，使用近端連線執行JSON-RPC 方法。

## 設置 System.Settings.xml 設定檔
AllowedTypeNamespaces 設定 JSON 反序列化的命名空間的白名單
ApiPayloadOptions 是設定編碼方式(序列化+壓縮+加密)
BusinessObjectProvider 指定業務邏輯物件提供者，以建立 ProgID 對應的業務邏輯物件

```xml
<?xml version="1.0" encoding="utf-8"?>
<SystemSettings xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    <CommonConfiguration>
        <Version>1.0.0</Version>
        <IsDebugMode>true</IsDebugMode>
        <AllowedTypeNamespaces>Custom.Define</AllowedTypeNamespaces>
        <ApiPayloadOptions>
            <Serializer>messagepack</Serializer>
            <Compressor>gzip</Compressor>
            <Encryptor>aes256</Encryptor>
        </ApiPayloadOptions>
    </CommonConfiguration>
    <BackendConfiguration>
        <BusinessObjectProvider>Custom.Business.TBusinessObjectProvider, Custom.Business</BusinessObjectProvider>
    </BackendConfiguration>
</SystemSettings>
```

## 設置 System.Settings.xml 設定檔



## 呼叫 JSON-RPC 方法的 JSON 格式

method 的格式為 {ProgID}.{Method}
"$type" 為 Method 傳入參數型別

```json

{
  "jsonrpc": "2.0",
  "method": "{ProgID}.{Method}",
  "params": {
    "value": {
      "$type": "Custom.Define.THelloArgs, Custom.Define",
      "userName": "Jeff"
    }
  },
  "id": "e942952b-6450-412c-bb24-c6ab7c804789"
}
```

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