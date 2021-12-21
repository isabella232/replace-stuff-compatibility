namespace Replace_Stuff_Compatibility.ModPatch
{
	public class UndergroundPowerConduit: AbstractPatch
	{
		protected override string GetRequiredModNames() => "owlchemist.undergroundpowerconduits";

		protected override void AddItems()
		{
			MultiModPatch.PowerConduits.Add(GetDatabaseThing("PowerConduitInvisible"));
		}
	}
}