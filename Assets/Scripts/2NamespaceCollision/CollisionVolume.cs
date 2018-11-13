using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Collision
{
    public class CollisionVolume : MonoBehaviour
    {
       
        public float x_min;
        public float x_max;
        public float y_min;
        public float y_max;
        public List<float> x_Values;        
        public List<float> y_Values;
        void add_Values_to_list()
        {
            x_Values.Add(x_max);
            x_Values.Add(x_min);
            y_Values.Add(y_min);
            y_Values.Add(y_max);
        }
        // Use this for initialization
        void Start()
        {
            add_Values_to_list();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}