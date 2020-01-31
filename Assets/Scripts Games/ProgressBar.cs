using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Transform loadingBar;
    private GameManager gameManager;
    public float currentAmount;
    public float speedRadial;
    private CollisionTarget collTarget;
    public bool readyToShoot = false;
    public float countForChance;


    void Start()
    {

        collTarget = GameObject.FindGameObjectWithTag("Aim").GetComponent<CollisionTarget>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

      void FixedUpdate()
    {
       if (currentAmount < 100 && collTarget.isProgress)
            {
            currentAmount += 4* gameManager.multiplier;
            if (currentAmount > countForChance) countForChance += currentAmount;          
        }
        loadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
        
        if (loadingBar.GetComponent<Image>().fillAmount == 1)
        {
            readyToShoot = true;
            gameManager.multiplier = 20f;

        } else
        {
            readyToShoot = false;
        }
    }


}


