using HarmonyLib;
using RimWorld;
using Verse;

namespace Replace_Stuff_Compatibility
{
	public class InterchangableBridges
	{
		[HarmonyPatch(typeof(GenConstruct), "CanBuildOnTerrain")]
		class BridgeCanReplaceBridge
		{
			public static void Postfix(BuildableDef entDef,
				IntVec3 c,
				Map map,
				Rot4 rot,
				Thing thingToIgnore,
				ThingDef stuffDef, ref bool __result)
			{
				if (__result) return;
				__result = typeof(TerrainDef).IsAssignableFrom(entDef.GetType()) && c.GetTerrain(map).bridge;
			}
		}
	}
}