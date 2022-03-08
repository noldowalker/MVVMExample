using UnityEngine;
using Zenject;

namespace mvvm.example
{
    public class ExampleDependencyInstaller: Installer<ExampleDependencyInstaller>
    {
        public override void InstallBindings()
        {
            Debug.Log("Install Bindings");
            Container.Bind<ITextProvider>().To<ExampleTextProvider>().AsSingle();
            Container.BindFactory<ExamplePanelModel, ExamplePanelModel.Factory>().FromFactory<ExamplePanelModel.CustomFactory>();
        }
    }
}