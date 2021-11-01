namespace Replace_Stuff_Compatibility
{
	public class VanillaExpandedPower : AbstractPatch
	{
		protected override string GetRequiredModNames() => "vanillaexpanded.vfepower";

		protected override void AddItems()
		{
			var advancedSolarGenerator = GetDatabaseThing("VFE_AdvancedSolarGenerator");

			var advancedWindTurbine = GetDatabaseThing("VFE_AdvancedWindTurbine");

			var largeWoodGenerator = GetDatabaseThing("VFE_IndustrialWoodFiredGenerator");
			var largeChemfuelGenerator = GetDatabaseThing("VFE_IndustrialChemfuelPoweredGenerator");
			var helixienGenerator = GetDatabaseThing("VPE_HelixienGenerator");
			var largeHelixienGenerator = GetDatabaseThing("VPE_IndustrialHelixienGenerator");

			var largeWatermillGenerator = GetDatabaseThing("VFE_AdvancedWatermillGenerator");

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

			MultiModPatch.PoweredGenerators.Add(largeWoodGenerator);
			MultiModPatch.PoweredGenerators.Add(largeChemfuelGenerator);
			MultiModPatch.PoweredGenerators.Add(helixienGenerator);
			MultiModPatch.PoweredGenerators.Add(largeHelixienGenerator);
			
			MultiModPatch.SolarGenerators.Add(advancedSolarGenerator);
			MultiModPatch.GeothermalGenerators.Add(advancedGeothermalGenerator);
			MultiModPatch.WindTurbines.Add(advancedWindTurbine);
			MultiModPatch.WatermillGenerators.Add(largeWatermillGenerator);
			
			AddInterchangeableList(electricCrematorium, helexienCrematorium);
			AddInterchangeableList(fueledStove, electricStove, helixienStove);
			AddInterchangeableList(biofuelRefinery, helixienRefinery);
		}
	}
}