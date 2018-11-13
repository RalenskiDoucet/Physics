using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Particales
{
    public class LinearMove : IMoveable
    {
        public ParticleData pData;

        public LinearMove(ParticleData particleData)
        {
            pData = particleData;
        }

        public void Move(Transform t)
        {
            pData.Acceleration = pData.Force * pData.Mass;
            pData.Velocity = pData.Velocity + pData.Acceleration * Time.deltaTime;
            t.position = pData.Velocity * Time.deltaTime;
        }
    }
}