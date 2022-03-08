using Zenject;

namespace mvvm.example
{
    public class ExamplePanelModel: PanelModel
    {
        public string TextFieldFirst { get; private set; }

        private ITextProvider _textProvider;

        public ExamplePanelModel(ITextProvider textProvider)
        {
            PanelType = Panels.Example;
            TextFieldFirst = "";
            _textProvider = textProvider;
        }

        public void RegenerateValueForCurrentField()
        {
            TextFieldFirst = _textProvider.GenerateRandomText();
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