using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScaleClick : MonoBehaviour
{
    public float scaleTo;
    bool clicked;
    float timer;
    Vector2 scale;
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked)
        {
            timer += Time.deltaTime;
            transform.localScale = new Vector2(scale.x * scaleTo, scale.y * scaleTo);

            if (timer >= 0.1f)
            {
                timer = 0;
                clicked = false;
                transform.localScale = scale;
            }
        }
    }

    private void OnMouseDown()
    {
        clicked = true;
    }
}
