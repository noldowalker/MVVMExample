using UnityEngine;
using Zenject;

namespace mvvm.example
{
    public class DependencyInstaller : Installer<DependencyInstaller>
    {
        public override void InstallBindings()
        {
            Debug.Log("INSTALLING BINDINGS");
            Container.BindInterfacesTo<ExampleModelSpawner>().AsSingle();
            Container.Bind<ITextInstaller>().To<ExampleTextInstaller>().AsSingle();
            Container.BindFactory<ExampleModel, ExampleModel.Factory>();
        }
    }
}