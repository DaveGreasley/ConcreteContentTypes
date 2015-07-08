using ConcreteContentTypes.Core.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Compilation;

[assembly: PreApplicationStartMethod(typeof(ConcreteContentTypes.Core.DynamicLoading.Initializer), "Initialize")]


namespace ConcreteContentTypes.Core.DynamicLoading
{
	public static class Initializer
	{
		public static void Initialize()
		{
			ModelAssemblyLoader.Current.ReloadAssembly();

			BuildManager.AddReferencedAssembly(ModelAssemblyLoader.Current.ModelAssembly);

			AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
		}

		static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			if (args.Name == ConcreteSettings.Current.AssemblyName)
			{
				return ModelAssemblyLoader.Current.ModelAssembly;
			}

			return null;
		}
	}

	public class ModelAssemblyLoader
	{
		#region Singleton

		static ModelAssemblyLoader _current = null;
		public static ModelAssemblyLoader Current
		{
			get
			{
				if (_current == null)
					_current = new ModelAssemblyLoader();

				return _current;
			}
		}

		#endregion

		public AppDomain ModelAppDomain { get; private set; }
		public Assembly ModelAssembly { get; private set; }

		public ModelAssemblyLoader()
		{

		}

		public void ReloadAssembly()
		{
			if (this.ModelAppDomain != null)
				UnloadAppDomain();

			AppDomainSetup modelDomainSetup = new AppDomainSetup();
			AppDomain modelDomain = AppDomain.CreateDomain("ConcreteModelDomain", null, modelDomainSetup);

			byte[] modelAssemblyBytes = File.ReadAllBytes(
				AppDomain.CurrentDomain.BaseDirectory + "\\" +
				ConcreteSettings.Current.AssemblyOutputDirectory + "\\" +
				ConcreteSettings.Current.AssemblyName + ".dll");

			this.ModelAssembly = Assembly.Load(modelAssemblyBytes);

			this.ModelAppDomain = modelDomain;
		}

		private void UnloadAppDomain()
		{
			AppDomain.Unload(this.ModelAppDomain);

			this.ModelAssembly = null;
			this.ModelAppDomain = null;
		}
	}
}
