using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Particales
{

    [CreateAssetMenu(menuName = "Projectile's Data")]
    public class ProjectileData : ScriptableObject
    {
        public Vector3 starting_velocity;
        public Vector3 current_velocity;

        public Vector3 initial_position;
        public Vector3 current_position;

        public Vector3 velocity;
        public Vector3 acceleration;
        public Vector3 starting_height;
        public Vector3 current_height;

        //gravity is constant
        public Vector3 gravity;

        public float angle;
        public float time;
        public float speed;
    }
}
