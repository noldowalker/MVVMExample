using mvvm.example.ViewModel.Example;
using UnityEngine;
using Zenject;

namespace mvvm.example
{
    public class ExampleDependencyInstaller: Installer<ExampleDependencyInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ITextProvider>().To<ExampleTextProvider>().AsSingle();
            Container.BindFactory<ExamplePanelModel, ExamplePanelModel.Factory>().FromFactory<ExamplePanelModel.CustomFactory>();
            Container.BindFactory<ExamplePanelModel, ExamplePanelViewModel, ExamplePanelViewModel.Factory>().FromFactory<ExamplePanelViewModel.CustomFactory>();
        }
    }
}