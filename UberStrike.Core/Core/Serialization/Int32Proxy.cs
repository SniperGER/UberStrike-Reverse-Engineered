﻿using System;
using System.IO;

namespace UberStrike.Core.Serialization {
	public static class Int32Proxy {
		public static void Serialize(Stream bytes, int instance) {
			var bytes2 = BitConverter.GetBytes(instance);
			bytes.Write(bytes2, 0, bytes2.Length);
		}

		public static int Deserialize(Stream bytes) {
			var array = new byte[4];
			bytes.Read(array, 0, 4);

			return BitConverter.ToInt32(array, 0);
		}
	}
}
