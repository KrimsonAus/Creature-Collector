using System.Collections;
using System.Collections.Generic;
using Unity.Services.CloudSave;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public string dataName;
    public string data;
    // Start is called before the first frame update
    void Start()
    {

    }
    async void Save()
    {
        var d = new Dictionary<string, object>
        {
            {dataName, data }
        };
        await CloudSaveService.Instance.Data.ForceSaveAsync(d);
        print("Save Data Attempt Made");
    }
}
