using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button fireBtn;
    public GameObject aim;
    public GameObject platePrefab;
    public bool isActiveFireBtn = true;
    //public GameObject scoreText;
    //private float textScore;


    void Start()
    {
        
    }

    void Update()
    {
        //scoreText.text = "Score";
        if (isActiveFireBtn)
        {
            fireBtn.gameObject.SetActive(true);
        } 
    }

    public void SpawnPlate()
    {
        Instantiate(platePrefab, platePrefab.transform.position, platePrefab.transform.rotation);
        fireBtn.gameObject.SetActive(false);
        isActiveFireBtn = false;

    }


}
