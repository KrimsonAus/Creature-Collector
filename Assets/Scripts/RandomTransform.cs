using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTransform : MonoBehaviour
{

    public bool scale;
    public Vector3[] possibleScales;

    public bool rot;
    public Vector3[] possibleRots;

    int rngS;
    // Start is called before the first frame update
    void Start()
    {
        if(scale)
        {
            rngS = Random.Range(0, possibleScales.Length);

            transform.localScale = possibleScales[rngS];
        }
        if (rot)
        {
            rngS = Random.Range(0, possibleRots.Length);

            transform.Rotate(possibleRots[rngS]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
