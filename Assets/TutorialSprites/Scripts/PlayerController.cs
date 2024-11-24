using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
public class PlayerController : MonoBehaviour
{
    [SerializeField] public float minPos, maxPos;

    public static PlayerController instance;
    public float moveSpeed;
    float moveInput;

    public Projectile laser;
    public bool reloading;
    public int lives, dfltlives;

    public GameObject explosion;
    public GameManager gM;
    public LivesManager livesMan;

    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerLives"))
        {
            lives = PlayerPrefs.GetInt("PlayerLives");
        }
    }
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right*moveSpeed*moveInput*Time.deltaTime);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minPos, maxPos), transform.position.y);
    
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        PlayerPrefs.SetInt("PlayerLives", lives);
        livesMan.livesCounter = lives;
    }


    void Shoot()
    {
        if (!reloading)
        {
            Projectile projectile = Instantiate(laser,transform.position,transform.rotation);
            projectile.destroyed += DestroyLaser;
            reloading = true;
        }
    }

    void DestroyLaser()
    {
        reloading = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Invader" || other.gameObject.tag == "Enemy Laser")
        {
            if (lives > 1)
            {
                lives--;
                livesMan.livesCounter--;
                gM.StartCoroutine("PlayerRespawn");
            }
            else
            {
                gM.GameOver();  
            }

            Instantiate(explosion,transform.position,transform.rotation);
            

        }
    }
}
