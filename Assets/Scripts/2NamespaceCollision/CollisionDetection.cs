using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collision
{
    public class CollisionDetection : CollisionVolume
    { 
        CollisionVolume mShape = new CollisionVolume();
        CollisionVolume mShape2 = new CollisionVolume();
        
        
        public bool collision_made;

        void check_for_collision(List<float> x ,List<float> y)
        {
            CollisionVolume mShape = new CollisionVolume();
            CollisionVolume mShape2 = new CollisionVolume();

            if (mShape2.x_min<mShape.x_max)
            {
                collision_made = true;
                BroadcastMessage("Collision was made");
            }
            if (mShape2.y_min < mShape.y_max)
            {
                collision_made = true;
            }
            else if(mShape2.x_max > mShape.x_max)
            {
                collision_made = false;
            }
        }
        // Use this for initialization
        void Start() {
            check_for_collision(x_Values, y_Values);
        }

        // Update is called once per frame
        void Update() {

        }
    }
}