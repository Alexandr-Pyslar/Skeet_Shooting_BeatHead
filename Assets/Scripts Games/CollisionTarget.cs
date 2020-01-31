using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTarget : MonoBehaviour
{
    public bool isProgress = false;
    public GameObject platePrefab;
    public ProgressBar progressBar;

    void Start()
    {
        progressBar = GameObject.FindGameObjectWithTag("Aim").GetComponent<ProgressBar>();
    }

    // Цель в прицеле
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Target"))
        {
            isProgress = true;
        }
    }

    // Сброс прогресс бара, если цель не в прицеле
    private void OnTriggerExit2D(Collider2D collision)
    {
        progressBar.currentAmount = 0;
        isProgress = false;    
    }


}
