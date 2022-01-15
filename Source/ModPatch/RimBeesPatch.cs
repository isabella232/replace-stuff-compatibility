using System.Collections.Generic;
using Verse;

namespace Replace_Stuff_Compatibility.ModPatch
{
	public class RimBeesPatch : AbstractPatch
	{
		protected override string GetRequiredModNames() => "sarg.rimbees";

		protected override void AddItems()
		{
			var beehouse = GetDatabaseThing("RB_Beehouse");
			var climatizedBeehouse = GetDatabaseThing("RB_ClimatizedBeehouse");
			var advancedBeehouse = GetDatabaseThing("RB_AdvancedBeehouse");
			var advancedClimatizedBeehouse = GetDatabaseThing("RB_AdvancedClimatizedBeehouse");
			var spacerBeehouse = GetDatabaseThing("RB_SpacerBeehouse");

			AddInterchangeableList(new List<ThingDef>()
			{
				beehouse, 
				climatizedBeehouse,
				advancedBeehouse,
				advancedClimatizedBeehouse,
				spacerBeehouse
			}, preAction: (newThing, oldThing) =>
			{
				var newHouse = (RimBees.Building_Beehouse) newThing;
				var oldHouse = (RimBees.Building_Beehouse) oldThing;
			
				oldHouse.innerContainerDrones.TryTransferAllToContainer(newHouse.innerContainerDrones);
				oldHouse.innerContainerQueens.TryTransferAllToContainer(newHouse.innerContainerQueens);
			});
		}
	}
}