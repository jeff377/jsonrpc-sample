using System;
using Custom.Define;
using Bee.Business;
using Bee.Define;

namespace Custom.Business
{
    /// <summary>
    /// 員工的業務邏輯物件。
    /// </summary>
    public class EmployeeBusinessObject : FormBusinessObject
    {
        /// <summary>
        /// 建構函式。
        /// </summary>
        /// <param name="sessionID">連線識別。</param>
        /// <param name="progId">程式代碼。</param>
        public EmployeeBusinessObject(Guid sessionID, string progId) : base(sessionID, progId)
        {
        }

        /// <summary>
        /// Hello 測試方法。
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        [ApiAccessControl(ApiProtectionLevel.Public)]
        public HelloResult Hello(HelloArgs args)
        {
            return new HelloResult()
            {
                Message = $"Hello, {args.UserName}"
            };
        }
    }
}
