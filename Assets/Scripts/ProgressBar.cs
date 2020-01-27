using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Transform loadingBar;
    public float currentAmount;
    public float speedRadial;
    private CollisionTarget collTarget;
    public bool readyToShoot = false;
    // Start is called before the first frame update
    void Start()
    {
        collTarget = GameObject.FindGameObjectWithTag("Aim").GetComponent<CollisionTarget>();

    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmount < 100 && collTarget.isProgress)
        {
            currentAmount += speedRadial * Time.deltaTime;
        }
        loadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
        if (loadingBar.GetComponent<Image>().fillAmount == 1)
        {
            readyToShoot = true;
        }


    }
}
