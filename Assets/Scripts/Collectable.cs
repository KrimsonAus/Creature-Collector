using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Collectable : MonoBehaviour
{
    public string resource;
    public int health;
    public int amountToGive;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        health -= 1;

        if (health <= 0)
        {
            PlayerPrefs.SetInt(resource, PlayerPrefs.GetInt(resource) + amountToGive);
            Destroy(gameObject);
        }
    }
}
