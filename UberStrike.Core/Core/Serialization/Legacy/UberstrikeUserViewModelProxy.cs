﻿using UberStrike.Core.ViewModel;
using System.IO;

namespace UberStrike.Core.Serialization.Legacy {
	public static class UberstrikeUserViewModelProxy {
		public static void Serialize(Stream stream, UberstrikeUserViewModel instance) {
			int num = 0;
			if (instance != null) {
				using (MemoryStream memoryStream = new MemoryStream()) {
					if (instance.CmuneMemberView != null) {
						MemberViewProxy.Serialize(memoryStream, instance.CmuneMemberView);
					} else {
						num |= 1;
					}
					if (instance.UberstrikeMemberView != null) {
						UberstrikeMemberViewProxy.Serialize(memoryStream, instance.UberstrikeMemberView);
					} else {
						num |= 2;
					}
					Int32Proxy.Serialize(stream, ~num);
					memoryStream.WriteTo(stream);
				}
			} else {
				Int32Proxy.Serialize(stream, 0);
			}
		}

		public static UberstrikeUserViewModel Deserialize(Stream bytes) {
			int num = Int32Proxy.Deserialize(bytes);
			UberstrikeUserViewModel uberstrikeUserViewModel = null;
			if (num != 0) {
				uberstrikeUserViewModel = new UberstrikeUserViewModel();
				if ((num & 1) != 0) {
					uberstrikeUserViewModel.CmuneMemberView = MemberViewProxy.Deserialize(bytes);
				}
				if ((num & 2) != 0) {
					uberstrikeUserViewModel.UberstrikeMemberView = UberstrikeMemberViewProxy.Deserialize(bytes);
				}
			}
			return uberstrikeUserViewModel;
		}
	}
}
