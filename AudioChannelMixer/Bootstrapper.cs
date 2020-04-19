using System.Windows;
using AudioChannelMixer.Modules;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;

namespace AudioChannelMixer
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Window)Shell;
            if (Application.Current.MainWindow != null)
            {
                Application.Current.MainWindow.Show();
            }
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            ModuleCatalog catalog = new ModuleCatalog();

            catalog.AddModule(typeof(AudioChannelMixerModule));

            return catalog;
        }
    }
}
