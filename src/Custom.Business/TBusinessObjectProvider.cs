﻿using System;
using Bee.Define;

namespace Custom.Business
{
    /// <summary>
    /// 業務邏輯物件提供者。
    /// </summary>
    public class TBusinessObjectProvider : IBusinessObjectProvider
    {
        /// <summary>
        /// 建構函式。
        /// </summary>
        public TBusinessObjectProvider()
        { }

        /// <summary>
        /// 建立系統層級業務邏輯物件。
        /// </summary>
        /// <param name="accessToken">存取令牌。</param>
        public object CreateSystemObject(Guid accessToken)
        {
            return SysFunc.CreateSystemObject(accessToken);
        }

        /// <summary>
        /// 建立表單層級業務邏輯物件。
        /// </summary>
        /// <param name="accessToken">存取令牌。</param>
        /// <param name="progID">程式代碼。</param>
        public object CreateFormObject(Guid accessToken, string progID)
        {
            switch (progID)
            {
                case "Employee":  // 員工
                    return new TEmployeeObject(accessToken, progID);
                default:
                    return SysFunc.CreateBusinessObject(accessToken, progID);
            }
        }
    }
}
