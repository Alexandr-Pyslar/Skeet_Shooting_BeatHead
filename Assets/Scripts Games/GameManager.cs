using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button fireBtn;
    public GameObject aim;
    public GameObject[] platePrefab;
    public ProgressBar progressBar;
    public bool isActiveFireBtn = true;
    public float multiplier;
    public bool isDestroy = false;

    private AudioSource audioPlayer;
    public AudioClip shootAudio;
    public bool playShoot = false;

    public Text scoreText;
    private int score = 0;

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
        StartCoroutine(Destroy5Sec());
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
    IEnumerator Destroy5Sec()
    {
        yield return new WaitForSeconds(5f);
        isActiveFireBtn = true;
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
            Debug.Log("chance Shoot!");
        }
    }

    public void UpdateScore()
    {
        score ++;
        scoreText.text = "Score: " + score;
    }
}
