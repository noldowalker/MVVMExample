using UnityEngine;
using Zenject;

namespace mvvm.example
{
    public abstract class Panel: MonoBehaviour
    {
        public abstract Panels PanelType { get; }
        
        public class Factory : PlaceholderFactory<Panels, Transform, Panel> {}
    }
}