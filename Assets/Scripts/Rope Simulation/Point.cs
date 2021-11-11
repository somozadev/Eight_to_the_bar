using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RopeSimulator
{
    [System.Serializable]
    public class Point: MonoBehaviour
    {
        public Vector3 position, previous_position;
        public bool locked;
        void Awake()
        {
            position = transform.position;
        }
    }
}