using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : MonoBehaviour
{
    Creature creature;
    // Start is called before the first frame update
    void Start()
    {
        creature = GetComponentInParent<Creature>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (creature.hunger < 100 && PlayerPrefs.GetInt("rice") >= 1)
        {
            PlayerPrefs.SetInt("rice", PlayerPrefs.GetInt("rice") - 1);
            creature.hunger += 1;
        }
    }
}
