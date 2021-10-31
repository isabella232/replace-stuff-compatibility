namespace Replace_Stuff_Compatibility
{
	public class VanillaFurnitureProduction: AbstractPatch
	{
		protected override string GetRequiredModNames() => "vanillaexpanded.vfeproduction";

		protected override void AddItems()
		{
			var stoneCutter = GetDatabaseThing("TableStonecutter");
			var electricStoneCutter = GetDatabaseThing("VFE_TableStonecutterElectric");

			var fabricationBench = GetDatabaseThing("FabricationBench");
			var assemblyBench = GetDatabaseThing("VFE_ComponentFabricationBench");

			var butchersTable = GetDatabaseThing("TableButcher");
			var electricButchersTable = GetDatabaseThing("VFE_TableButcherElectric");

			var drugLab = GetDatabaseThing("DrugLab");
			var electricDrugLab = GetDatabaseThing("VFE_TableDrugLabElectric");
			
			MultiModPatch.Smelters.Add(GetDatabaseThing("VFE_FueledSmelter"));

			AddInterchangeableWorkbenches(stoneCutter, electricStoneCutter);
			AddInterchangeableWorkbenches(fabricationBench, assemblyBench);
			AddInterchangeableWorkbenches(butchersTable, electricButchersTable);
			AddInterchangeableWorkbenches(drugLab, electricDrugLab);
		}
	}
}