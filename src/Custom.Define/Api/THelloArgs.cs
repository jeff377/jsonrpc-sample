﻿using System;
using Bee.Define;
using MessagePack;

namespace Custom.Define
{
    [MessagePackObject]
    [Serializable]
    public class THelloArgs : TBusinessArgs
    {
        /// <summary>
        /// 用戶名稱。
        /// </summary>
        [Key(1)]
        public string UserName { get; set; } = string.Empty;
    }
}
