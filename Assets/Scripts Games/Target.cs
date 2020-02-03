using System.Collections;
using UnityEngine;
//using UnityEngine.UI;


public class Target : MonoBehaviour
{
    public GameObject platePrefab;
    public ProgressBar progressBar;
    public ParticleSystem dirtParticle;
    private Rigidbody2D targetRb;
    private GameManager gameManager;
    private float speed;
    private bool isDestroy = false;
    private float currenScale;
    private float randomPosX = 23f;
    private float randomPosY;
    private bool tempPlayShoot;

    void Start()
    {  
        dirtParticle.Stop();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        progressBar = GameObject.FindGameObjectWithTag("Aim").GetComponent<ProgressBar>();
        transform.localScale = new Vector3(.5f, .5f, 1f);
        targetRb = GetComponent<Rigidbody2D>();
        RandomPosX();
        randomPosY = Random.Range(-4f, 7f);
        speed = Random.Range(0.1f, 0.3f);

        transform.position = new Vector3(randomPosX, randomPosY, -15);

        if (randomPosY < 0)
        {
            targetRb.AddForce(new Vector2(-randomPosX, Random.Range(0, 6f)) * (speed + gameManager.level/10f), ForceMode2D.Impulse);
        } else
        {
            targetRb.AddForce(new Vector2(-randomPosX, Random.Range(0, -6f)) * (speed + gameManager.level/10f), ForceMode2D.Impulse);
        }

        // включение кнопок с подсказками направления
        if (randomPosX > 0)
        {
            gameManager.rightAlarm.SetActive(true);
        }
        else
        {
            gameManager.leftAlarm.SetActive(true);
        }

        tempPlayShoot = gameManager.playShoot;
        Debug.Log("Level: " + gameManager.level + " Score: " + gameManager.score + " speed: " + speed + " coef: "+ gameManager.level / 10f);

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
        // уничтожэение, если игрок не попал
        if (gameManager.isDestroy)
        {
            gameManager.score--;
            gameManager.isActiveFireBtn = true;
            gameManager.leftAlarm.SetActive(false);
            gameManager.rightAlarm.SetActive(false);
            Destroy(gameObject);
            
        }
    }

    //Изменение размера тарелки, для эффекта перспективы
    void ChahgeScalePlate()
    {
        currenScale = platePrefab.transform.localScale.x * 0.992f;
        platePrefab.transform.localScale = new Vector3(currenScale, currenScale, currenScale);
    }

    //Выбор стороны запуска тарелки по Х
    void RandomPosX()
    {
        float pushPosX = Random.Range(0.0f, 1.0f);
        if (pushPosX < 0.5f)
        {
            randomPosX *= -1;
        }        
    }

    //Задержка удаления после выстрела пока долетит снаряд
    IEnumerator DelayAfterShoot()
    {
        yield return new WaitForSeconds(0.6f);
        gameManager.isActiveFireBtn = true;
        gameManager.score++;
        gameManager.leftAlarm.SetActive(false);
        gameManager.rightAlarm.SetActive(false);

        Destroy(gameObject);
        Destroy(dirtParticle);
    }
}
