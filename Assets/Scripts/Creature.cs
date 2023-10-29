using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.CloudSave;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public string nameId;

    public GameObject heart;

    public int happiness;
    public int hunger;

    int hungerOld;
    int happinessOld;

    int hearts;
    int heartsU;

    public TMPro.TextMeshPro hungerText;
    // Start is called before the first frame update
    void Start()
    {
        check();
    }

    // Update is called once per frame
    void Update()
    {
        if (hungerOld != hunger)
        {
            hungerOld = hunger;
            FindAnyObjectByType<SaveData>().Save(nameId + "Hunger", "" + hunger);
        }

        hungerText.text = "Hunger: " + hunger + "/100";
    }

    private void OnMouseDown()
    {
        Instantiate(heart, transform.position, Quaternion.identity);
        PlayerPrefs.SetInt("hearts", PlayerPrefs.GetInt("hearts") + 1);
    }

    async void GetHunger()
    {
        var keysToLoad = new HashSet<string>
            {
                nameId+"Hunger",
            };
        var loadedData = await CloudSaveService.Instance.Data.LoadAsync(keysToLoad);
        hunger = int.Parse(loadedData[nameId + "Hunger"]);
        hungerOld = hunger;
    }

    public void check()
    {
        if (nameId != null)
        {
            //FindAnyObjectByType<SaveData>().Save(nameId + "Hunger", "10");
            GetHunger();
        }
        else
        {
            check();
        }
    }
}
