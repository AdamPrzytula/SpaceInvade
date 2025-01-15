using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public int livesCounter;
    public Text livesText;

    void Update()
    {
        livesText.text = livesCounter + "x ";

        Color newColor;

        if (livesCounter == 2)
        {
            newColor = Color.yellow;
        }
        else if (livesCounter == 1)
        {
            newColor = Color.red;
        }
        else
        {
            newColor = Color.green;
        }

        livesText.color = newColor;

        GameObject lifeIcon = GameObject.FindGameObjectWithTag("LifeIcon");
        if (lifeIcon != null)
        {
            SpriteRenderer spriteRenderer = lifeIcon.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = newColor;
            }
        }
    }
}
