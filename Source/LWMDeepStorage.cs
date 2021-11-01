using System;
using System.Collections.Generic;
using ArmorRacks.ThingComps;
using ArmorRacks.Things;
using Replace_Stuff.NewThing;
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

			NewThingReplacement.replacements.Add(new NewThingReplacement.Replacement(
				ListContainsThingDef(new List<ThingDef>() {shelf, doubleShelf, deepDoubleShelf}),
				preAction: copyStorageSettings));

			NewThingReplacement.replacements.Add(new NewThingReplacement.Replacement(
				ListContainsThingDef(new List<ThingDef>() {pallet, wrappedPallet}),
				preAction: copyStorageSettings));
			
			NewThingReplacement.replacements.Add(new NewThingReplacement.Replacement(
				ListContainsThingDef(new List<ThingDef>() {weaponsCabinet, weaponsLocker}),
				preAction: copyStorageSettings));
		}
	}
}