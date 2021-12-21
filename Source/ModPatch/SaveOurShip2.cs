using System.Collections.Generic;
using System.Linq;
using Replace_Stuff.NewThing;
using RimWorld;
using Verse;

namespace Replace_Stuff_Compatibility.ModPatch
{
	public class SaveOurShip2 : AbstractPatch
	{
		protected override string GetRequiredModNames() => "kentington.saveourship2";

		protected override void AddItems()
		{
			var HullFoamWall = GetDatabaseThing("HullFoamWall");
			var Ship_Beam_Unpowered = GetDatabaseThing("Ship_Beam_Unpowered");
			var Ship_Beam = GetDatabaseThing("Ship_Beam");
			var Ship_BeamArchotech_Unpowered = GetDatabaseThing("Ship_BeamArchotech_Unpowered");
			var Ship_BeamArchotech = GetDatabaseThing("Ship_BeamArchotech");
			var ShipAirlock = GetDatabaseThing("ShipAirlock");
			var ShipAirlockArchotech = GetDatabaseThing("ShipAirlockArchotech");

			var ShipInside_PassiveCooler = GetDatabaseThing("ShipInside_PassiveCooler");
			var ShipInside_PassiveCoolerAdvanced = GetDatabaseThing("ShipInside_PassiveCoolerAdvanced");
			var ShipInside_PassiveCoolerArchotech = GetDatabaseThing("ShipInside_PassiveCoolerArchotech");

			var ShipInside_PassiveVent = GetDatabaseThing("ShipInside_PassiveVent");
			var ShipInside_PassiveVentArchotech = GetDatabaseThing("ShipInside_PassiveVentArchotech");

			var ShipInside_SolarGenerator = GetDatabaseThing("ShipInside_SolarGenerator");
			var ShipInside_SolarGeneratorArchotech = GetDatabaseThing("ShipInside_SolarGeneratorArchotech");

			var Ship_Reactor = GetDatabaseThing("Ship_Reactor");
			var ArchotechAntimatterReactor = GetDatabaseThing("ArchotechAntimatterReactor");

			var ShipCombatShieldGenerator = GetDatabaseThing("ShipCombatShieldGenerator");
			var ArchotechShieldGenerator = GetDatabaseThing("ArchotechShieldGenerator");

			var ShipHeatsink = GetDatabaseThing("ShipHeatsink");
			var ShipHeatManifold = GetDatabaseThing("ShipHeatManifold");
			var ShipHeatsinkAntiEntropy = GetDatabaseThing("ShipHeatsinkAntiEntropy");

			var Holodeck_Basic = GetDatabaseThing("Holodeck_Basic");
			var Holodeck_Standard = GetDatabaseThing("Holodeck_Standard");
			var Holodeck_AI = GetDatabaseThing("Holodeck_AI");

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
			AddInterchangeableList(wallsAndSimilar);

			// The ship reactors are interchangeable
			AddInterchangeableList(Ship_Reactor, ArchotechAntimatterReactor);

			// Can upgrade shields to archotech shields
			NewThingReplacement.replacements.Add(new NewThingReplacement.Replacement(
				newItem => newItem == ArchotechShieldGenerator,
				oldItem => oldItem == ShipCombatShieldGenerator
			));
			
			// The small heat sinks are interchangeable
			AddInterchangeableList(ShipHeatsink, ShipHeatManifold, ShipHeatsinkAntiEntropy);

			// The holodecks are interchangeable
			AddInterchangeableList(Holodeck_Basic, Holodeck_Standard, Holodeck_AI);
		}
	}
}