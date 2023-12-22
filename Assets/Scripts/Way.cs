using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{    
    public class Way : MonoBehaviour
    {        
        [field: SerializeField] public Vector3[] Points { get; private set; }

        private void OnValidate()
        {
            var transformsChildren = GetComponentsInChildren<Transform>();
            Points = new Vector3[transformsChildren.Length];

            for(int i = 0; i < transformsChildren.Length; i++)
                Points[i] = transformsChildren[i].position;
        }        
    }
}
