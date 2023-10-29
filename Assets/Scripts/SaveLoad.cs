using System.Collections;
using System.Collections.Generic;
using Unity.Services.CloudSave;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    int level=1;
    int xp;

    public TMPro.TextMeshProUGUI welcomeText;
    // Start is called before the first frame update
    void Start()
    {
        SaveData();
    }
    async void SaveData()
    {
        var data = new Dictionary<string, object>
        {
            {"level", level },
            {"xp", xp }
        };
        await CloudSaveService.Instance.Data.ForceSaveAsync(data);
        print("Save Data Attempt Made");
    }   

    async void LoadData()
    {
        var keysToLoad = new HashSet<string>
        {
            "level",
            "xp",
            "username"
        };
        var loadedData = await CloudSaveService.Instance.Data.LoadAsync(keysToLoad);
        var loadedLevel = loadedData["level"];
        var loadedXp = loadedData["xp"];
        var loadedUsername = loadedData["username"];
        print("Loaded Data. Level : " + loadedLevel + ", Xp : " + loadedXp + "/" +( 50 + (level * 1.25f)));
        welcomeText.text = "Welcome " + loadedUsername + " (lv " + loadedLevel + ")";
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            LoadData();
        }
    }
}
