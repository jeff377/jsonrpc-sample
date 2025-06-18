using System;
using Bee.Define;
using MessagePack;

namespace Custom.Define
{
    [MessagePackObject]
    [Serializable]
    public class THelloResult : TBusinessResult
    {
        /// <summary>
        /// 回傳訊息。
        /// </summary>
        [Key(1)]
        public string Message { get; set; } = string.Empty;
    }
}
