namespace Replace_Stuff_Compatibility
{
	public class VanillaExpandedPower : AbstractPatch
	{
		protected override string GetRequiredModNames() => "vanillaexpanded.vfepower";

		protected override void AddItems()
		{
			var battery = GetDatabaseThing("Battery");
			var smallBattery = GetDatabaseThing("VFE_SmallBattery");
			var largeBattery = GetDatabaseThing("VFE_LargeBattery");
			var advancedBattery = GetDatabaseThing("VFE_AdvancedBattery");
			var largeAdvancedBattery = GetDatabaseThing("VFE_LargeAdvancedBattery");

			var solarGenerator = GetDatabaseThing("SolarGenerator");
			var advancedSolarGenerator = GetDatabaseThing("VFE_AdvancedSolarGenerator");

			var windTurbine = GetDatabaseThing("WindTurbine");
			var advancedWindTurbine = GetDatabaseThing("VFE_AdvancedWindTurbine");

			var woodGenerator = GetDatabaseThing("WoodFiredGenerator");
			var largeWoodGenerator = GetDatabaseThing("VFE_IndustrialWoodFiredGenerator");
			var chemfuelGenerator = GetDatabaseThing("ChemfuelPoweredGenerator");
			var largeChemfuelGenerator = GetDatabaseThing("VFE_IndustrialChemfuelPoweredGenerator");
			var helixienGenerator = GetDatabaseThing("VPE_HelixienGenerator");
			var largeHelixienGenerator = GetDatabaseThing("VPE_IndustrialHelixienGenerator");

			var watermillGenerator = GetDatabaseThing("WatermillGenerator");
			var largeWatermillGenerator = GetDatabaseThing("VFE_AdvancedWatermillGenerator");

			AddInterchangeableList(battery, smallBattery, largeBattery, advancedBattery, largeAdvancedBattery);
			AddInterchangeableList(solarGenerator, advancedSolarGenerator);
			AddInterchangeableList(windTurbine, advancedWindTurbine);
			AddInterchangeableList(woodGenerator, largeWoodGenerator, chemfuelGenerator, largeChemfuelGenerator,
				helixienGenerator, largeHelixienGenerator);
			AddInterchangeableList(watermillGenerator, largeWatermillGenerator);
		}
	}
}