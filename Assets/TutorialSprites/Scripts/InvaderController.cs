using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderController : MonoBehaviour
{
    public GameObject laser;
    public GameObject explosion;

    public int points;
    ScoreManager scoreMan;

    InvaderMovement invManager;

    private void Awake()
    {
        invManager = GetComponentInParent<InvaderMovement>();
        scoreMan = FindObjectOfType<ScoreManager>();
    }

    void Start()
    {
        InvokeRepeating("ShotRandomiser", Random.Range(1f, 5f), 1f);
    }

    void Update()
    {
        Debug.DrawRay(transform.position, Vector2.down, Color.red);
    }

    void Shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position - transform.up, Vector2.down);

        if (hit.collider.tag != "Invader")
        {
            if(gameObject.activeInHierarchy)
            {
                Vector3 laserSpawnPosition = transform.position - new Vector3(0, 0.5f, 0);
                Instantiate(laser, laserSpawnPosition, transform.rotation);
            }
        }
    }

    void ShotRandomiser()
    {
        if(Random.Range(0, 10) >= 9)
        {
            Shoot();    
        }
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Laser")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            invManager.alienCount--;
            scoreMan.AddScore(points);
            gameObject.SetActive(false);
        }
    }
}
