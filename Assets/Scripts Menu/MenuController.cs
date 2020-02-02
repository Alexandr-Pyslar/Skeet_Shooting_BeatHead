using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menuBtn;
    public GameObject exitGameBtn;
    public GameObject settingsBtn;
    public GameObject menuSampleScene;

    private float camVol;
    private bool fadingVol = false;


    private void Start()
    {
        camVol = GameObject.Find("Main Camera").GetComponent<AudioSource>().volume;
    }
    private void Update()
    {
        if (fadingVol && camVol >= 0)
        {
            camVol *= 0.8f;
            GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = camVol;
        }
            
    }

    public void ShowExitBtns()
    {
        menuBtn.SetActive(false);
        exitGameBtn.SetActive(true);
    }

    public void BackInMenu()
    {
        menuBtn.SetActive(true);
        exitGameBtn.SetActive(false);
        settingsBtn.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsBtn.SetActive(true);
        menuBtn.SetActive(false);
    }


    public void ExitGame()
    {

        Application.Quit();
    }

    public void StartGame()
    {
        fadingVol = true;
        Invoke("LoadGame", 0.3f);       
    }

    public void BackToMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    private void LoadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }



}
