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
				Replace_Stuff_Compatibility.SaveOurShip2.Patch();
				VanillaExpandedFurniture.Patch();
			}
		}
	}
}