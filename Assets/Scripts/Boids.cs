using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Particales
{
    public class Boids : MonoBehaviour {

      
        private List<ParticleData> boids;
        public List<GameObject> gameObjects;

       
        private void Start()
        {
            foreach (var p in boids)
            {
                p.Position = Vector3.zero;
                p.Position = new Vector3(Random.Range(-8, 8), Random.Range(-8, 8), Random.Range(-8, 8));
            }
        }

        private void PreviousUpdate()
        {
            MoveBoidsToNewPosition();
        }

        public void MoveBoidsToNewPosition()
        {// This Will move the boids towards a certain boid.
         
            Vector3 v1;
            Vector3 v2;
            Vector3 v3;

        
            foreach (var b in boids)
            {
                Bound_Position(b);
                v1 = Boid_Cohesion(b);
                v2 = Boid_Dispersion(b);
                v3 = Boid_Alignment(b);

                b.Velocity = b.Velocity + v1 + v2 + v3;

                if (b.Velocity.magnitude > 8)
                    b.Velocity = b.Velocity.normalized;

                b.Position = b.Position + b.Velocity;
                gameObjects[boids.IndexOf(b)].transform.position = b.Position;
            }
        }


        public Vector3 Boid_Cohesion(ParticleData b)
        {
            // this Will keep the boids in a close group.
            var N = boids.Count;


            Vector3 pc = new Vector3(0, 0, 0);

            foreach (var item in boids)//For each item that is in the list of boids.
            {
                if (item != b)
                {
                    pc += item.Position;
                }
            }
            pc = pc / (N - 1);
            return (pc - b.Position) / 100;
        }

        public Vector3 Boid_Dispersion(ParticleData b)
        {
   
            Vector3 c = new Vector3(0, 0, 0);

        
            foreach (var item in boids)
            {
                if (item != b)
                    if ((item.Position - b.Position).magnitude <= 1)
                    {
                        c = c - (item.Position - b.Position);
                    }
            }
            return c;
        }

        public Vector3 Boid_Alignment(ParticleData b)
        {
         
            var N = boids.Count;

            Vector3 pv = new Vector3(0, 0, 0);

  
            foreach (var item in boids)
            {
                if (item != b)
                {
                    pv += b.Velocity;
                }
            }
            pv = pv / (N - 1);
            return (pv - b.Velocity) / 8;
        }

        public Vector3 Bound_Position(ParticleData b)
        {
            float Xmin = 0, Xmax = 0, Ymin = 0, Ymax = 0, Zmin = 0, Zmax = 0;
            Vector3 v = new Vector3(0, 0, 0);

            if (b.Position.x < Xmin)
            {
                v.x = Screen.width;
            }
            else if (b.Position.x > Xmax)
            {
                v.x = -15;
            }

            if (b.Position.y < Ymin)
            {
                v.y = Screen.height;
            }
            else if (b.Position.x > Ymax)
            {
                v.y = -15;
            }

            if (b.Position.y < Zmin)
            {
                v.z = 15;
            }
            else if (b.Position.x > Zmax)
            {
                v.z = -15;
            }

            return v;
        }
    }
}