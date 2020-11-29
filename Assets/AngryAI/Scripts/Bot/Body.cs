﻿using System.Collections.Generic;
using UnityEngine;

namespace MBaske.AngryAI
{
    public abstract class Body : MonoBehaviour
    {
        public Vector3 Velocity => rb.velocity;
        public Vector3 VelocityXZ => Vector3.ProjectOnPlane(rb.velocity, Vector3.up);
        public Vector3 ForwardXZ => Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized;

        protected Rigidbody rb;
        protected bool isOutOfBounds;

        public virtual void Initialize()
        {
            rb = GetComponent<Rigidbody>();
        }

        public virtual void OnAgentReset()
        {
            isOutOfBounds = false;
        }

        public virtual void StepUpdate(float[] actions)
        {
        }

        public Vector3 Localize(Vector3 v)
        {
            return transform.InverseTransformVector(v);
        }

        protected void AddVectorObs(List<float> obs, Vector3 v)
        {
            obs.Add(v.x);
            obs.Add(v.y);
            obs.Add(v.z);
        }
    }
}