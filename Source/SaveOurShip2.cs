using System;
using System.Collections.Generic;
using System.Linq;
using Replace_Stuff.NewThing;
using RimWorld;
using Verse;

namespace Replace_Stuff_Compatibility
{
	public class SaveOurShip2
	{ 
		private static Predicate<ThingDef> ListContainsThingDef(List<ThingDef> list)
		{
			return product => list.Exists(n => n == product);
		}

		public static void Patch()
		{
			if (!LoadedModManager.RunningModsListForReading.Exists(pack => pack.PackageId == "kentington.saveourship2"))
			{
				return;
			}
			
			var HullFoamWall = DefDatabase<ThingDef>.GetNamed("HullFoamWall");
			var Ship_Beam_Unpowered = DefDatabase<ThingDef>.GetNamed("Ship_Beam_Unpowered");
			var Ship_Beam = DefDatabase<ThingDef>.GetNamed("Ship_Beam");
			var Ship_BeamArchotech_Unpowered = DefDatabase<ThingDef>.GetNamed("Ship_BeamArchotech_Unpowered");
			var Ship_BeamArchotech = DefDatabase<ThingDef>.GetNamed("Ship_BeamArchotech");
			var ShipAirlock = DefDatabase<ThingDef>.GetNamed("ShipAirlock");
			var ShipAirlockArchotech = DefDatabase<ThingDef>.GetNamed("ShipAirlockArchotech");
			
			var ShipInside_PassiveCooler = DefDatabase<ThingDef>.GetNamed("ShipInside_PassiveCooler");
			var ShipInside_PassiveCoolerAdvanced = DefDatabase<ThingDef>.GetNamed("ShipInside_PassiveCoolerAdvanced");
			var ShipInside_PassiveCoolerArchotech = DefDatabase<ThingDef>.GetNamed("ShipInside_PassiveCoolerArchotech");
			
			var ShipInside_PassiveVent = DefDatabase<ThingDef>.GetNamed("ShipInside_PassiveVent");
			var ShipInside_PassiveVentArchotech = DefDatabase<ThingDef>.GetNamed("ShipInside_PassiveVentArchotech");
			
			var ShipInside_SolarGenerator = DefDatabase<ThingDef>.GetNamed("ShipInside_SolarGenerator");
			var ShipInside_SolarGeneratorArchotech = DefDatabase<ThingDef>.GetNamed("ShipInside_SolarGeneratorArchotech");
			
			var Ship_Reactor = DefDatabase<ThingDef>.GetNamed("Ship_Reactor");
			var ArchotechAntimatterReactor = DefDatabase<ThingDef>.GetNamed("ArchotechAntimatterReactor");

			var ShipCombatShieldGenerator = DefDatabase<ThingDef>.GetNamed("ShipCombatShieldGenerator");
			var ArchotechShieldGenerator = DefDatabase<ThingDef>.GetNamed("ArchotechShieldGenerator");
			
			var ShipHeatsink = DefDatabase<ThingDef>.GetNamed("ShipHeatsink");
			var ShipHeatManifold = DefDatabase<ThingDef>.GetNamed("ShipHeatManifold");
			var ShipHeatsinkAntiEntropy = DefDatabase<ThingDef>.GetNamed("ShipHeatsinkAntiEntropy");
			
			var Holodeck_Basic = DefDatabase<ThingDef>.GetNamed("Holodeck_Basic");
			var Holodeck_Standard = DefDatabase<ThingDef>.GetNamed("Holodeck_Standard");
			var Holodeck_AI = DefDatabase<ThingDef>.GetNamed("Holodeck_AI");
			
			var walls = new List<ThingDef>()
			{
				HullFoamWall,
				Ship_Beam_Unpowered,
				Ship_Beam,
				Ship_BeamArchotech_Unpowered,
				Ship_BeamArchotech,
				ShipAirlock,
				ShipAirlockArchotech
			};

			var vents = new List<ThingDef>()
			{
				ShipInside_PassiveVent,
				ShipInside_PassiveVentArchotech
			};

			var radiators = new List<ThingDef>()
			{
				ShipInside_PassiveCooler,
				ShipInside_PassiveCoolerAdvanced,
				ShipInside_PassiveCoolerArchotech
			};

			var solarGenerators = new List<ThingDef>()
			{
				ShipInside_SolarGenerator,
				ShipInside_SolarGeneratorArchotech
			};

			var reactors = new List<ThingDef>()
			{
				Ship_Reactor,
				ArchotechAntimatterReactor
			};

			var heatSinks = new List<ThingDef>()
			{
				ShipHeatsink,
				ShipHeatManifold,
				ShipHeatsinkAntiEntropy
			};

			var holodecks = new List<ThingDef>()
			{
				Holodeck_Basic,
				Holodeck_Standard,
				Holodeck_AI
			};
			
			var wallsAndSimilar = walls
				.Concat(vents)
				.Concat(radiators)
				.Concat(solarGenerators)
				.ToList();

			// When replacing radiators with radiators, maintain the target temperature
			NewThingReplacement.replacements.Add(new NewThingReplacement.Replacement(
				building => typeof(Building_Radiator).IsAssignableFrom(building.thingClass),
				postAction: (newRadiator, oldRadiator) =>
				{
					((Building_Radiator) newRadiator).compTempControl.targetTemperature =
						((Building_Radiator) oldRadiator).compTempControl.targetTemperature;
				}
			));

			// When replacing vents, maintain the target temperature
			NewThingReplacement.replacements.Add(new NewThingReplacement.Replacement(
				building => typeof(Building_ShipVent).IsAssignableFrom(building.thingClass),
				postAction: (newVent, oldVent) =>
				{
					((Building_ShipVent) newVent).compTempControl.targetTemperature =
						((Building_ShipVent) oldVent).compTempControl.targetTemperature;

					((Building_ShipVent) newVent).heatWithPower =
						((Building_ShipVent) oldVent).heatWithPower;
				}
			));

			// All Wall-Like items should be interchangeable
			NewThingReplacement.replacements.Add(new NewThingReplacement.Replacement(
				ListContainsThingDef(wallsAndSimilar)
			));

			// The ship reactors are interchangeable
			NewThingReplacement.replacements.Add(new NewThingReplacement.Replacement(
				ListContainsThingDef(reactors)
			));

			// Can upgrade shields to archotech shields
			NewThingReplacement.replacements.Add(new NewThingReplacement.Replacement(
				newItem => newItem == ArchotechShieldGenerator,
				oldItem => oldItem == ShipCombatShieldGenerator
			));

			// The small heat sinks are interchangeable
			NewThingReplacement.replacements.Add(new NewThingReplacement.Replacement(
				ListContainsThingDef(heatSinks)
			));

			// The holodecks are interchangeable
			NewThingReplacement.replacements.Add(new NewThingReplacement.Replacement(
				ListContainsThingDef(holodecks)
			));
		}
	}
}