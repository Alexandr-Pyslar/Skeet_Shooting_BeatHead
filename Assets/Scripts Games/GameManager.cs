using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button fireBtn;
    public GameObject aim;
    public GameObject[] platePrefab;
    public GameObject textGameOver;
    public ProgressBar progressBar;
    public ParticleSystem dirtParticle;

    private AudioSource audioPlayer;
    public AudioClip shootAudio;

    public Text scoreText;
    public Text levelText;

    public GameObject leftAlarm;
    public GameObject rightAlarm;

    public bool isActiveFireBtn = true;
    public float multiplier;
    public bool isDestroy = false;
    public bool playShoot = false;
    public int score = 0;
    public int level = 1;

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        progressBar = GameObject.FindGameObjectWithTag("Aim").GetComponent<ProgressBar>();
    }
    void Update()
    {
        
        if (isActiveFireBtn)
        {
            fireBtn.gameObject.SetActive(true);
            StopAllCoroutines();
            UpdateScore();
        }
        if (playShoot)
        {
            UpdateScore();
            audioPlayer.PlayOneShot(shootAudio, .5f);
            playShoot = false;
        }
    }

    public void SpawnPlate()
    {
        int prefabIndex = Random.Range(0, platePrefab.Length);
        Instantiate(platePrefab[prefabIndex], platePrefab[prefabIndex].transform.position, platePrefab[prefabIndex].transform.rotation);
        StartCoroutine(SetSpeedProgressBar());
        StartCoroutine(Destroy7Sec());
        StartCoroutine(LastChanceDestroy());
        fireBtn.gameObject.SetActive(false);
        isActiveFireBtn = false;
        isDestroy = false;
    }


    // Множитель для скорости заполнения прогресс бара
    IEnumerator SetSpeedProgressBar()
    {
            multiplier = 2;
            yield return new WaitForSeconds(1f);
            multiplier = 1.75f;
            yield return new WaitForSeconds(1f);
            multiplier = 1.5f;
            yield return new WaitForSeconds(1f);
            multiplier = 1.25f;
            yield return new WaitForSeconds(1f);
            multiplier = 1f;
            yield return new WaitForSeconds(1f);
            multiplier = 2;
    }

    //Уничтожение спустя 5 сек после запуска
    IEnumerator Destroy7Sec()
    {
        yield return new WaitForSeconds(7f);
        isActiveFireBtn = true;
        score--;
        isDestroy = true;
    }


    //Вероятность уничтожения на последней десятой доле секунды, в зависимости от времени заполнения прогресс бара
    IEnumerator LastChanceDestroy()
    {
        yield return new WaitForSeconds(4.9f);
        int chance = Random.Range(0, 100);
        if (progressBar.countForChance > chance)
        {
            isDestroy = true;
            isActiveFireBtn = true;
        }
    }

    public void UpdateScore()
    { 
        scoreText.text = "Score: " + score + "/5";
        levelText.text = "Level: " + level;

        if (score >= 5)
        {
            // Next Level
            level++;
            score = 0;
        }
        if (score < 0)
        {
            // Game Over
            textGameOver.SetActive(true);
            score = 0;
            Invoke("BackToMenu", 1f);

        }
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

}
