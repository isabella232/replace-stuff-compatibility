namespace Replace_Stuff_Compatibility.CorePatch
{
	public class RoyaltyUpgrades: AbstractPatch
	{
		protected override string GetRequiredModNames() => "ludeon.rimworld.royalty";

		protected override void AddItems()
		{
			var brazier = GetDatabaseThing("Brazier");
			var darklightBrazier = GetDatabaseThing("DarklightBrazier");
			
			AddInterchangeableList(brazier, darklightBrazier);
		}
	}
}