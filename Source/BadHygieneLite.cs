namespace Replace_Stuff_Compatibility
{
	public class BadHygieneLite: AbstractPatch
	{
		protected override string GetRequiredModNames() => "dubwise.dubsbadhygiene.lite";

		protected override void AddItems()
		{
			var latrine = GetDatabaseThing("PitLatrine");
			var toilet = GetDatabaseThing("ToiletStuff");
			var smartToilet = GetDatabaseThing("ToiletAdvStuff");
			
			var washTub = GetDatabaseThing("WashBucket");
			var bathTub = GetDatabaseThing("BathtubStuff");
			var simpleShower = GetDatabaseThing("ShowerSimple");
			var shower = GetDatabaseThing("ShowerStuff");
			var powerShower = GetDatabaseThing("ShowerAdvStuff");
			
			AddInterchangeableList(latrine, toilet, smartToilet);
			AddInterchangeableList(washTub, bathTub, simpleShower, shower, powerShower);
		}
	}
}