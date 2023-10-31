using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public string username, password;

    public TMPro.TMP_InputField usernameField;
    public TMPro.TMP_InputField passwordField;

    public Toggle saveLogin;

    bool save;
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this);
        UnityServices.InitializeAsync();

        if(PlayerPrefs.GetInt("saveLogin") == 1)
        {
            AttemptSignIn(PlayerPrefs.GetString("username"), PlayerPrefs.GetString("password"));
        }
    }


    async void AttemptSignUp(string username, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(username, password);
            Debug.Log("SignUp is successful.");
            SaveLoginData(username, password);
            if (save)
            {
                PlayerPrefs.SetString("username", username);
                PlayerPrefs.SetString("password", password);
            }
            PlayerPrefs.SetInt("first", 0);
            SceneManager.LoadScene(1);
        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            // Compare error code to CommonErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
    }

    async void AttemptSignIn(string username, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(username, password);
            Debug.Log("SignIn is successful.");
            if (save)
            {
                PlayerPrefs.SetString("username", username); 
                PlayerPrefs.SetString("password", password);
            }
            PlayerPrefs.SetInt("first", 1);
            SceneManager.LoadScene(1);
        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            // Compare error code to CommonErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        username = usernameField.text;
        password = passwordField.text;
    }

    public void SignUp()
    {
        AttemptSignUp(username, password);
    }
    public void SignIn()
    {
        AttemptSignIn(username, password);
    }

    public void saveLog()
    {
        if (saveLogin.isOn)
        {
            
            PlayerPrefs.SetInt("saveLogin", 1);
            save = true;
        }
        else
        {
            PlayerPrefs.SetInt("saveLogin", 0);
            save = false;
        }
    }

    async void SaveLoginData(string username, string password)
    {
        var data = new Dictionary<string, object>
        {
            {"username", username }
            //{"password", password }
        };
        await CloudSaveService.Instance.Data.ForceSaveAsync(data);
        print("Save Data Attempt Made");
    }
}
