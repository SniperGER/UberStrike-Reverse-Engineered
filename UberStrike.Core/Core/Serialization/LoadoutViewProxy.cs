﻿using System.IO;
using UberStrike.Core.Types;
using UberStrike.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization {
	public static class LoadoutViewProxy {
		public static void Serialize(Stream stream, LoadoutView instance) {
			var num = 0;

			using (var memoryStream = new MemoryStream()) {
				Int32Proxy.Serialize(memoryStream, instance.Backpack);
				Int32Proxy.Serialize(memoryStream, instance.Boots);
				Int32Proxy.Serialize(memoryStream, instance.Cmid);
				Int32Proxy.Serialize(memoryStream, instance.Face);
				Int32Proxy.Serialize(memoryStream, instance.FunctionalItem1);
				Int32Proxy.Serialize(memoryStream, instance.FunctionalItem2);
				Int32Proxy.Serialize(memoryStream, instance.FunctionalItem3);
				Int32Proxy.Serialize(memoryStream, instance.Gloves);
				Int32Proxy.Serialize(memoryStream, instance.Head);
				Int32Proxy.Serialize(memoryStream, instance.LoadoutId);
				Int32Proxy.Serialize(memoryStream, instance.LowerBody);
				Int32Proxy.Serialize(memoryStream, instance.MeleeWeapon);
				Int32Proxy.Serialize(memoryStream, instance.QuickItem1);
				Int32Proxy.Serialize(memoryStream, instance.QuickItem2);
				Int32Proxy.Serialize(memoryStream, instance.QuickItem3);

				if (instance.SkinColor != null) {
					StringProxy.Serialize(memoryStream, instance.SkinColor);
				} else {
					num |= 1;
				}

				EnumProxy<AvatarType>.Serialize(memoryStream, instance.Type);
				Int32Proxy.Serialize(memoryStream, instance.UpperBody);
				Int32Proxy.Serialize(memoryStream, instance.Weapon1);
				Int32Proxy.Serialize(memoryStream, instance.Weapon1Mod1);
				Int32Proxy.Serialize(memoryStream, instance.Weapon1Mod2);
				Int32Proxy.Serialize(memoryStream, instance.Weapon1Mod3);
				Int32Proxy.Serialize(memoryStream, instance.Weapon2);
				Int32Proxy.Serialize(memoryStream, instance.Weapon2Mod1);
				Int32Proxy.Serialize(memoryStream, instance.Weapon2Mod2);
				Int32Proxy.Serialize(memoryStream, instance.Weapon2Mod3);
				Int32Proxy.Serialize(memoryStream, instance.Weapon3);
				Int32Proxy.Serialize(memoryStream, instance.Weapon3Mod1);
				Int32Proxy.Serialize(memoryStream, instance.Weapon3Mod2);
				Int32Proxy.Serialize(memoryStream, instance.Weapon3Mod3);
				Int32Proxy.Serialize(memoryStream, instance.Webbing);
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		public static LoadoutView Deserialize(Stream bytes) {
			var num = Int32Proxy.Deserialize(bytes);
			var loadoutView = new LoadoutView();
			loadoutView.Backpack = Int32Proxy.Deserialize(bytes);
			loadoutView.Boots = Int32Proxy.Deserialize(bytes);
			loadoutView.Cmid = Int32Proxy.Deserialize(bytes);
			loadoutView.Face = Int32Proxy.Deserialize(bytes);
			loadoutView.FunctionalItem1 = Int32Proxy.Deserialize(bytes);
			loadoutView.FunctionalItem2 = Int32Proxy.Deserialize(bytes);
			loadoutView.FunctionalItem3 = Int32Proxy.Deserialize(bytes);
			loadoutView.Gloves = Int32Proxy.Deserialize(bytes);
			loadoutView.Head = Int32Proxy.Deserialize(bytes);
			loadoutView.LoadoutId = Int32Proxy.Deserialize(bytes);
			loadoutView.LowerBody = Int32Proxy.Deserialize(bytes);
			loadoutView.MeleeWeapon = Int32Proxy.Deserialize(bytes);
			loadoutView.QuickItem1 = Int32Proxy.Deserialize(bytes);
			loadoutView.QuickItem2 = Int32Proxy.Deserialize(bytes);
			loadoutView.QuickItem3 = Int32Proxy.Deserialize(bytes);

			if ((num & 1) != 0) {
				loadoutView.SkinColor = StringProxy.Deserialize(bytes);
			}

			loadoutView.Type = EnumProxy<AvatarType>.Deserialize(bytes);
			loadoutView.UpperBody = Int32Proxy.Deserialize(bytes);
			loadoutView.Weapon1 = Int32Proxy.Deserialize(bytes);
			loadoutView.Weapon1Mod1 = Int32Proxy.Deserialize(bytes);
			loadoutView.Weapon1Mod2 = Int32Proxy.Deserialize(bytes);
			loadoutView.Weapon1Mod3 = Int32Proxy.Deserialize(bytes);
			loadoutView.Weapon2 = Int32Proxy.Deserialize(bytes);
			loadoutView.Weapon2Mod1 = Int32Proxy.Deserialize(bytes);
			loadoutView.Weapon2Mod2 = Int32Proxy.Deserialize(bytes);
			loadoutView.Weapon2Mod3 = Int32Proxy.Deserialize(bytes);
			loadoutView.Weapon3 = Int32Proxy.Deserialize(bytes);
			loadoutView.Weapon3Mod1 = Int32Proxy.Deserialize(bytes);
			loadoutView.Weapon3Mod2 = Int32Proxy.Deserialize(bytes);
			loadoutView.Weapon3Mod3 = Int32Proxy.Deserialize(bytes);
			loadoutView.Webbing = Int32Proxy.Deserialize(bytes);

			return loadoutView;
		}
	}
}
