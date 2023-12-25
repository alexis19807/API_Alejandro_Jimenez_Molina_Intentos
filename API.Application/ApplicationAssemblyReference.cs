using System.Reflection;

namespace Application
{
	//This is to get the assembly and use it in DI class using reflection
	public class ApplicationAssemblyReference
	{
		internal static readonly Assembly Assembly = typeof(ApplicationAssemblyReference).Assembly;
	}
}
