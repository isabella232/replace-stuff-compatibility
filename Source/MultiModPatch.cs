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

		public static List<ThingDef> MachiningTables = new List<ThingDef>() {GetDatabaseThing("TableMachining")};

		public static List<ThingDef> Stoves = new List<ThingDef>()
			{GetDatabaseThing("FueledStove"), GetDatabaseThing("ElectricStove")};

		public static List<ThingDef> TailoringBenches = new List<ThingDef>()
			{GetDatabaseThing("HandTailoringBench"), GetDatabaseThing("ElectricTailoringBench")};

		public static List<ThingDef> Lights = new List<ThingDef>() { };

		public static List<ThingDef> Sunlamps = new List<ThingDef>() {GetDatabaseThing("SunLamp")};

		public static List<ThingDef> EndTables = new List<ThingDef>() {GetDatabaseThing("EndTable")};

		public static List<ThingDef> Dressers = new List<ThingDef>() {GetDatabaseThing("Dresser")};

		public static List<ThingDef> PoweredGenerators = new List<ThingDef>()
			{GetDatabaseThing("WoodFiredGenerator"), GetDatabaseThing("ChemfuelPoweredGenerator")};

		public static List<ThingDef> SolarGenerators = new List<ThingDef>() {GetDatabaseThing("SolarGenerator")};
		
		public static List<ThingDef> TVs = new List<ThingDef>()
		{
			GetDatabaseThing("TubeTelevision"), GetDatabaseThing("FlatscreenTelevision"),
			GetDatabaseThing("MegascreenTelevision")
		};

		public static List<ThingDef> Fabricators = new List<ThingDef>() {GetDatabaseThing("FabricationBench")};

		public static List<ThingDef> Wardrobes = new List<ThingDef>() { };

		public static List<ThingDef> ArtTables = new List<ThingDef>() { GetDatabaseThing("TableSculpting") };

		public static List<ThingDef> Columns = new List<ThingDef>() { GetDatabaseThing("Column") };

		protected override void AddItems()
		{
			// Allow all "plant growable items" to replace each other, and when they do attempt to set the growing plant type
			NewThingReplacement.replacements.Add(new NewThingReplacement.Replacement(
				building => typeof(IPlantToGrowSettable).IsAssignableFrom(building.thingClass),
				postAction: (newItem, oldItem) =>
				{
					((IPlantToGrowSettable) newItem).SetPlantDefToGrow(((IPlantToGrowSettable) oldItem).GetPlantDefToGrow());
				}));

			NewThingReplacement.replacements.Add(new NewThingReplacement.Replacement(
				building => typeof(Building_Battery).IsAssignableFrom(building.thingClass)));

			// We can use placeWorkers and comps to check what kind of power is being generated so that we don't have to worry
			// about each item individually
			NewThingReplacement.replacements.Add(new NewThingReplacement.Replacement(
				building => building.placeWorkers?.Any(placeWorker =>
					placeWorker == typeof(PlaceWorker_WatermillGenerator)) ?? false));
			NewThingReplacement.replacements.Add(new NewThingReplacement.Replacement(
				building => building.placeWorkers?.Any(placeWorker =>
					placeWorker == typeof(PlaceWorker_WindTurbine)) ?? false));
			NewThingReplacement.replacements.Add(new NewThingReplacement.Replacement(
				building => building.placeWorkers?.Any(placeWorker =>
					placeWorker == typeof(PlaceWorker_OnSteamGeyser)) ?? false));

			AddInterchangeableWorkbenches(Smelters);
			AddInterchangeableWorkbenches(Smithys);
			AddInterchangeableList(Lights);
			AddInterchangeableList(Sunlamps);
			AddInterchangeableList(EndTables);
			AddInterchangeableList(Dressers);
			AddInterchangeableList(TVs);
			AddInterchangeableList(PoweredGenerators);
			AddInterchangeableList(SolarGenerators);
			AddInterchangeableList(Fabricators);
			AddInterchangeableList(Wardrobes);
			AddInterchangeableList(TailoringBenches);
			AddInterchangeableList(Stoves);
			AddInterchangeableList(MachiningTables);
			AddInterchangeableList(ArtTables);
			AddInterchangeableList(Columns);
		}
	}
}