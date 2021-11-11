using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RopeSimulator;

public class RopeHandler : MonoBehaviour
{
    [SerializeField] Rope rope;
    [SerializeField] GameObject parent_points;
    [SerializeField] GameObject parent_sticks;
    void OnEnable()
    {
        rope = new Rope(60000,600000,parent_points.GetComponentsInChildren<Point>().ToList(),parent_sticks.GetComponentsInChildren<Stick>().ToList());
        rope.Simulate();
    }

}
