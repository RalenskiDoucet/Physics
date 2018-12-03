using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Collision
{
    public class SortAndSweepBehaviour : MonoBehaviour
    {
        public List<CollisionVolume> xValues;
        private List<CollisionVolume> yValues;
        public List<CollisionVolume> activeList;
        public List<CollisionVolume> closedList;

        // Use this for initialization
        void Start()
        {
            xValues = new List<CollisionVolume>(GetComponents<CollisionVolume>());
            yValues = new List<CollisionVolume>(GetComponents<CollisionVolume>());
        }

        public void CheckCollisionForXAxis()
        {
            xValues.OrderBy(v => v.x_min);
            for(int i = 0; i < xValues.Count; i++)
            {
                foreach(var volume in xValues)
                {
                    activeList.Add(volume);
                    if(activeList.Count >= 2)
                    {
                        if(activeList[0].x_min < activeList[1].x_max)
                        {
                            closedList.Add(activeList[0]);
                            activeList.Remove(activeList[0]);
                            Debug.Log("collision on X axis");
                        }
                    }
                }
            }
        }

        public void CheckCollisionForYAxis()
        {
            yValues.OrderBy(v => v.y_min);
            for (int i = 0; i < yValues.Count; i++)
            {
                foreach (var volume in yValues)
                {
                    activeList.Add(volume);
                    if (activeList.Count >= 2)
                    {
                        if (activeList[0].y_min < activeList[1].y_max)
                        {
                            closedList.Add(activeList[0]);
                            activeList.Remove(activeList[0]);
                            Debug.Log("collision on Y axis");
                        }
                    }
                }
            }
        }
    }
}
