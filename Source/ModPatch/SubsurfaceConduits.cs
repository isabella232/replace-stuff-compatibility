namespace Replace_Stuff_Compatibility.ModPatch
{
	public class SubsurfaceConduits: AbstractPatch
	{
		protected override string GetRequiredModNames() => "murmur.subsurfaceconduit";

		protected override void AddItems()
		{
			MultiModPatch.PowerConduits.Add(GetDatabaseThing("MUR_SubsurfaceConduit"));
		}
	}
}