using System;
using System.Collections.Generic;
using Replace_Stuff.NewThing;
using RimWorld;
using Verse;

namespace Replace_Stuff_Compatibility
{
	public static class VanillaExpandedFurniture
	{
		[DefOf]
		public static class BaseGameThingDefs
		{
			public static ThingDef EndTable;
			public static ThingDef Dresser;
		}

		private static Predicate<ThingDef> ListContainsThingDef(List<ThingDef> list)
		{
			return product => list.Exists(n => n == product);
		}

		
		public static void Patch()
		{
			if (!LoadedModManager.RunningModsListForReading.Exists(pack => pack.PackageId == "vanillaexpanded.vfecore"))
			{
				return;
			}
			
			var tableLightEndTable = DefDatabase<ThingDef>.GetNamed("Table_LightEndTable");
			var tableRoyalEndTable = DefDatabase<ThingDef>.GetNamed("Table_RoyalEndTable");
			var tableRoyalDresser = DefDatabase<ThingDef>.GetNamed("Table_RoyalDresser");

			var endTables = new List<ThingDef>()
			{
				BaseGameThingDefs.EndTable,
				tableLightEndTable,
				tableRoyalEndTable
			};

			var dressers = new List<ThingDef>()
			{
				BaseGameThingDefs.Dresser,
				tableRoyalDresser,
			};

			NewThingReplacement.replacements.Add(new NewThingReplacement.Replacement(
				ListContainsThingDef(endTables)
			));
			
			NewThingReplacement.replacements.Add(new NewThingReplacement.Replacement(
				ListContainsThingDef(dressers)
			));
		}
	}
}