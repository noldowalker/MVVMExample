using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace mvvm.example
{
    public class ExampleTab : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _tabText; 
        [SerializeField]
        private TextMeshProUGUI _tabButtonText; 
        [SerializeField]
        private Button _tabButton;

        public void Awake()
        {
            _tabButton.onClick.AddListener(OnButtonClick) ;
        }

        public void SetTabButtonText(string text)
        {
            _tabButtonText.text = text;
        }
        
        public void SetTabText(string text)
        {
            _tabText.text = text;
        }
        
        private void OnButtonClick()
        {
            Debug.Log("TabButtonClicked!");
        }
    }
}
