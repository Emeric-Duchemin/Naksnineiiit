using UnityEngine;

// Stand-alone trainer for the walker agent, uses a randomized target position.

namespace MBaske.AngryAI
{
    public class WalkTrainerA : Walker
    {
        [SerializeField]
        public Transform target;
        public override void InitializeAgent()
        {
            base.InitializeAgent();
        }

        public override void AgentReset()
        {
            base.AgentReset();
            walkMode = 1;
        }

        public override void CollectObservations()
        {
            Vector3 delta = target.position - body.transform.position;
            Vector3 dirXZ = Vector3.ProjectOnPlane(delta, Vector3.up).normalized;
            normWalkDir = Vector3.SignedAngle(dirXZ, body.ForwardXZ, Vector3.up) / 180f;

            base.CollectObservations();

            if (!IsDone())
            {
                base.reward = 0f;
                if (body.transform.rotation.eulerAngles.x >= 100 && body.transform.rotation.eulerAngles.x <= 260 && (body.transform.rotation.eulerAngles.z <= 100 || body.transform.rotation.eulerAngles.z >= 260))//prevent to be upside down
                {
                    AddReward(-5f);
                }
                if (body.transform.rotation.eulerAngles.z >= 100 && body.transform.rotation.eulerAngles.z <= 260 && (body.transform.rotation.eulerAngles.x <= 100 || body.transform.rotation.eulerAngles.x >= 260))//prevent to be upside down
                {
                    AddReward(-5f);
                }
                // Minimize angle -> face walk direction.
                
                float speed = Vector3.Dot(body.VelocityXZ, dirXZ) * 0.1f;
                RaycastHit hit;
                Physics.Raycast(body.transform.position , body.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity);
                //Debug.DrawRay(body.transform.position, body.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                if (hit.distance < 10 && hit.collider != null && hit.collider.gameObject.tag == "Wall")
                {
                    Vector3 deltaObject = hit.point - body.transform.position;
                    Vector3 dirObjectXZ = Vector3.ProjectOnPlane(deltaObject, Vector3.up).normalized;
                    float speedTowardObject = Vector3.Dot(body.VelocityXZ, dirObjectXZ) * 0.1f;
                    AddReward(-speedTowardObject * 4);
                    base.reward_angle += -Mathf.Abs(normWalkDir) * 0.5f;
                    base.reward += -Mathf.Abs(normWalkDir) * 0.5f;
                    AddReward(-Mathf.Abs(normWalkDir) * 0.5f);
                }
                else
                {
                    base.reward_angle += -Mathf.Abs(normWalkDir * 2);
                    base.reward += -Mathf.Abs(normWalkDir * 2);
                    AddReward(-Mathf.Abs(normWalkDir) * 2);
                }
                if (delta.sqrMagnitude < 25)
                {
                    AddReward(10f);
                    base.reward_got_target += 10f;
                }
                switch (walkMode)
                {
                    case 1:
                        AddReward(speed * 5); // forward
                        base.reward_speed_f += speed * 5;
                        base.reward += speed * 5;
                        break;
                    case -1:
                        AddReward(-speed); // backward
                        base.reward_speed_b += -speed;
                        base.reward += -speed;
                        break;
                    case 0:
                        AddReward(-10f);
                        break;
                }
            }
        }
    }
}
