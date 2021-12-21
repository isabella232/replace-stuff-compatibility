namespace Replace_Stuff_Compatibility.ModPatch
{
	public class RimEffect: AbstractPatch
	{
		protected override string GetRequiredModNames() => "rimeffect.core";

		protected override void AddItems()
		{
			var bedsideTable = GetDatabaseThing("RE_PrefabBedsideTable");
			var bedsideTableWithLamp = GetDatabaseThing("RE_PrefabBedsideTableLamp");
			
			MultiModPatch.SolarGenerators.Add(GetDatabaseThing("PrefabSolarCollectors"));
			MultiModPatch.PoweredGenerators.Add(GetDatabaseThing("RE_PrefabGenerator"));
			
			MultiModPatch.EndTables.Add(GetDatabaseThing("RE_PrefabEndTable"));
			MultiModPatch.EndTables.Add(GetDatabaseThing("RE_PrefabEndTableWithLamp"));
			MultiModPatch.Dressers.Add(GetDatabaseThing("RE_PrefabDresser"));
			MultiModPatch.Wardrobes.Add(GetDatabaseThing("RE_PrefabWardrobe"));
			
			MultiModPatch.TVs.Add(GetDatabaseThing("RE_PrefabTelevision"));
			
			MultiModPatch.Lights.Add(GetDatabaseThing("RE_PrefabStandingLamp"));
			
			MultiModPatch.Columns.Add(GetDatabaseThing("RE_PrefabColumn"));
			
			AddInterchangeableList(bedsideTable, bedsideTableWithLamp);
		}
	}
}