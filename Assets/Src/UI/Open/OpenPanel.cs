using System;

namespace mvvm.example.Open
{
    public class OpenPanel: Panel
    {
        public override Panels PanelType => Panels.Open;

        public Action OnOpenAction;

        public void OnOpen()
        {
            OnOpenAction?.Invoke();
        }
    }
}