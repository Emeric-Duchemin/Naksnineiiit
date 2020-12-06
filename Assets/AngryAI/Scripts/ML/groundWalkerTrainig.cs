using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBaske.AngryAI
{
    public class groundWalkerTrainig : MonoBehaviour
    {
        public GameObject obstacle;
        public GameObject ground;
        public Transform target;
        public BodyWalker body;
        private float diam = 7f;

        List<Vector3> positions = new List<Vector3>();

        public static float generateNormalRandom(float mu, float sigma)
        {
            float rand1 = Random.Range(0.0f, 1.0f);
            float rand2 = Random.Range(0.0f, 1.0f);

            float n = Mathf.Sqrt(-2.0f * Mathf.Log(rand1)) * Mathf.Cos((2.0f * Mathf.PI) * rand2);

            float res = (mu + sigma * n);
            while (res > mu + sigma && res < mu + sigma)
            {
                rand1 = Random.Range(0.0f, 1.0f);
                rand2 = Random.Range(0.0f, 1.0f);

                n = Mathf.Sqrt(-2.0f * Mathf.Log(rand1)) * Mathf.Cos((2.0f * Mathf.PI) * rand2);

                res = (mu + sigma * n);
            }
            return res;
        }

        // Start is called before the first frame update
        void Start()
        {
            int nbObstacle = Random.Range(10, 20);
            for (int i = 0; i < nbObstacle; i++)
            {
                Vector3 v = new Vector3(generateNormalRandom(ground.transform.position.x, 25), -0.5f, generateNormalRandom(ground.transform.position.z, 25));
                bool possible = true;
                for (int j = 0; j < positions.Count; j++)
                {
                    float d = (v - positions[j]).magnitude;
                    if (d > diam && d < (diam * 2))
                    {
                        Debug.Log(d);
                        possible = false;
                    }
                }
                if (possible)
                {
                    positions.Add(v);
                    GameObject instan = Instantiate(obstacle, v, Quaternion.identity);
                    instan.transform.localScale = new Vector3(2f, 5f, 2f);
                }
                else
                {
                    i--;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 delta = target.position - body.transform.position;
            if (delta.sqrMagnitude < 25)
            {
                RandomizeTarget();
            }
        }

        private void RandomizeTarget()
        {
            bool possible = false;
            while (!possible)
            {
                Vector3 pos = Random.onUnitSphere * 40;
                pos.y = 0;
                for (int j = 0; j < positions.Count; j++)
                {
                    float d = (pos - positions[j]).magnitude;
                    if (d < 10)
                    {
                        continue;
                    }
                }
                target.transform.localPosition = pos;
                possible = true;
            }
        }
    }
}
