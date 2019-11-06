using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SP_SceneManager : MonoBehaviour
{
    public Text gameOverText;
    public Button retryButton;

    public GameObject turret;

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Minion").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("Minion")[i]);                    //Destroys all minions in scene
        }
        GetComponent<SP_EnemySpawner>().enabled = false;                                //Disables the enemy spawener
    }

    public void Retry()
    {
        SceneManager.LoadScene("SP_Main");
    }
}
