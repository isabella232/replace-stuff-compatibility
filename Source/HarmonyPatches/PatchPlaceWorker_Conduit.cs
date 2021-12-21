using System.Collections.Generic;
using HarmonyLib;
using Replace_Stuff.NewThing;
using RimWorld;
using Verse;

namespace Replace_Stuff_Compatibility.HarmonyPatches
{
	[HarmonyPatch(typeof(PlaceWorker_Conduit), "AllowsPlacing")]

	public class PatchPlaceWorker_Conduit
	{
		public static void Postfix(ref AcceptanceReport __result, BuildableDef checkingDef,
			IntVec3 loc,
			Rot4 rot,
			Map map)
		{
			if (__result.Accepted) return;

			List<Thing> thingList = loc.GetThingList(map);
			for (int index = 0; index < thingList.Count; ++index)
			{
				if (thingList[index].def.EverTransmitsPower &&
				    !(checkingDef is ThingDef checkingD && checkingD.CanReplace(thingList[index].def)))
				{
					__result = (AcceptanceReport) false;
					return;
				}

				if (thingList[index].def.entityDefToBuild != null &&
				    thingList[index].def.entityDefToBuild is ThingDef entityDefToBuild && entityDefToBuild.EverTransmitsPower)
				{
					__result = (AcceptanceReport) false;
					return;
				}
			}

			__result = (AcceptanceReport) true;
		}
	}
}