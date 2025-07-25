#  jsonrpc-sample

## 📝 專案概述

`jsonrpc-sample` 是一個基於 JSON-RPC 協議的示範專案，展示如何使用 .NET 技術實現用戶端與伺服器端的互動。此專案涵蓋以下功能：

- JSON-RPC 伺服端初始化  
- JSON-RPC 用戶端遠端連線，模擬實際部署環境  
- JSON-RPC 用戶端近端連線，方便開發與除錯  
- 使用 JSON-RPC 方法進行業務邏輯操作（如 `Ping` 與 `Hello` 方法）  
- 支援系統層級與表單層級的業務邏輯物件  
- 支援資料傳輸的序列化、壓縮與加密（即編碼處理）

---

## 🧩 專案架構

此專案包含以下模組：

1. **DefinePath 資料夾**  
   - 定義系統參數檔路徑（如 `System.Settings.xml`, `Database.Settings.xml`）  
   - 本範例僅使用 `System.Settings.xml`

2. **Custom.Define 專案**  
   - 定義業務邏輯的參數與結果資料類型（例如 `HelloArgs`, `HelloResult`）  
   - 為 JSON-RPC 用戶端與伺服端共用的模組

3. **Custom.Business 專案**  
   - 實作業務邏輯物件（如 `EmployeeBusinessObject`）及其方法（如 `Hello`）  
   - 為伺服端必要模組，開發階段近端用戶端亦可參考  
   - 所有 JSON-RPC 呼叫皆以類別形式傳遞參數與接收結果

4. **JsonRpcServer 專案**  
   - 提供伺服端初始化與 API 註冊的擴充方法  
   - 使用 `BackendExtensions` 設定 `DefinePath` 並初始化服務  
   - 包含 `ApiServiceController` 類別，作為 API 服務的控制器，繼承自 `Bee.Business.ApiServiceController`，負責處理 JSON-RPC 請求並提供 API 端點

5. **JsonRpcClient 專案**  
   - Windows Forms 範例用戶端，示範如何透過 JSON-RPC 與伺服器互動  
   - 使用 `ApiConnector` 呼叫 API 方法

---

## 🔐 API 金鑰產生與設定

**為了確保 JSON-RPC 的安全性，必須先產生並設定 API 金鑰。**  
API 金鑰將用於加密與解密 JSON-RPC 的請求與回應資料，若未完成金鑰設定，範例程式將無法正常運行。

### ✅ 操作步驟：

請使用 [BeeSettingsEditor 工具](https://github.com/jeff377/bee-library/tree/main/tools/BeeSettingsEditor) 產生 API 加密金鑰，並寫入至 `System.Settings.xml`。

1. 下載並執行 `BeeSettingsEditor.exe` 工具  
2. 產生主金鑰檔案（`Master.key`）  
3. 產生 API 加密金鑰，會自動加密並儲存於設定檔中  

📘 詳細操作說明請參閱工具專案的 README：  
👉 [BeeSettingsEditor 工具頁面](https://github.com/jeff377/bee-library/tree/main/tools/BeeSettingsEditor)

---

## 💬 JSON-RPC 請求範例

`method` 格式為 `{ProgID}.{Method}`，`"$type"` 表示方法參數的型別定義。

```json
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
```

---

## 🛠️ 開發者指南

1. **設定 `System.Settings.xml`**
   - 指定 `AllowedTypeNamespaces` 允許的反序列化命名空間
   - 設定 `ApiPayloadOptions` 為序列化、壓縮與加密的順序
   - 指定 `BusinessObjectProvider` 為業務邏輯載入類型

2. **擴充業務邏輯**
   - 在 `Custom.Business` 新增業務物件與方法實作
   - 在 `Custom.Define` 定義對應的參數與回傳類別

3. **啟動伺服器**
   - 執行 `JsonRpcServer`，透過 `BackendInitialize` 進行初始化
   - 確保 `DefinePath` 所指定的目錄與設定檔存在
   - 可透過 `jsonrpc.http` 測試 JSON-RPC 方法運作狀況

4. **啟動用戶端**
   - 執行 `JsonRpcClient`，選擇遠端或近端方式呼叫 JSON-RPC 方法
