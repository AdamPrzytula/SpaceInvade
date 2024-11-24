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
    }
}
