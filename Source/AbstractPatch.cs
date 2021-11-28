using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using JetBrains.Annotations;
using Replace_Stuff.NewThing;
using RimWorld;
using Verse;

namespace Replace_Stuff_Compatibility
{
	public abstract class AbstractPatch
	{
		[NotNull]
		protected abstract string GetRequiredModNames();

		protected abstract void AddItems();

		public void Patch()
		{
			var requiredModName = GetRequiredModNames();

			if (requiredModName != "" &&
			    !LoadedModManager.RunningModsListForReading.Exists(pack => pack.PackageId == requiredModName))
			{
				return;
			}

			AddItems();
		}

		private static Action<Thing, Thing> transferBills = (n, o) =>
		{
			Building_WorkTable newTable = n as Building_WorkTable;
			Building_WorkTable oldTable = o as Building_WorkTable;

			// The base ReplaceStuff already has transferring bills from one table to another for hand/electric tailoring benches
			// and for fueled/electric stove, so we need to skip those
			if ((newTable.def == NewThingDefOf.HandTailoringBench || newTable.def == NewThingDefOf.ElectricTailoringBench) &&
				  (oldTable.def == NewThingDefOf.HandTailoringBench || oldTable.def == NewThingDefOf.ElectricTailoringBench))
				return;
			
			if ((newTable.def == NewThingDefOf.FueledStove || newTable.def == NewThingDefOf.ElectricStove) &&
			    (oldTable.def == NewThingDefOf.FueledStove || oldTable.def == NewThingDefOf.ElectricStove))
				return;
			
			foreach (Bill bill in oldTable.BillStack)
			{
				newTable.BillStack.AddBill(bill);
			}
		};

		protected static ThingDef GetDatabaseThing(string name) => DefDatabase<ThingDef>.GetNamed(name);

		protected static Predicate<ThingDef> ListContainsThingDef(HashSet<ThingDef> list) => list.Contains;

		protected static void AddInterchangeableList(List<ThingDef> items) => AddInterchangeableList(items, null, null);

		protected static void AddInterchangeableList(params ThingDef[] items) =>
			AddInterchangeableList(items.ToList(), null, null);
		
		protected static void AddInterchangeableList(List<ThingDef> items, Action<Thing, Thing> preAction = null,
			Action<Thing, Thing> postAction = null)
		{
			NewThingReplacement.replacements.Add(new NewThingReplacement.Replacement(ListContainsThingDef(new HashSet<ThingDef>(items)),
				preAction: preAction, postAction: postAction));
		}

		protected static void AddInterchangeableWorkbenches(List<ThingDef> items) =>
			AddInterchangeableList(items, preAction: transferBills);
		
		protected static void AddInterchangeableWorkbenches(params ThingDef[] items) =>
			AddInterchangeableWorkbenches(items.ToList());
	}
}