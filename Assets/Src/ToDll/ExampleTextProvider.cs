namespace mvvm.example
{
    public class ExampleTextProvider: ITextProvider
    {
        public string GenerateRandomText()
        {
            return "Random Generated string";
        }
    }
}