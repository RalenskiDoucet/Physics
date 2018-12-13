using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
namespace Particales
{
    public class BoidsBehaviour : MonoBehaviour {


        private List<ParticleData> boids;
        public List<GameObject> gameObjects;
        public float flock = 2.0f;
        public Toggle b1toggle;
        public Toggle b2toggle;
        public Toggle b3toggle;

        private void Start()
        {
            foreach (var p in boids)
            {
                p.current_position = Vector3.zero;
                p.current_position = new Vector3(Random.Range(-8, 8), Random.Range(-8, 8), Random.Range(-8, 8));
            }
        }

        private void PreviousUpdate()
        {
            MoveBoidsToNewPosition();
        }


        public void MoveBoidsToNewPosition()
        {// This Will move the boids towards a one boid.

            Vector3 vec1;
            Vector3 vec2;
            Vector3 vec3;
            Vector3 vec4;

            foreach (var b in boids)
            {
                if (b.isPerching)
                {
                    if (b.perch_timer > 0)
                    {
                        b.perch_timer = b.perch_timer - 1;
                    }
                    else
                    {
                        b.current_position = new Vector3(0, 30, 0);
                        b.isPerching = false;
                        b.perch_timer = 50;
                    }
                }

                if (b.perch_timer == 50)
                {
                    //checks to see if the switches are either on or off
                    if (b1toggle.isOn)
                    {
                        //calls Rule 1
                        vec1 = flock * Boid_Cohesion(b2toggle);
                    }
                    else
                        vec1 = -flock * Boid_Cohesion(b2toggle.isOn);

                    if (b2toggle.isOn)
                    {
                        //calls Rule 2
                        vec2 = Boid_Dispersion(b);
                    }
                    else
                        vec2 = -Boid_Dispersion(b1toggle);


                    b.velocity += vec1 + vec2 * Time.deltaTime;


                    if (b3toggle.isOn)
                    {
                        //calls Rule 3
                        vec3 = Boid_Alignment(b);
                        b.velocity += vec1 + vec2 + vec3 * Time.deltaTime;
                    }
                    else
                        b.velocity += vec1 + vec2 * Time.deltaTime;

                    vec4 = Bound_Position(b);

                    if (b.velocity.magnitude > 10)
                        b.velocity = b.velocity.normalized;

                    b.current_position = b.initial_position + b.starting_velocity;
                    gameObjects[boids.IndexOf(b)].transform.position = b.initial_position;
                }
            }
        }



        public Vector3 Boid_Cohesion(Particle b)
        {
            
            var N = boids.Count;


            Vector3 pc = new Vector3(0, 0, 0);

            foreach (var item in boids)
            {
                if (item != b1toggle)
                {
                    pc += item.current_position;
                }
            }
            pc = pc / (N - 1);
            return (pc - b.Position) / 100;
        }

        public Vector3 Boid_Dispersion(Particle b)
        {

            Vector3 c = new Vector3(0, 0, 0);


            foreach (var item in boids)
            {
                if (item != b1toggle)
                    if ((item.current_position - b.Position).magnitude <= 1)
                    {
                        c = c - (item.current_position - b.Position);
                    }
            }
            return c;
        }

        public Vector3 Boid_Alignment(Particle b)
        {

            var N = boids.Count;

            Vector3 pv = new Vector3(0, 0, 0);


            foreach (var item in boids)
            {
                if (item != b1toggle)
                {
                    pv += b.Velocity;
                }
            }
            pv = pv / (N - 1);
            return (pv - b.Velocity) / 8;
        }

        public Vector3 Bound_Position(Particle b)
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

#if UNITY_EDITOR
    [CustomEditor(typeof(BoidsBehaviour))]
        public class BoidBehaviourEditor : Editor
        {
            private BoidsBehaviour bBoids;

            private void OnEnable()
            {
                b = target as boids;
            }

            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();
                b.flock = GUILayout.HorizontalSlider(b.flock, 1, -1);

                if (GUILayout.Button("Land Boids"))
                {
                    foreach (var item in bBoids.boids)
                    {
                        item.current_position.y = 0;
                    }
                }
            }
        }
#endif
    }
}