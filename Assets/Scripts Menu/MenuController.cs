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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        SceneManager.LoadScene("SampleScene");
    }

    public void BackToMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }



}
