using System.Collections.Generic;
using ArmorRacks.ThingComps;
using ArmorRacks.Things;
using Replace_Stuff.NewThing;
using RimWorld;
using Verse;

namespace Replace_Stuff_Compatibility
{
	public class ArmourRacks : AbstractPatch
	{
		protected override string GetRequiredModNames() => "khamenman.armorracks";

		protected override void AddItems()
		{
			var armourRack = GetDatabaseThing("ArmorRacks_ArmorRack");
			var mechanisedArmourRack = GetDatabaseThing("ArmorRacks_MechanizedArmorRack");
			var mendingArmourRack = GetDatabaseThing("ArmorRacks_MendingArmorRack");

			// When replacing an armour rack, make sure to copy over it's settings, pawn type, body type and owner
			NewThingReplacement.replacements.Add(new NewThingReplacement.Replacement(
				ListContainsThingDef(new List<ThingDef>() {armourRack, mechanisedArmourRack, mendingArmourRack}),
				preAction: (newThing, oldThing) =>
				{
					var newRack = (ArmorRack) newThing;
					var oldRack = (ArmorRack) oldThing;
					
					newRack.Settings.CopyFrom(oldRack.Settings);
					newRack.BodyTypeDef = oldRack.BodyTypeDef;
					newRack.PawnKindDef = oldRack.PawnKindDef;
					
					newRack.TryGetComp<CompAssignableToPawn_ArmorRacks>().TryAssignPawn(oldRack.GetAssignedPawn());
				}));
		}
	}
}