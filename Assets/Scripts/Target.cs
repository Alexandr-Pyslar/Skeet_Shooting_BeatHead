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
    public float speed = 7.5f;
    public float posX = 0.4f;
    public float posY = 1f;
    private bool isDestroy = false;
    private float currenScale;
    private float randomPosX = 6f;


    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        progressBar = GameObject.FindGameObjectWithTag("Aim").GetComponent<ProgressBar>();
        targetRb = GetComponent<Rigidbody2D>();
        RandomPosX();
        transform.position = new Vector3(randomPosX, -6.8f, 1);
        targetRb.AddForce(new Vector2(-posX, posY) * speed, ForceMode2D.Impulse);
        
    }
    private void Update()
    {
        ChahgeScalePlate();
        // Уничтожение тарелки, если прогрессбар заполнен и цель в прицеле
        if (progressBar.readyToShoot && progressBar.currentAmount >= 100)
        {
            Destroy(gameObject);
            isDestroy = true;
            gameManager.isActiveFireBtn = true;
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
}
