using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Particales;
namespace ClothPhyics
{

    public class SpringDampner : MonoBehaviour
    {
        public float springConstant;
        public float dampingFactor;
        public float restLength;
        public float unitLength;
        public Vector3 Pos;
        private Vector3 e; //unit length vector
        private Vector3 ePrime;
        Particales.Particle Particle1;
        Particales.Particle Particle2;


        // Use this for initialization
        void Start()
        {
            restLength = Vector3.Distance(Particle1.Position, Particle2.Position);
            springConstant = 20;
            dampingFactor = 100;
            
        }

        // Update is called once per frame
        void Update()
        {
            //length between vector between particles
            ePrime = Particle2.Position - Particle1.Position;
            unitLength = ePrime.magnitude;
            e = ePrime.normalized / unitLength;
            //1d Velocity
            var m1 = Vector3.Dot(e, Particle1.Velocity);
            var m2 = Vector3.Dot(e, Particle2.Velocity);
            //1d to 3d
            var hL = -springConstant * (restLength - unitLength) - dampingFactor * (m1 - m2);
            var f1 = hL * e;
            var f2 = -f1;

            Debug.Log(f1);
            Particle1.AddForce(f1);
            Particle2.AddForce(f2);
        }
      
    }
}