using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace mvvm.example
{
    public class MainSystem : MonoBehaviour
    {
        private DependencyInstaller _dependencyInstaller;
        
        void Start()
        {
            Debug.Log("START");
            DependencyInstaller.Install(new DiContainer());
        }
    }
}
