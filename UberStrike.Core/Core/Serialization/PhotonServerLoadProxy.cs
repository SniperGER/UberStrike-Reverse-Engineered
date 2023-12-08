﻿using System.IO;
using Cmune.Core.Models;

namespace UberStrike.Core.Serialization {
	public static class PhotonServerLoadProxy {
		public static void Serialize(Stream stream, PhotonServerLoad instance) {
			using (var memoryStream = new MemoryStream()) {
				SingleProxy.Serialize(memoryStream, instance.MaxPlayerCount);
				Int32Proxy.Serialize(memoryStream, instance.PeersConnected);
				Int32Proxy.Serialize(memoryStream, instance.PlayersConnected);
				Int32Proxy.Serialize(memoryStream, instance.RoomsCreated);
				memoryStream.WriteTo(stream);
			}
		}

		public static PhotonServerLoad Deserialize(Stream bytes) {
			return new PhotonServerLoad {
				MaxPlayerCount = SingleProxy.Deserialize(bytes),
				PeersConnected = Int32Proxy.Deserialize(bytes),
				PlayersConnected = Int32Proxy.Deserialize(bytes),
				RoomsCreated = Int32Proxy.Deserialize(bytes)
			};
		}
	}
}
