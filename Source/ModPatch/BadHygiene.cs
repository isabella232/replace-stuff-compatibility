namespace Replace_Stuff_Compatibility.ModPatch
{
	public class BadHygiene : AbstractPatch
	{
		protected override string GetRequiredModNames() => "dubwise.dubsbadhygiene";

		protected override void AddItems()
		{
			var basin = GetDatabaseThing("BasinStuff");
			var fountain = GetDatabaseThing("Fountain");

			var latrine = GetDatabaseThing("PitLatrine");
			var toilet = GetDatabaseThing("ToiletStuff");
			var smartToilet = GetDatabaseThing("ToiletAdvStuff");

			var washTub = GetDatabaseThing("WashBucket");
			var bathTub = GetDatabaseThing("BathtubStuff");
			var simpleShower = GetDatabaseThing("ShowerSimple");
			var shower = GetDatabaseThing("ShowerStuff");
			var powerShower = GetDatabaseThing("ShowerAdvStuff");

			var waterButt = GetDatabaseThing("WaterButt");
			var waterTower = GetDatabaseThing("WaterTowerS");
			var largeWaterTower = GetDatabaseThing("WaterTowerL");

			var septicTank = GetDatabaseThing("SewageSepticTank");
			var sewageTreatment = GetDatabaseThing("SewageTreatment");

			AddInterchangeableList(basin, fountain);
			AddInterchangeableList(latrine, toilet, smartToilet);
			AddInterchangeableList(washTub, bathTub, simpleShower, shower, powerShower);
			AddInterchangeableList(waterButt, waterTower, largeWaterTower);
			AddInterchangeableList(septicTank, sewageTreatment);
		}
	}
}