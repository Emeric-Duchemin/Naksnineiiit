using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace MBaske.AngryAI
{
    public class groundWalkerTrainig : MonoBehaviour
    {
        public GameObject obstacle;
        public GameObject ground;
        public Transform target;
        public BodyWalker body;
        private float diam = 7f;
        public bool straight_line = false;

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
            string[] fileList = { "target.txt", "speed_f.txt", "speed_b.txt", "speed_p.txt", "angle.txt" };
            for (int i = 0; i < fileList.Length; ++i)
            {
                if (File.Exists(Application.dataPath + @"\plot\"+fileList[i]))
                {
                    Debug.Log(Application.dataPath + @"/plot/" + fileList[i]);
                    File.Delete(Application.dataPath + @"/plot/" + fileList[i]);
                    //UnityEditor.AssetDatabase.Refresh();
                }
            }
            if (!straight_line)
            {
                RandomizeTarget();
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
            else {
                lineaDerecha();
            }
        }

        void lineaDerecha() {
            for (int i = -6; i <7; ++i) {
                Vector3 v = new Vector3(ground.transform.position.x - 10, -0.5f, ground.transform.position.z + i * 7.7f);
                Vector3 v2 = new Vector3(ground.transform.position.x+10, -0.5f, ground.transform.position.z + i * 7.7f);
                GameObject instan = Instantiate(obstacle, v, Quaternion.identity);
                instan.transform.localScale = new Vector3(2f, 5f, 2f);
                GameObject instan2 = Instantiate(obstacle, v2, Quaternion.identity);
                instan2.transform.localScale = new Vector3(2f, 5f, 2f);

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
            if (straight_line) {
                if(target.transform.localPosition.z <= -30)
                    target.transform.localPosition = new Vector3(0,0,40);
                else
                    target.transform.localPosition = new Vector3(0, 0, -40);
                return;
            }
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
