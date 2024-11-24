using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector2 moveDir;
    public float speed;

    public System.Action destroyed;
    public GameObject explosion;

    void Update()
    {
        transform.Translate(moveDir*speed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (destroyed != null)
        {
            destroyed.Invoke();
        }

        Instantiate(explosion,transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
