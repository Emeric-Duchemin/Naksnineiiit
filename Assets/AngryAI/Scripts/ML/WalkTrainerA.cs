using UnityEngine;

// Stand-alone trainer for the walker agent, uses a randomized target position.

namespace MBaske.AngryAI
{
    public class WalkTrainerA : Walker
    {
        [SerializeField]
        private Transform target;
        public override void InitializeAgent()
        {
            base.InitializeAgent();
        }

        public override void AgentReset()
        {
            base.AgentReset();
            walkMode = Random.Range(-1, 2);
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
                    AddReward(-10f);
                }
                if (body.transform.rotation.eulerAngles.z >= 100 && body.transform.rotation.eulerAngles.z <= 260 && (body.transform.rotation.eulerAngles.x <= 100 || body.transform.rotation.eulerAngles.x >= 260))//prevent to be upside down
                {
                    AddReward(-10f);
                }
                // Minimize angle -> face walk direction.
                base.reward_angle += -Mathf.Abs(normWalkDir);
                base.reward += -Mathf.Abs(normWalkDir);
                AddReward(-Mathf.Abs(normWalkDir) * 0.2f);
                float speed = Vector3.Dot(body.VelocityXZ, dirXZ) * 0.1f;
                Vector3 delt = target.position - this.transform.position;
                if (delt.sqrMagnitude < 25)
                {
                    AddReward(10f);
                    base.reward_got_target += 10f;
                }
                switch (walkMode)
                {
                    case 1:
                        AddReward(speed); // forward
                        base.reward_speed_f += speed;
                        base.reward += speed;
                        break;
                    case -1:
                        AddReward(-speed); // backward
                        base.reward_speed_b += -speed;
                        base.reward += -speed;
                        break;
                    case 0:
                        AddReward(-Mathf.Abs(speed)); // pause
                        base.reward_speed_p += -Mathf.Abs(speed);
                        base.reward += -Mathf.Abs(speed);
                        break;
                }
            }
        }
    }
}
