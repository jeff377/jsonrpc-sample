﻿using System;
using Bee.Business;
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
        public ISystemBusinessObject CreateSystemBusinessObject(Guid accessToken)
        {
            return new TSystemBusinessObject(accessToken);
        }

        /// <summary>
        /// 建立表單層級業務邏輯物件。
        /// </summary>
        /// <param name="accessToken">存取令牌。</param>
        /// <param name="progId">程式代碼。</param>
        public IFormBusinessObject CreateFormBusinessObject(Guid accessToken, string progId)
        {
            switch (progId)
            {
                case "Employee":  // 員工
                    return new TEmployeeBusinessObject(accessToken, progId);
                default:
                    return new TFormBusinessObject(accessToken, progId);
            }
        }
    }
}
