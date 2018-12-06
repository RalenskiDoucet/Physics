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
     
        private Vector3 e; //unit length vector
        private Vector3 ePrime;
        Particales.Particle Particle1;
        Particales.Particle Particle2;
        SpringDampner sd;
        private List<Particle> Particles = new List<Particle>();
        private List<SpringDampner> springs = new List<SpringDampner>();
        Gizmos gizmos = new Gizmos();
        public GameObject p1, p2;

        void OnDrawGizmos()
        {
            foreach (var p in Particles)
            {
                p1.transform.position = Particle1.Position;
                p2.transform.position = Particle2.Position;
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(p1.transform.position, 2);

            }
            foreach (var s in springs)
            {
                
                Gizmos.color = Color.magenta;
                Gizmos.DrawLine(Particle1.Position, Particle2.Position);
            }

        }

        // Use this for initialization
        void Start()
        {
            Particles.Add(Particle1);
            Particles.Add(Particle2);
            springs.Add(sd);
            Particle1 = p1.GetComponent<ClothBehaviour>().particle1;
            Particle2 = p2.GetComponent<ClothBehaviour>().particle1;
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