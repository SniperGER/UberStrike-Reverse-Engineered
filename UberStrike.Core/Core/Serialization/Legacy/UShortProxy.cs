﻿using System;
using System.IO;

namespace UberStrike.Core.Serialization.Legacy {
	public static class UShortProxy {
		public static void Serialize(Stream bytes, ushort instance) {
			byte[] bytes2 = BitConverter.GetBytes(instance);
			bytes.Write(bytes2, 0, bytes2.Length);
		}

		public static ushort Deserialize(Stream bytes) {
			byte[] array = new byte[2];
			bytes.Read(array, 0, 2);
			return BitConverter.ToUInt16(array, 0);
		}
	}
}
