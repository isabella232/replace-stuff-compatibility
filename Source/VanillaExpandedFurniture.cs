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
			var tableLightEndTable = GetDatabaseThing("Table_LightEndTable");
			var tableRoyalEndTable = GetDatabaseThing("Table_RoyalEndTable");
			var tableRoyalDresser = GetDatabaseThing("Table_RoyalDresser");

			var campfire = GetDatabaseThing("Campfire");
			var stoneCampfire = GetDatabaseThing("Stone_Campfire");

			var oldRadio = GetDatabaseThing("Radio_Industrial");
			var radio = GetDatabaseThing("Radio_Spacer");
			
			MultiModPatch.Lights.Add(GetDatabaseThing("Light_ModernLamp"));
			MultiModPatch.Lights.Add(GetDatabaseThing("Light_Streetlamp"));
			MultiModPatch.Lights.Add(GetDatabaseThing("Table_LightEndTable"));

			AddInterchangeableList(BaseGameThingDefs.EndTable, tableLightEndTable, tableRoyalEndTable);
			AddInterchangeableList(BaseGameThingDefs.Dresser, tableRoyalDresser);
			AddInterchangeableList(campfire, stoneCampfire);
			AddInterchangeableList(oldRadio, radio);
		}
	}
}