using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundWalkerTrainig : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject ground;

    public static float generateNormalRandom(float mu, float sigma)
    {
        float rand1 = Random.Range(0.0f, 1.0f);
        float rand2 = Random.Range(0.0f, 1.0f);

        float n = Mathf.Sqrt(-2.0f * Mathf.Log(rand1)) * Mathf.Cos((2.0f * Mathf.PI) * rand2);

        return (mu + sigma * n);
    }

    // Start is called before the first frame update
    void Start()
    {
        int nbObstacle = Random.Range(5, 30);
        for(int i = 0; i < nbObstacle; i++)
        {
            Instantiate(obstacle, new Vector3(generateNormalRandom(ground.transform.position.x, 25), 0, generateNormalRandom(ground.transform.position.z, 25)), Quaternion.identity);
            obstacle.transform.localScale = new Vector3(2f, 5f, 2f); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
