using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Particales;

namespace Collision
{
    public class OnCollision:MonoBehaviour
    {
        Particle b;
        BoidsBehaviour boids;
        void OnCollisionEnter()
        {
            boids.Boid_Dispersion(b);
        }
    }
}
