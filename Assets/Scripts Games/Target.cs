using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Target : MonoBehaviour
{
    public GameObject platePrefab;
    private Rigidbody2D targetRb;
    private GameManager gameManager;
    public ProgressBar progressBar;
    private float speed;
    private float posX = 0.4f;
    private float posY;
    private bool isDestroy = false;
    private float currenScale;
    private float randomPosX = 8.6f;
    private float randomPosY;
    private bool tempPlayShoot;


    void Start()
    {
        
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        progressBar = GameObject.FindGameObjectWithTag("Aim").GetComponent<ProgressBar>();
        targetRb = GetComponent<Rigidbody2D>();
        RandomPosX();
        speed = Random.Range(20f, 40f);
        //posX = Random.Range(0.3f, 0.5f);
        posY = Random.Range(0.8f, 1.4f);
        transform.position = new Vector3(randomPosX, -8f, -15);
        targetRb.AddForce(new Vector2(-posX, posY) * speed, ForceMode2D.Impulse);
        tempPlayShoot = gameManager.playShoot;


    }
    private void Update()
    {
        ChahgeScalePlate();
        // Уничтожение тарелки, если прогрессбар заполнен и цель в прицеле
        if (progressBar.readyToShoot && progressBar.currentAmount >= 100)
        {  if(!tempPlayShoot)
            {
                tempPlayShoot = true;
                gameManager.playShoot = true;
            }
            StartCoroutine(DelayAfterShoot());
        }

        if (gameManager.isDestroy)
        {
            gameManager.isActiveFireBtn = true;
            Destroy(gameObject);
            
        }
    }

    //Изменение размера тарелки, для эффекта перспективы
    void ChahgeScalePlate()
    {
        currenScale = platePrefab.transform.localScale.x * 0.99f;
        platePrefab.transform.localScale = new Vector3(currenScale, currenScale, currenScale);
    }

    //Выбор стороны запуска тарелки по Х
    void RandomPosX()
    {
        float pushPosX = Random.Range(0.0f, 1.0f);
        if (pushPosX < 0.5f)
        {
            randomPosX *= -1;
            posX *= -1;
        }        
    }

    IEnumerator DelayAfterShoot()
    {
        yield return new WaitForSeconds(0.3f);
        gameManager.isActiveFireBtn = true;
        isDestroy = true;
        Destroy(gameObject);
    }
}
