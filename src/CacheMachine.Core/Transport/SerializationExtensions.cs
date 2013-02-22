﻿using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CacheMachine.Core.Transport
{
    public static class SerializationExtensions
    {
        public static byte[] ObjectToByteArray(this object obj)
        {
            if (obj == null)
                return null;

            var bf = new BinaryFormatter();

            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();    
            }
        }
    }
}