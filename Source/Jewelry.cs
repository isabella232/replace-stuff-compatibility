namespace Replace_Stuff_Compatibility
{
	public class Jewelry: AbstractPatch
	{
		protected override string GetRequiredModNames() => "kikohi.jewelry";

		protected override void AddItems()
		{
			MultiModPatch.ArtTables.Add(GetDatabaseThing("LaserTableSculpting"));
		}
	}
}