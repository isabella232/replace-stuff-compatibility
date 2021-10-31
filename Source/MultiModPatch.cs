using System.Collections.Generic;
using Replace_Stuff.NewThing;
using RimWorld;
using Verse;

namespace Replace_Stuff_Compatibility
{
	public class MultiModPatch : AbstractPatch
	{
		protected override string GetRequiredModNames() => "";

		public static List<ThingDef> Smelters = new List<ThingDef>() {GetDatabaseThing("ElectricSmelter")};

		public static List<ThingDef> Smithys = new List<ThingDef>()
			{GetDatabaseThing("FueledSmithy"), GetDatabaseThing("ElectricSmithy")};

		public static List<ThingDef> Lights = new List<ThingDef>() { };

		public static List<ThingDef> Sunlamps = new List<ThingDef>() {GetDatabaseThing("SunLamp")};

		public static List<ThingDef> EndTables = new List<ThingDef>() {GetDatabaseThing("EndTable")};

		public static List<ThingDef> Dressers = new List<ThingDef>() {GetDatabaseThing("Dresser")};

		public static List<ThingDef> TVs = new List<ThingDef>()
		{
			GetDatabaseThing("TubeTelevision"), GetDatabaseThing("FlatscreenTelevision"),
			GetDatabaseThing("MegascreenTelevision")
		};

		protected override void AddItems()
		{
			// Allow all "plant growable items" to replace each other, and when they do attempt to set the growing plant type
			NewThingReplacement.replacements.Add(new NewThingReplacement.Replacement(
				building => typeof(IPlantToGrowSettable).IsAssignableFrom(building.thingClass),
				postAction: (newItem, oldItem) =>
				{
					((IPlantToGrowSettable) newItem).SetPlantDefToGrow(((IPlantToGrowSettable) oldItem).GetPlantDefToGrow());
				}));

			AddInterchangeableWorkbenches(Smelters);
			AddInterchangeableWorkbenches(Smithys);
			AddInterchangeableList(Lights);
			AddInterchangeableList(Sunlamps);
			AddInterchangeableList(EndTables);
			AddInterchangeableList(Dressers);
			AddInterchangeableList(TVs);
		}
	}
}