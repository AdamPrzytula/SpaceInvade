using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class InvaderMovement : MonoBehaviour
{
    public float moveSpd;
    public float moveDownSpd;

    public bool edgeContact;

    public int alienCount;
    public GameObject[] aliens;

    public GameManager gM;

    private void Awake()
    {
        aliens = GameObject.FindGameObjectsWithTag("Invader");
    }

    void Start()
    {
        alienCount=aliens.Length;
    }

    void Update()
    {
        transform.Translate(Vector2.right * moveSpd * Time.deltaTime);

        foreach(GameObject alien in aliens) { 
        if(alien.activeInHierarchy)
            {
                PlayerController playerController = Object.FindFirstObjectByType<PlayerController>();
                if (alien.transform.position.x >= playerController.maxPos && !edgeContact) ChangePos();
                else if (alien.transform.position.x <= playerController.minPos && !edgeContact) ChangePos();
            }

            if (alienCount == 0) gM.StartCoroutine("WaveReset");
        }
    }

    void ChangePos()
    {
        edgeContact = true;
        Invoke("ContactCheck", 0.5f);
        moveSpd *= -1f;
        transform.position= new Vector2(transform.position.x, transform.position.y - moveDownSpd);
    }

    void ContactCheck()
    {
        edgeContact = false;
    }

    public void AliensReset()
    {
        
    }
}
