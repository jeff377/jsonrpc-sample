using System;
using Custom.Define;
using Bee.Business;
using Bee.Define;

namespace Custom.Business
{
    /// <summary>
    /// Business logic object for Employee.
    /// </summary>
    public class EmployeeBusinessObject : FormBusinessObject
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sessionID">Session ID.</param>
        /// <param name="progId">Program ID.</param>
        public EmployeeBusinessObject(Guid sessionID, string progId) : base(sessionID, progId)
        {
        }

        /// <summary>
        /// Hello test method.
        /// </summary>
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
