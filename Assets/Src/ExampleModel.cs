using Zenject;

namespace mvvm.example
{
    public class ExampleModel
    {
        private ITextInstaller _textInstaller;
        public string ExampleText;

        public ExampleModel(ITextInstaller textInstaller)
        {
            _textInstaller = textInstaller;
            ExampleText = textInstaller.GetRandomText();
        }
        
        public class Factory : PlaceholderFactory<ExampleModel>
        {
        }
    }
    
    public class ExampleModelSpawner : ITickable
    {
        readonly ExampleModel.Factory _exampleModelFactory;

        public ExampleModelSpawner(ExampleModel.Factory exampleModelFactory)
        {
            _exampleModelFactory = exampleModelFactory;
        }

        public void Tick()
        {
            var enemy = _exampleModelFactory.Create();
        }
    }
}