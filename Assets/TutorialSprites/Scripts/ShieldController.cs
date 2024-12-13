using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    SpriteRenderer sprRenderer;
    CapsuleCollider2D col2D;

    [SerializeField] float shieldPower;

    private void Awake()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
        col2D = GetComponent<CapsuleCollider2D>();

        shieldPower = 1f;
    }

    void Update()
    {
        sprRenderer.color=new Color(1f,1f,1f,shieldPower);

        if(shieldPower <= 0f ) { 
            col2D.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        shieldPower -= 0.1f;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        shieldPower -= 0.1f;
    }
}
