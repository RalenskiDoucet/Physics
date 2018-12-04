using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Particales;
namespace ClothPhyics
{
    public class ClothBehaviour : MonoBehaviour
    {

       
        public Gizmos gGizmos = new Gizmos();
        public Particales.Particle particle1;
    
    
        // Use this for initialization
        void clothStart()
        {
            particle1 = new Particales.Particle(new Vector3(particle1.Position.x, particle1.Position.y, particle1.Position.z));
            particle1.Position = transform.position;            
            particle1.Mass = 1;

           
        }
            
        void Awake()
        {
            clothStart();
        }

        // Update is called once per frame
        void Update()
        {
            var gravity = new Vector3(0, -9.81f, 0);
            particle1.AddForce(gravity * 0.25f);
            Debug.Log(particle1.Force);
            particle1.Update(Time.deltaTime);            
            transform.position = particle1.Position;
           
        }
    }

}