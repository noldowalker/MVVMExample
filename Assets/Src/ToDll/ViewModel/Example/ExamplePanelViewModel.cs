using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UniRx;
using UnityEngine;
using UnityWeld.Binding;
using Zenject;

namespace mvvm.example.ViewModel.Example
{
    public class ExamplePanelViewModel
    {
        public Action<string> OnTextChange;
        
        private int _currentFieldIndex;
        private ExamplePanelModel _model;
        
        public void SetModel(ExamplePanelModel model)
        {
            _model = model;
            _currentFieldIndex = 0;
            
            _model._currentTextFieldIndex
                .ObserveEveryValueChanged(x => x.Value)
                .Subscribe(index =>
                {
                    Refresh();
                });
            
            _model.TextFields
                .ForEach(reactiveText =>
                {
                    reactiveText
                        .ObserveEveryValueChanged(x => x.Value)
                        .Where(s => _model.IsCurrent(reactiveText))
                        .Subscribe(s =>
                        {
                            Refresh();
                        });
                });
        }

        public int GetTabsCount()
        {
            return _model.TextFields.Count;
        }
        
        public void RegenerateValueForCurrentField()
        {
            _model.RegenerateValueForCurrentField();
        }
        
        public void SwitchCurrentText(int index)
        {
            _model.SwitchCurrentText(index);
        }
        
        public void Refresh()
        {
            OnTextChange?.Invoke(_model.GetCurrentText());
        }
        
        public class Factory : PlaceholderFactory<ExamplePanelModel, ExamplePanelViewModel>
        {
        }
        
        public class CustomFactory: IFactory<ExamplePanelModel, ExamplePanelViewModel>
        {
            private DiContainer _container;

            public CustomFactory(DiContainer container)
            {
                _container = container;
            }
            
            public ExamplePanelViewModel Create(ExamplePanelModel model)
            {
                var viewModel = new ExamplePanelViewModel();
                viewModel.SetModel(model);
                return viewModel;
            }
        }
    }
}