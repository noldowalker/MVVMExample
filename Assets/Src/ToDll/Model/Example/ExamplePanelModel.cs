using System.Collections.Generic;
using UniRx;
using Zenject;

namespace mvvm.example
{
    public class ExamplePanelModel: PanelModel
    {
        public List<ReactiveProperty<string>> TextFields { get; private set; }
        public ReactiveProperty<int> _currentTextFieldIndex { get; private set; }
        private ITextProvider _textProvider;

        public ExamplePanelModel(ITextProvider textProvider)
        {
            TextFields = new List<ReactiveProperty<string>>();
            PanelType = Panels.Example;
            TextFields.Add(new ReactiveProperty<string>("Tab №1 default value"));
            TextFields.Add(new ReactiveProperty<string>("Tab №2 default value"));
            _textProvider = textProvider;
            _currentTextFieldIndex = new ReactiveProperty<int>(0);
        }
        
        public void SwitchCurrentText(int index)
        {
            if (TextFields.Count > index)
                _currentTextFieldIndex.Value = index;
        }

        public void RegenerateValueForCurrentField()
        {
            TextFields[_currentTextFieldIndex.Value].Value = _textProvider.GenerateRandomText();
        }

        public string GetCurrentText()
        {
            return TextFields[_currentTextFieldIndex.Value].Value;
        }

        public bool IsCurrent(ReactiveProperty<string> text)
        {
            return TextFields.IndexOf(text) == _currentTextFieldIndex.Value;
        }

        public class Factory : PlaceholderFactory<ExamplePanelModel>
        {
        }
        
        public class CustomFactory: IFactory<ExamplePanelModel>
        {
            private DiContainer _container;
            private ITextProvider _textProvider;

            public CustomFactory(DiContainer container, ITextProvider textProvider)
            {
                _container = container;
                _textProvider = textProvider;
            }
            
            public ExamplePanelModel Create()
            {
                return new ExamplePanelModel(_textProvider);
            }
        }
    }
    
    
}