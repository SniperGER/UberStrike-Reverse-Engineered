﻿using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization {
	public static class LuckyDrawUnityViewProxy {
		public static void Serialize(Stream stream, LuckyDrawUnityView instance) {
			var num = 0;

			using (var memoryStream = new MemoryStream()) {
				EnumProxy<BundleCategoryType>.Serialize(memoryStream, instance.Category);

				if (instance.Description != null) {
					StringProxy.Serialize(memoryStream, instance.Description);
				} else {
					num |= 1;
				}

				if (instance.IconUrl != null) {
					StringProxy.Serialize(memoryStream, instance.IconUrl);
				} else {
					num |= 2;
				}

				Int32Proxy.Serialize(memoryStream, instance.Id);
				BooleanProxy.Serialize(memoryStream, instance.IsAvailableInShop);

				if (instance.LuckyDrawSets != null) {
					ListProxy<LuckyDrawSetUnityView>.Serialize(memoryStream, instance.LuckyDrawSets, LuckyDrawSetUnityViewProxy.Serialize);
				} else {
					num |= 4;
				}

				if (instance.Name != null) {
					StringProxy.Serialize(memoryStream, instance.Name);
				} else {
					num |= 8;
				}

				Int32Proxy.Serialize(memoryStream, instance.Price);
				EnumProxy<UberStrikeCurrencyType>.Serialize(memoryStream, instance.UberStrikeCurrencyType);
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		public static LuckyDrawUnityView Deserialize(Stream bytes) {
			var num = Int32Proxy.Deserialize(bytes);
			var luckyDrawUnityView = new LuckyDrawUnityView();
			luckyDrawUnityView.Category = EnumProxy<BundleCategoryType>.Deserialize(bytes);

			if ((num & 1) != 0) {
				luckyDrawUnityView.Description = StringProxy.Deserialize(bytes);
			}

			if ((num & 2) != 0) {
				luckyDrawUnityView.IconUrl = StringProxy.Deserialize(bytes);
			}

			luckyDrawUnityView.Id = Int32Proxy.Deserialize(bytes);
			luckyDrawUnityView.IsAvailableInShop = BooleanProxy.Deserialize(bytes);

			if ((num & 4) != 0) {
				luckyDrawUnityView.LuckyDrawSets = ListProxy<LuckyDrawSetUnityView>.Deserialize(bytes, LuckyDrawSetUnityViewProxy.Deserialize);
			}

			if ((num & 8) != 0) {
				luckyDrawUnityView.Name = StringProxy.Deserialize(bytes);
			}

			luckyDrawUnityView.Price = Int32Proxy.Deserialize(bytes);
			luckyDrawUnityView.UberStrikeCurrencyType = EnumProxy<UberStrikeCurrencyType>.Deserialize(bytes);

			return luckyDrawUnityView;
		}
	}
}
