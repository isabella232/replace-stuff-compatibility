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

			foreach (Bill bill in oldTable.BillStack)
			{
				newTable.BillStack.AddBill(bill);
			}
		};

		protected static ThingDef GetDatabaseThing(string name) => DefDatabase<ThingDef>.GetNamed(name);

		protected static Predicate<ThingDef> ListContainsThingDef(List<ThingDef> list)
		{
			return product => list.Exists(n => n == product);
		}

		protected static void AddInterchangeableList(List<ThingDef> items) => AddInterchangeableList(items, null, null);

		protected static void AddInterchangeableList(params ThingDef[] items) =>
			AddInterchangeableList(items.ToList(), null, null);
		
		protected static void AddInterchangeableList(List<ThingDef> items, Action<Thing, Thing> preAction = null,
			Action<Thing, Thing> postAction = null)
		{
			NewThingReplacement.replacements.Add(new NewThingReplacement.Replacement(ListContainsThingDef(items),
				preAction: preAction, postAction: postAction));
		}

		protected static void AddInterchangeableWorkbenches(List<ThingDef> items) =>
			AddInterchangeableList(items, preAction: transferBills);
		
		protected static void AddInterchangeableWorkbenches(params ThingDef[] items) =>
			AddInterchangeableWorkbenches(items.ToList());
	}
}