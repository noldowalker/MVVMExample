using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using mvvm.example.Open;
using mvvm.example.ViewModel.Example;
using UniRx;
using UnityEngine;
using Zenject;

namespace mvvm.example
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] 
        private Transform canvas;
        [Inject]
        private ExamplePanelModel.Factory _exampleModelFactory;
        [Inject]
        private ExamplePanelViewModel.Factory _exampleViewModelFactory;
        [Inject]
        private Panel.Factory _panelsFactory;

        private Stack<Panel> _panelsStack;

        public void Awake()
        {
            _panelsStack = new Stack<Panel>();
            var panel = (OpenPanel)_panelsFactory.Create(Panels.Open, canvas);
            _panelsStack.Push(panel);
            panel.OnOpenAction += () => OpenButtonClick();
        }

        public void OpenButtonClick()
        {
            var model = _exampleModelFactory.Create();
            Open(model);
        }

        private void Open(PanelModel panelModel)
        {
            switch (panelModel)
            {
                case ExamplePanelModel panel: OpenExample(panel);
                    break;
            }
        }
        
        private void OpenExample(ExamplePanelModel panelModel)
        {
            var panelViewModel = _exampleViewModelFactory.Create(panelModel);
            var panel = (ExamplePanelView)_panelsFactory.Create(panelModel.PanelType, canvas);
            panel.SetViewModel(panelViewModel);
            _panelsStack.Last().gameObject.SetActive(false);
            _panelsStack.Push(panel);
        }
    }
}
