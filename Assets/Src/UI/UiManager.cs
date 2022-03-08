using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using mvvm.example.Open;
using UnityEngine;
using Zenject;

namespace mvvm.example
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private Transform canvas;
        [Inject]
        private ExamplePanelModel.Factory _exampleModelFactory;
        [Inject]
        private Panel.Factory _panelsFactory;

        private List<Panel> _panelsStack;

        public void Awake()
        {
            _panelsStack = new List<Panel>();
            var panel = (OpenPanel)_panelsFactory.Create(Panels.Open, canvas);
            _panelsStack.Add(panel);
            panel.OnOpenAction += () => OpenButtonClick();
        }

        public void OpenButtonClick()
        {
            var model = _exampleModelFactory.Create();
            Open(model);
        }

        private void Open(ExamplePanelModel panelModel)
        {
            panelModel.RegenerateValueForCurrentField();
            var panel = _panelsFactory.Create(panelModel.PanelType, canvas);
            _panelsStack.Last().gameObject.SetActive(false);
            _panelsStack.Add(panel);
            panel.gameObject.SetActive(true);
        }
    }
}
