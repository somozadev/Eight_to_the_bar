using System.Globalization;
using System.Collections.Generic;
using UnityEngine;

namespace RopeSimulator
{
    [System.Serializable]
    public class Rope
    {
        public List<Point> points;
        public List<Stick> sticks;
        public float gravity;
        public int iterations;

        public Rope() { }
        public Rope(float gravity, int iterations, List<Point> points, List<Stick> sticks)
        {
            this.points = points;
            this.sticks = sticks;
            this.gravity = gravity;
            this.iterations = iterations;
        }

        public void Simulate()
        {
            foreach (Point p in points)
            {
                if (!p.locked)
                {
                    Vector3 position_start = p.position;
                    p.position += p.position - p.previous_position;
                    p.position += Vector3.down * gravity * Time.deltaTime * Time.deltaTime;
                    p.previous_position = position_start;
                }
            }
            for (int i = 0; i < iterations; i++)
            {
                foreach (Stick stick in sticks)
                {
                    Vector3 stick_center = (stick.point_a.position - stick.point_b.position) / 2;
                    Vector3 stick_direction = (stick.point_a.position - stick.point_b.position).normalized;
                    if (!stick.point_a.locked)
                        stick.point_a.position = stick_center + stick_direction * stick.length / 2;
                    if (!stick.point_b.locked)
                        stick.point_a.position = stick_center - stick_direction * stick.length / 2;
                }
            }
        }
    }

}

