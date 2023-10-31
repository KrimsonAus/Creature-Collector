using System.Collections;
using System.Collections.Generic;
using Unity.Services.Authentication;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;
    public string sceneName;
    public bool signOut;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
    }

    public void OpenMenu()
    {
        menu.SetActive(true);
    }

    public void ChangeScene()
    {
        if(signOut)
        {
            FindAnyObjectByType<ResourceManager>().UpdateGRH();
            AuthenticationService.Instance.SignOut();
        }
        SceneManager.LoadScene(sceneName);
    }
}
