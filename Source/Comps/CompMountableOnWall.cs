using Verse;

namespace Replace_Stuff_Compatibility.Comps
{
	public class CompProperties_MountableOnWall : CompProperties
	{
		public CompProperties_MountableOnWall()
		{
			this.compClass = typeof(CompMountableOnWall);
		}
	}
	public class CompMountableOnWall : ThingComp
	{

	}
}