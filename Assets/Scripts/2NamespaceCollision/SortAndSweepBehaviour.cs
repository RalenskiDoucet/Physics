using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Collision
{
    public class SortAndSweepBehaviour : MonoBehaviour
    {
        public List<CollisionVolume> x_Values;
        private List<CollisionVolume> y_Values;
        public List<CollisionVolume> active_List;
        public List<CollisionVolume> closed_List;

        // Use this for initialization
        void Start()
        {
            x_Values = new List<CollisionVolume>(GetComponents<CollisionVolume>());
            y_Values = new List<CollisionVolume>(GetComponents<CollisionVolume>());
        }

        public void CollisionForXAxis()
        {
            x_Values.OrderBy(v => v.x_min);
            for(int i = 0; i < x_Values.Count; i++)
            {
                foreach(var volume in x_Values)
                {
                    active_List.Add(volume);
                    if(active_List.Count >= 2)
                    {
                        if(active_List[0].x_min < active_List[1].x_max)
                        {
                            closed_List.Add(active_List[0]);
                            active_List.Remove(active_List[0]);
                            Debug.Log("collision on X axis");
                        }
                    }
                }
            }
        }

        public void CollisionForYAxis()
        {
            y_Values.OrderBy(v => v.y_min);
            for (int i = 0; i < y_Values.Count; i++)
            {
                foreach (var volume in y_Values)
                {
                    active_List.Add(volume);
                    if (active_List.Count >= 2)
                    {
                        if (active_List[0].y_min < active_List[1].y_max)
                        {
                            closed_List.Add(active_List[0]);
                            active_List.Remove(active_List[0]);
                            Debug.Log("collision on Y axis");
                        }
                    }
                }
            }
        }
    }
}
