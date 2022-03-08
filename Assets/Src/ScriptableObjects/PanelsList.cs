using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mvvm.example
{
    [CreateAssetMenu(fileName = "PanelsList", menuName = "ExampleProject/ScriptableObjects/Spawn Panels List", order = 1)]
    public class PanelsList : ScriptableObject
    {
        [SerializeField]
        public List<PanelRecord> Panels;
    }

    [Serializable]
    public struct PanelRecord
    {
        public Panels panelType;
        public GameObject panelPrefub;
    };
}
