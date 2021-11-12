namespace Replace_Stuff_Compatibility
{
	public class UtilityColumns: AbstractPatch
	{
		protected override string GetRequiredModNames() => "nephlite.orbitaltradecolumn";

		protected override void AddItems()
		{
			MultiModPatch.Columns.Add(GetDatabaseThing("LightColumnMod"));
			MultiModPatch.Columns.Add(GetDatabaseThing("DarkColumnMod"));
			MultiModPatch.Columns.Add(GetDatabaseThing("DetColumnMod"));
			MultiModPatch.Columns.Add(GetDatabaseThing("FlameColumnMod"));
			MultiModPatch.Columns.Add(GetDatabaseThing("GraveColumnMod"));
			MultiModPatch.Columns.Add(GetDatabaseThing("SunColumnMod"));
			MultiModPatch.Columns.Add(GetDatabaseThing("IceColumnMod"));
			
			MultiModPatch.Lights.Add(GetDatabaseThing("LightColumnMod"));
			MultiModPatch.Lights.Add(GetDatabaseThing("DarkColumnMod"));
			
			MultiModPatch.Sunlamps.Add(GetDatabaseThing("SunColumnMod"));
		}
	}
}