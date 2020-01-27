using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTarget : MonoBehaviour
{
    public bool isProgress = false;
    private AudioSource playerAudio;
    public AudioClip shootSound;
    public GameObject platePrefab;
    public ProgressBar progressBar;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        progressBar = GameObject.FindGameObjectWithTag("Aim").GetComponent<ProgressBar>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(progressBar.currentAmount / 100);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Target"))
        {
            isProgress = true;
        }
                if (progressBar.readyToShoot)
        {
            playerAudio.PlayOneShot(shootSound, 0.2f);
        }

        Debug.Log("readyToShoot: " + progressBar.readyToShoot + "  isProgress: " + isProgress + "  currentAmount: " + progressBar.currentAmount / 100);
        //Destroy(platePrefab.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        progressBar.currentAmount = 0;
        isProgress = false;
        
    }


}
