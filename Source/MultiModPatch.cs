using System.Collections.Generic;
using Verse;

namespace Replace_Stuff_Compatibility
{
	public class MultiModPatch : AbstractPatch
	{
		protected override string GetRequiredModNames() => "";

		public static List<ThingDef> Smelters = new List<ThingDef>() {GetDatabaseThing("ElectricSmelter")};

		public static List<ThingDef> Smithys = new List<ThingDef>()
			{GetDatabaseThing("FueledSmithy"), GetDatabaseThing("ElectricSmithy")};

		public static List<ThingDef> Lights = new List<ThingDef>() { };

		protected override void AddItems()
		{
			AddInterchangeableList(Smelters);
			AddInterchangeableList(Smithys);
			AddInterchangeableList(Lights);
		}
	}
}