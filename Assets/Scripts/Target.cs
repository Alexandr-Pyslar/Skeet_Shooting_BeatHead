using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Target : MonoBehaviour
{
    private Rigidbody2D targetRb;
    private GameManager gameManager;
    public ProgressBar progressBar;
    public float speed = 7.5f;
    public float posX = 1f;
    public float posY = 1f;
    private bool isDestroy = false;




    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        progressBar = GameObject.FindGameObjectWithTag("Aim").GetComponent<ProgressBar>();
        targetRb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(-18.7f, -5.63f, 0);
        targetRb.AddForce(new Vector2(posX, posY) * speed, ForceMode2D.Impulse);
        
    }
    private void Update()
    {

        if (Vector2.Distance(gameManager.aim.transform.position, transform.position) < 0.5f && progressBar.readyToShoot)
        {
            gameManager.isActiveFireBtn = true;
            Destroy(gameObject);
            isDestroy = true;
        }

        if (transform.position.y <= -7f)
        {
            gameManager.isActiveFireBtn = true;
            Destroy(gameObject);          
        }
    }


}
