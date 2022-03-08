using mvvm.example;
using UnityEngine;
using Zenject;

public class ExampleSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        ExampleDependencyInstaller.Install(Container);
        Container.Bind<PanelsList>().FromScriptableObjectResource("ScriptableObjects/PanelsList").AsSingle();
        Container.BindFactory<Panels, Transform, Panel, Panel.Factory>().FromFactory<PanelFactory>();
    }
}