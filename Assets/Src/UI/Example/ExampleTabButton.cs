using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace mvvm.example
{
    public class ExampleTabButton : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI _text;
        [SerializeField] 
        private Button _button;

        public Action<int> ButtonClickActions;

        private int _index;
        
        public void SetTabIndex(int index)
        {
            _index = index;
            _text.text = "Tab #" + (index + 1);
        }

        public void OnButtonClick()
        {
            ButtonClickActions?.Invoke(_index);
        }
    }
}
