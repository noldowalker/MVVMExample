using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using mvvm.example.ViewModel.Example;
using UnityEngine;
using UnityEngine.UI;
using UnityWeld.Binding;

namespace mvvm.example
{
    [Binding]
    public class ExamplePanelView: Panel, INotifyPropertyChanged
    {
        public override Panels PanelType => Panels.Example;
        [SerializeField] 
        private ExampleTabButton _tabButtonPrefub;
        [SerializeField] 
        private Transform _tabsContainer;
        
        private ExamplePanelViewModel _viewModel;
        
        private string text = "";
        
        [Binding]
        public string Text
        {
            get => text;
            set
            {
                if (text == value)
                {
                    return;
                }

                text = value;

                OnPropertyChanged("Text");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        public void SetViewModel(ExamplePanelViewModel model)
        {
            _viewModel = model;
            for (int i = 0; i < _viewModel.GetTabsCount(); i++)
            {
                var button = Instantiate(_tabButtonPrefub, _tabsContainer);
                button.SetTabIndex(i);
                button.ButtonClickActions += SetTabAsCurrent;
            }

            _viewModel.OnTextChange += SetText;
            _viewModel.Refresh();
        }
        
        [Binding]
        public void SetRandomTextForCurrentTab()
        {
            if (_viewModel == null)
                return;
            
            _viewModel.RegenerateValueForCurrentField();
        }

        public void SetTabAsCurrent(int index)
        {
            _viewModel.SwitchCurrentText(index);
        }

        public void SetText(string value)
        {
            Text = value;
        }

        private void OnDestroy()
        {
            _viewModel.OnTextChange -= SetText;
        }
        
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}