using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool paused;

    public GameObject gOMenu;

    public PlayerController player;
    public ScoreManager scoreMan;

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("PlayerLives", player.dfltlives);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && player.gameObject.activeInHierarchy)
        {
            paused = !paused;
            GamePaused();
        }
    }



    void GamePaused()
    {
         if (paused) PauseGame();
         else ResumeGame();
    }

    void PauseGame()
    {
        Time.timeScale= 0f;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    void ClearScreen()
    {
        foreach(var laser in GameObject.FindGameObjectsWithTag("Enemy Laser"))
            {
                Destroy(laser.gameObject);
            }
    }

    IEnumerator PlayerRespawn()
    {
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        PauseGame();
        ClearScreen();
        yield return new WaitForSecondsRealtime(3f);
        ResumeGame();
        player.gameObject.SetActive(true);

    }

    IEnumerator WaveReset()
    {
            yield return new WaitForSeconds(0.3f);
            PauseGame();
            ClearScreen();
            yield return new WaitForSecondsRealtime(3f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            ResumeGame();
    }

    public void GameOver()
    {
        player.gameObject.SetActive(false);
            PauseGame();
            gOMenu.SetActive(true);
    }

    public void GameReset()
    {
        PlayerPrefs.SetInt("PlayerLives", player.dfltlives);
        PlayerPrefs.SetFloat("Score", 0);

        player.lives = 3;
        scoreMan.scoreCount= 0;

        SceneManager.LoadScene(1);
        ResumeGame();
    }
}
