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
            pData.acceleration = pData.Force * pData.Mass;
            pData.velocity = pData.velocity + pData.acceleration * Time.deltaTime;
            t.position = pData.velocity * Time.deltaTime;
        }
    }
}