using System.Collections.Generic;
using HarmonyLib;
using Verse;

namespace Replace_Stuff_Compatibility
{
	public class Mod : Verse.Mod
	{
		public Mod(ModContentPack content) : base(content)
		{
#if DEBUG
			Harmony.DEBUG = true;
#endif
			new Harmony("Garethp.rimworld.Replace_Stuff_Compatibility.main").PatchAll();
		}

		[StaticConstructorOnStartup]
		public static class ModStartup
		{
			static ModStartup()
			{
				var patches = new List<AbstractPatch>()
				{
					new CoreUpgrades(),
					new RoyaltyUpgrades(),
					new IdeologyUpgrades(),
					new SaveOurShip2(),
					new VanillaExpandedFurniture(),
					new VanillaExpandedSecurity(), 
					new VanillaExpandedPower(),
					new VanillaFurnitureProduction(),
					new VanillaExpandedSpacer(),
					new VanillaExpandedBooks(),
					new RimEffect(),
					new ArmourRacks(),
					new LWMDeepStorage(),
					new HigherPower()
				};

				patches.ForEach(patch => patch.Patch());
				
				(new MultiModPatch()).Patch();
			}
		}
	}
}