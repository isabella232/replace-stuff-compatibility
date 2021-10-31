using RimWorld;
using Verse;

namespace Replace_Stuff_Compatibility
{
	public class VanillaExpandedFurniture: AbstractPatch
	{
		[DefOf]
		public static class BaseGameThingDefs
		{
			public static ThingDef EndTable;
			public static ThingDef Dresser;
		}

		protected override string GetRequiredModNames() => "vanillaexpanded.vfecore";

		protected override void AddItems()
		{
			if (!LoadedModManager.RunningModsListForReading.Exists(pack => pack.PackageId == "vanillaexpanded.vfecore"))
			{
				return;
			}

			var tableLightEndTable = GetDatabaseThing("Table_LightEndTable");
			var tableRoyalEndTable = GetDatabaseThing("Table_RoyalEndTable");
			var tableRoyalDresser = GetDatabaseThing("Table_RoyalDresser");

			AddInterchangeableList(BaseGameThingDefs.EndTable, tableLightEndTable, tableRoyalEndTable);
			AddInterchangeableList(BaseGameThingDefs.Dresser, tableRoyalDresser);
		}
	}
}