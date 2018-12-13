using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Particales
{

    [CreateAssetMenu(menuName = "Projectile's Data")]
    public class ParticleData : ScriptableObject, IMoveable
    {
        public Vector3 starting_velocity;
        public Vector3 current_velocity;
        public Vector3 Force;
        public float Mass;
        public IMoveable moveable;
        public Vector3 initial_position;
        public Vector3 current_position;
        public bool isPerching = false;
        public float perch_timer;
        public Vector3 velocity;
        public Vector3 acceleration;
        public Vector3 starting_height;
        public Vector3 current_height;

        //gravity is constant
        public Vector3 gravity;

        public float angle;
        public float time;
        public float speed;
        private void OnEnable()
        {
            moveable = new LinearMove(this);
            perch_timer = 50;
        }
        public void Move(Transform t)
        {
            moveable.Move(t);
        }
    }
}
