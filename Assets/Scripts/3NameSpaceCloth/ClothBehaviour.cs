using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Particales;
namespace ClothPhyics
{
    public class ClothBehaviour : MonoBehaviour
    {

       
       public Gizmos gGizmos = new Gizmos();
       public Particle particle;
       public List<Gizmos> gizmos = new List<Gizmos>();
        // Use this for initialization
        void clothStart()
        {
            particle = new Particle(new Vector3(particle.Position.x, particle.Position.y, particle.Position.z));
            particle.Position = transform.position;
            particle.Mass = 1;
        }
            
        void Start()
        {
          
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}