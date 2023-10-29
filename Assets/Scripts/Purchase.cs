using System.Collections;
using System.Collections.Generic;
using Unity.Services.CloudSave;
using UnityEngine;
using UnityEngine.UI;

public class Purchase : MonoBehaviour
{
    public int cost;
    public string product;

    public RawImage spriteR;
    public TMPro.TextMeshProUGUI nameText;

    bool owned;
    // Start is called before the first frame update
    void Start()
    {
        //DEBUG//
        nameText.text = product;
        //Save("gems", "150");
        //Save("rice", "150");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buy()
    {
        if (PlayerPrefs.GetInt("gems") >= cost && !owned)
        {
            print("Costs: " + cost + " Have: " + PlayerPrefs.GetInt("gems"));
            owned = true;
            FindAnyObjectByType<SaveData>().Save(product, "1");
            PlayerPrefs.SetInt("gems", PlayerPrefs.GetInt("gems") - cost);
        }
    }
}
