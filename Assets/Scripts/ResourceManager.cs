using System.Collections;
using System.Collections.Generic;
using Unity.Services.CloudSave;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public float updateTiming;
    public TMPro.TextMeshProUGUI riceText;
    public TMPro.TextMeshProUGUI gemsText;
    public TMPro.TextMeshProUGUI heartsText;

    float updateTimer;

    public string valueS;
    // Start is called before the first frame update
    void Start()
    {
        CheckGRH();
    }

    // Update is called once per frame
    void Update()
    {
        updateTimer += Time.deltaTime;

        if(updateTimer > updateTiming)
        {
            updateTimer = 0;
            UpdateGRH();
        }

        gemsText.text = "" + PlayerPrefs.GetInt("gems");
        riceText.text = "" + PlayerPrefs.GetInt("rice");
        heartsText.text = "" + PlayerPrefs.GetInt("hearts");
    }

    async void CheckGRH()
    {
        var keysToLoad = new HashSet<string>
        {
            "gems",
            "rice",
            "hearts"
        };
        var loadedData = await CloudSaveService.Instance.Data.LoadAsync(keysToLoad);
        PlayerPrefs.SetInt("gems", int.Parse(loadedData["gems"]));
        PlayerPrefs.SetInt("rice", int.Parse(loadedData["rice"]));
        PlayerPrefs.SetInt("hearts", int.Parse(loadedData["hearts"]));
    }

    void UpdateGRH()
    {
        FindObjectOfType<SaveData>().Save("gems",  PlayerPrefs.GetInt("gems") + "");
        FindObjectOfType<SaveData>().Save("rice",  PlayerPrefs.GetInt("rice") + "");
        FindObjectOfType<SaveData>().Save("hearts",  PlayerPrefs.GetInt("hearts") + "");
    }
}
