using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace mvvm.example
{
    public class UIManager : MonoBehaviour
    {
        private ExampleModel.Factory _exampleFactory;

        [Inject]
        public void Init(ExampleModel.Factory modelFactory)
        {
            Debug.Log("+++ Example factory created +++");
            _exampleFactory = modelFactory;
        }
        
        void Start()
        {
            Debug.Log("+++ UIManager INITIALIZED! +++");
        }

        public void Open()
        {
            Debug.Log("+++ OPEN! +++");
            var model = _exampleFactory.Create();
            Debug.Log("text = model.ExampleText");
        }

        private void Show()
        {
            
        }
    }
}
