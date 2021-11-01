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

			var geothermalGenerator = GetDatabaseThing("GeothermalGenerator");
			var advancedGeothermalGenerator = GetDatabaseThing("VPE_AdvancedGeothermalGenerator");
			
			var electricCrematorium = GetDatabaseThing("ElectricCrematorium");
			var helexienCrematorium = GetDatabaseThing("VPE_GasCrematorium");
			
			var fueledStove = GetDatabaseThing("FueledStove");
			var electricStove = GetDatabaseThing("ElectricStove");
			var helixienStove = GetDatabaseThing("VPE_GasStove");

			var biofuelRefinery = GetDatabaseThing("BiofuelRefinery");
			var helixienRefinery = GetDatabaseThing("VPE_GasBiofuelRefinery");

			MultiModPatch.Lights.Add(GetDatabaseThing("VPE_GasLamp"));
			MultiModPatch.Lights.Add(GetDatabaseThing("VPE_GasFloodlight"));
			
			MultiModPatch.Smelters.Add(GetDatabaseThing("VPE_GasSmelter"));
			MultiModPatch.Smithys.Add(GetDatabaseThing("VPE_GasSmithy"));

			MultiModPatch.Sunlamps.Add(GetDatabaseThing("VPE_GasSunLamp"));

			AddInterchangeableList(battery, smallBattery, largeBattery, advancedBattery, largeAdvancedBattery);
			AddInterchangeableList(solarGenerator, advancedSolarGenerator);
			AddInterchangeableList(windTurbine, advancedWindTurbine);
			AddInterchangeableList(woodGenerator, largeWoodGenerator, chemfuelGenerator, largeChemfuelGenerator,
				helixienGenerator, largeHelixienGenerator);
			AddInterchangeableList(watermillGenerator, largeWatermillGenerator);
			AddInterchangeableList(electricCrematorium, helexienCrematorium);
			AddInterchangeableList(fueledStove, electricStove, helixienStove);
			AddInterchangeableList(biofuelRefinery, helixienRefinery);
			AddInterchangeableList(geothermalGenerator, advancedGeothermalGenerator);
		}
	}
}