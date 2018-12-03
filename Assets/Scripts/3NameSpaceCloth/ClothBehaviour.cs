using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Particales;
namespace ClothPhyics
{
    public class ClothBehaviour : MonoBehaviour
    {

       
        public Gizmos gGizmos = new Gizmos();
        public Particales.Particle particle;
        public List<Gizmos> gizmos = new List<Gizmos>();
        // Use this for initialization
        void clothStart()
        {
            particle = new Particales.Particle(new Vector3(particle.Position.x, particle.Position.y, particle.Position.z));
            particle.Position = transform.position;
            particle.Mass = 1;
        }
            
        void Start()
        {
          
        }

        // Update is called once per frame
        void Update()
        {
            var gravity = new Vector3(0, -9.81f, 0);
            particle.AddForce(gravity * 0.25f);
            particle.Update();
            transform.position = particle.Position;
        }
    }

}