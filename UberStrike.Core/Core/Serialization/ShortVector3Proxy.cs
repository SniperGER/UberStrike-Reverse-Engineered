﻿using System;
using System.IO;
using UberStrike.Core.Models;
using UnityEngine;

namespace UberStrike.Core.Serialization {
	public static class ShortVector3Proxy {
		public static void Serialize(Stream bytes, ShortVector3 instance) {
			bytes.Write(BitConverter.GetBytes((short)Mathf.Clamp(instance.x * 100f, -32768f, 32767f)), 0, 2);
			bytes.Write(BitConverter.GetBytes((short)Mathf.Clamp(instance.y * 100f, -32768f, 32767f)), 0, 2);
			bytes.Write(BitConverter.GetBytes((short)Mathf.Clamp(instance.z * 100f, -32768f, 32767f)), 0, 2);
		}

		public static ShortVector3 Deserialize(Stream bytes) {
			var array = new byte[6];
			bytes.Read(array, 0, 6);

			return new Vector3(0.01f * BitConverter.ToInt16(array, 0), 0.01f * BitConverter.ToInt16(array, 2), 0.01f * BitConverter.ToInt16(array, 4));
		}
	}
}
