using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Collision
{
    public class CollisionVolume : MonoBehaviour
    {
        float xmin;
        float xmax;
        float ymin;
        float ymax;
        public float x_min
        {
            get
            {
                return xmin;
            }
            set
            {
                xmin = value;
            }
        }
        public float x_max
        {
            get
            {
                return xmax;
            }
            set
            {
                xmax = value;
            }
        }
        public float y_min
        {
            get
            {
                return ymin;
            }
            set
            {
                ymin = value;
            }
        }
        public float y_max {
            get
            {
                return ymax;
            }
            set
            {
                ymax = value;
            }
        }
        public List<float> x_Values = new List<float>();
        public List<float> y_Values = new List<float>();
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