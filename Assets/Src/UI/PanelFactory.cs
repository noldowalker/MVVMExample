using mvvm.example.Open;
using UnityEngine;
using Zenject;

namespace mvvm.example
{
    public class PanelFactory: IFactory<Panels, Transform, Panel>
    {
        DiContainer _container;
        private PanelsList _panelsList;

        public PanelFactory(DiContainer container, PanelsList panelsList)
        {
            _container = container;
            _panelsList = panelsList;
        }

        public Panel Create(Panels type, Transform parent)
        {
            var panelData = _panelsList.Panels.Find(panelData => panelData.panelType == type);
 
            switch (type)
            {
                case Panels.Open: return _container.InstantiatePrefabForComponent<OpenPanel>(panelData.panelPrefub, parent);
                case Panels.Example: return _container.InstantiatePrefabForComponent<ExamplePanel>(panelData.panelPrefub, parent);
            }

            return null;
        }
    }
}