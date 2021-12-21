namespace Replace_Stuff_Compatibility.CorePatch
{
	public class CoreUpgrades: AbstractPatch
	{
		protected override string GetRequiredModNames() => "";

		protected override void AddItems()
		{
			var researchBench = GetDatabaseThing("SimpleResearchBench");
			var hitechResearchBench = GetDatabaseThing("HiTechResearchBench");
			
			MultiModPatch.Lights.Add(GetDatabaseThing("TorchLamp"));
			MultiModPatch.Lights.Add(GetDatabaseThing("StandingLamp"));
			MultiModPatch.Lights.Add(GetDatabaseThing("StandingLamp_Red"));
			MultiModPatch.Lights.Add(GetDatabaseThing("StandingLamp_Green"));
			MultiModPatch.Lights.Add(GetDatabaseThing("StandingLamp_Blue"));

			AddInterchangeableList(researchBench, hitechResearchBench);
		}
	}
}