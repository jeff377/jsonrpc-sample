using System;
using Custom.Define;
using Bee.Business;

namespace Custom.Business
{
    /// <summary>
    /// 員工的業務邏輯物件。
    /// </summary>
    public class TEmployeeObject : TFormObject
    {
        /// <summary>
        /// 建構函式。
        /// </summary>
        /// <param name="sessionID">連線識別。</param>
        /// <param name="progID">程式代碼。</param>
        public TEmployeeObject(Guid sessionID, string progID) : base(sessionID, progID)
        {
        }

        /// <summary>
        /// Hello 測試方法。
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public THelloResult Hello(THelloArgs args)
        {
            return new THelloResult()
            {
                Message = $"Hello, {args.UserName}"
            };
        }
    }
}
