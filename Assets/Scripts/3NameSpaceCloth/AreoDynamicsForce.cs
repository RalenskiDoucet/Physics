using System.Collections;
using System.Collections.Generic;
using Particales;
using UnityEngine;
namespace ClothPhyics
{
    public class AeroDynamicForce:MonoBehaviour
    { 
        public Vector3 density; //density of air
        private float Cd; //coefficient of drag for the object
        private Vector3 a; //cross sectional area of the object

        public Particle AreoPart1; //particle 1
        public Particle AreoPart2; //particle 2
        public Particle AreoPart3; //particle 3

        public AeroDynamicForce(Particle p1, Particle p2, Particle p3)
        {
            p1 = AreoPart1;
            p2 = AreoPart2;
            p3 = AreoPart3;
            density = new Vector3(0, 0, 1);
        }
        public bool CheckParticles(Particle temp)
        {
            return temp.name == AreoPart1.name || temp.name == AreoPart2.name || temp.name == AreoPart3.name;
        }
        void Start()
        {

        }

        public void Update()
        {
            //calculate the average velocity of the particles
            var AverageVelocity = (AreoPart1.Velocity + AreoPart2.Velocity + AreoPart3.Velocity) / 3;
            var V = AverageVelocity - density;

            //calculate the normal of the triangle
            var diffofAeroPart2andAreoPart1 = AreoPart2.Position - AreoPart1.Position;
            var diffofAreoPart3andAreoPart1 = AreoPart3.Position - AreoPart1.Position;
            var cross = Vector3.Cross(diffofAeroPart2andAreoPart1, diffofAreoPart3andAreoPart1);

            var n = cross / cross.magnitude;

            //calculate the area of the triangle
            var ao = cross.magnitude / 2;
            var a = ao + (Vector3.Dot(V, n) / V.magnitude);

            //calculate the total force being applied
            var force = -.5f * ((V.magnitude * Vector3.Dot(V, cross)) / (3 * cross.magnitude)) * cross.normalized;
            AreoPart1.AddForce(force / 4);
            AreoPart2.AddForce(force / 4);
            AreoPart3.AddForce(force / 4);
        }
    }
}