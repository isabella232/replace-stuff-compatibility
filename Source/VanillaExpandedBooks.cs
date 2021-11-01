namespace Replace_Stuff_Compatibility
{
	public class VanillaExpandedBooks: AbstractPatch
	{
		protected override string GetRequiredModNames() => "vanillaexpanded.vbookse";

		protected override void AddItems()
		{
			var writersTable = GetDatabaseThing("VBE_WritersTable");
			var typewritersTable = GetDatabaseThing("VBE_TypewritersTable");
			
			AddInterchangeableWorkbenches(writersTable, typewritersTable);
		}
	}
}