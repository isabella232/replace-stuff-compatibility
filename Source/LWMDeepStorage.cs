using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace Replace_Stuff_Compatibility
{
	public class LWMDeepStorage : AbstractPatch
	{
		protected override string GetRequiredModNames() => "lwm.deepstorage";

		protected override void AddItems()
		{
			var shelf = GetDatabaseThing("Shelf");
			var doubleShelf = GetDatabaseThing("LWM_BigShelf");
			var deepDoubleShelf = GetDatabaseThing("LWM_VeryBigShelf");

			var pallet = GetDatabaseThing("LWM_Pallet");
			var wrappedPallet = GetDatabaseThing("LWM_Pallet_Covered");

			var weaponsCabinet = GetDatabaseThing("LWM_WeaponsCabinet");
			var weaponsLocker = GetDatabaseThing("LWM_WeaponsLocker");

			// When replacing an armour rack, make sure to copy over it's settings, pawn type, body type and owner
			Action<Thing, Thing> copyStorageSettings = (newThing, oldThing) =>
			{
				((Building_Storage) newThing).settings.CopyFrom(((Building_Storage) oldThing).settings);
			};

			AddInterchangeableList(new List<ThingDef> {shelf, doubleShelf, deepDoubleShelf}, preAction: copyStorageSettings);
			AddInterchangeableList(new List<ThingDef> {pallet, wrappedPallet}, preAction: copyStorageSettings);
			AddInterchangeableList(new List<ThingDef> {weaponsCabinet, weaponsLocker}, preAction: copyStorageSettings);
		}
	}
}