using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityWeld.Binding;

namespace mvvm.example
{
    [Binding]
    public class ExampleText
    {
        [Binding]
        public string DisplayText
        {
            get;
            private set;
        }

        public ExampleText(string displayText)
        {
            this.DisplayText = displayText;
        }
    }
}
