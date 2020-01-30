using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button fireBtn;
    public GameObject aim;
    public GameObject platePrefab;
    public ProgressBar progressBar;
    public bool isActiveFireBtn = true;
    public float multiplier;
    public bool isDestroy = false;




    private void Start()
    {
        progressBar = GameObject.FindGameObjectWithTag("Aim").GetComponent<ProgressBar>();

    }
    void Update()
    {
        if (isActiveFireBtn)
        {
            fireBtn.gameObject.SetActive(true);
            StopAllCoroutines();
        }
        
    }

    public void SpawnPlate()
    { 
        Instantiate(platePrefab, platePrefab.transform.position, platePrefab.transform.rotation);
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
}
