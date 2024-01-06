﻿using System.IO;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;

namespace UberStrike.Core.Serialization.Legacy {
	public static class UberStrikeItemGearViewProxy {
		public static void Serialize(Stream stream, UberStrikeItemGearView instance) {
			int num = 0;
			if (instance != null) {
				using (MemoryStream memoryStream = new MemoryStream()) {
					Int32Proxy.Serialize(memoryStream, instance.ArmorAbsorptionPercent);
					Int32Proxy.Serialize(memoryStream, instance.ArmorPoints);
					Int32Proxy.Serialize(memoryStream, instance.ArmorWeight);
					if (instance.CustomProperties != null) {
						DictionaryProxy<string, string>.Serialize(memoryStream, instance.CustomProperties, new DictionaryProxy<string, string>.Serializer<string>(StringProxy.Serialize), new DictionaryProxy<string, string>.Serializer<string>(StringProxy.Serialize));
					} else {
						num |= 1;
					}
					if (instance.Description != null) {
						StringProxy.Serialize(memoryStream, instance.Description);
					} else {
						num |= 2;
					}
					Int32Proxy.Serialize(memoryStream, instance.ID);
					BooleanProxy.Serialize(memoryStream, instance.IsConsumable);
					EnumProxy<UberstrikeItemClass>.Serialize(memoryStream, instance.ItemClass);
					Int32Proxy.Serialize(memoryStream, instance.LevelLock);
					if (instance.Name != null) {
						StringProxy.Serialize(memoryStream, instance.Name);
					} else {
						num |= 4;
					}
					if (instance.PrefabName != null) {
						StringProxy.Serialize(memoryStream, instance.PrefabName);
					} else {
						num |= 8;
					}
					if (instance.Prices != null) {
						ListProxy<ItemPrice>.Serialize(memoryStream, instance.Prices, new ListProxy<ItemPrice>.Serializer<ItemPrice>(ItemPriceProxy.Serialize));
					} else {
						num |= 16;
					}
					EnumProxy<ItemShopHighlightType>.Serialize(memoryStream, instance.ShopHighlightType);
					Int32Proxy.Serialize(stream, ~num);
					memoryStream.WriteTo(stream);
					return;
				}
			}
			Int32Proxy.Serialize(stream, 0);
		}

		public static UberStrikeItemGearView Deserialize(Stream bytes) {
			int num = Int32Proxy.Deserialize(bytes);
			UberStrikeItemGearView uberStrikeItemGearView = null;
			if (num != 0) {
				uberStrikeItemGearView = new UberStrikeItemGearView();
				uberStrikeItemGearView.ArmorAbsorptionPercent = Int32Proxy.Deserialize(bytes);
				uberStrikeItemGearView.ArmorPoints = Int32Proxy.Deserialize(bytes);
				uberStrikeItemGearView.ArmorWeight = Int32Proxy.Deserialize(bytes);
				if ((num & 1) != 0) {
					uberStrikeItemGearView.CustomProperties = DictionaryProxy<string, string>.Deserialize(bytes, new DictionaryProxy<string, string>.Deserializer<string>(StringProxy.Deserialize), new DictionaryProxy<string, string>.Deserializer<string>(StringProxy.Deserialize));
				}
				if ((num & 2) != 0) {
					uberStrikeItemGearView.Description = StringProxy.Deserialize(bytes);
				}
				uberStrikeItemGearView.ID = Int32Proxy.Deserialize(bytes);
				uberStrikeItemGearView.IsConsumable = BooleanProxy.Deserialize(bytes);
				uberStrikeItemGearView.ItemClass = EnumProxy<UberstrikeItemClass>.Deserialize(bytes);
				uberStrikeItemGearView.LevelLock = Int32Proxy.Deserialize(bytes);
				if ((num & 4) != 0) {
					uberStrikeItemGearView.Name = StringProxy.Deserialize(bytes);
				}
				if ((num & 8) != 0) {
					uberStrikeItemGearView.PrefabName = StringProxy.Deserialize(bytes);
				}
				if ((num & 16) != 0) {
					uberStrikeItemGearView.Prices = ListProxy<ItemPrice>.Deserialize(bytes, new ListProxy<ItemPrice>.Deserializer<ItemPrice>(ItemPriceProxy.Deserialize));
				}
				uberStrikeItemGearView.ShopHighlightType = EnumProxy<ItemShopHighlightType>.Deserialize(bytes);
			}
			return uberStrikeItemGearView;
		}
	}
}
