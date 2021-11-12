namespace Replace_Stuff_Compatibility
{
	public class HigherPower: AbstractPatch
	{
		protected override string GetRequiredModNames() => "leion247612.higherhpower";

		protected override void AddItems()
		{
			MultiModPatch.PoweredGenerators.Add(GetDatabaseThing("ChemfuelPoweredGenerator_II"));
			MultiModPatch.SolarGenerators.Add(GetDatabaseThing("SolarGenerator_II"));
		}
	}
}