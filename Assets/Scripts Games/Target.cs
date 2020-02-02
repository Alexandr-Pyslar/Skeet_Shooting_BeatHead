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
    private float randomPosX = 23f;
    private float randomPosY;
    private bool tempPlayShoot;
    public ParticleSystem dirtParticle;



    void Start()
    {
        
        dirtParticle.Stop();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        progressBar = GameObject.FindGameObjectWithTag("Aim").GetComponent<ProgressBar>();
        transform.localScale = new Vector3(.6f, .6f, 1f);
        targetRb = GetComponent<Rigidbody2D>();
        RandomPosX();
        randomPosY = Random.Range(-3f, 6f);
        speed = Random.Range(0.5f, 1f);
        posY = Random.Range(0.8f, 1.4f);
        transform.position = new Vector3(randomPosX, randomPosY, -15);
        if (randomPosY < 0)
        {
            targetRb.AddForce(new Vector2(-randomPosX, Random.Range(0, 6f)) * (speed + gameManager.level/3), ForceMode2D.Impulse);
        } else
        {
            targetRb.AddForce(new Vector2(-randomPosX, Random.Range(0, -6f)) * (speed + gameManager.level/3), ForceMode2D.Impulse);
        }

        tempPlayShoot = gameManager.playShoot;
        Debug.Log("Level: " + gameManager.level + " Score: " + gameManager.score + "speed: " + speed);
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
                dirtParticle.Play();
                
                ChahgeScalePlate();

            }
            StartCoroutine(DelayAfterShoot());
        }

        if (gameManager.isDestroy)
        {
            gameManager.score--;
            gameManager.isActiveFireBtn = true;
            Destroy(gameObject);
            
        }
    }

    //Изменение размера тарелки, для эффекта перспективы
    void ChahgeScalePlate()
    {
        currenScale = platePrefab.transform.localScale.x * 0.985f;
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
        yield return new WaitForSeconds(0.6f);
        gameManager.isActiveFireBtn = true;
        //isDestroy = true;
        gameManager.score++;
        Destroy(gameObject);
        Destroy(dirtParticle);
    }
}
