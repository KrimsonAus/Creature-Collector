using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float timer;
    float rng;

    public bool instance;
    public GameObject gameobjectToInst;

    public float min;
    public float max;
    // Start is called before the first frame update
    void Start()
    {
        rng = Random.Range(min, max);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer>=rng)
        {
            timer = 0;
            rng = Random.Range(min, max);

            if (instance)
            {
                Instantiate(gameobjectToInst, transform.position, Quaternion.identity);
            }
        }
    }
}
