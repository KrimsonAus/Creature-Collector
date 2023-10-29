using System.Collections;
using System.Collections.Generic;
using Unity.Services.CloudSave;
using Unity.VisualScripting;
using UnityEngine;

public class CreatureManager : MonoBehaviour
{
    public string[] creatureName;
    public GameObject[] creatures;
    public Sprite[] creatureSprites;
    int[] owned;
    // Start is called before the first frame update
    void Start()
    {
        owned = new int[creatureName.Length];

        LoadCreatures();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            LoadCreatures();
        }

        for (int i = 0; i < creatures.Length; i++)
        {
            if (owned[i] == 1)
            {
                creatures[i].SetActive(true);
                creatures[i].GetComponent<Creature>().nameId = creatureName[i];
                creatures[i].GetComponent<SpriteRenderer>().sprite = creatureSprites[i];
            }
        }
    }

    async void LoadCreatures()
    {

        //var keysToLoad = new HashSet<string>
        //{
        //    "0","1","2","3","4","5"
        //};

        var keysToLoad = new HashSet<string>();

        for (int i = 0; i < creatureName.Length; i++)
        {
            keysToLoad.Add(creatureName[i]);
        }

        print("Keys To Load: " +keysToLoad);

        var loadedData = await CloudSaveService.Instance.Data.LoadAsync(keysToLoad);

        for (int i = 0; i < creatureName.Length; i++)
        {
            owned[i] = int.Parse(loadedData[creatureName[i]]);
        }
        print("Loaded Data. " + owned);
    }
}
