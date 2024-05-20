using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyObjs;
    public Transform[] spawnPoints;
    
    public float maxSpawnDelay;
    public float curSpawnDelay;

    public GameObject player;
    
    //UI
    public Text scoreText;
    public Image[] lifeImage;
    public GameObject gameOverSet;

    public bool isLive;

    void Update()
    {
        if (!isLive)
        {
            return;
        }
        curSpawnDelay += Time.deltaTime;

        if (curSpawnDelay > maxSpawnDelay)
        {
            SpawnEnemy();
            maxSpawnDelay = Random.Range(0.5f, 3f);
            curSpawnDelay = 0;
        }

        Player playerLogic = player.GetComponent<Player>();
        scoreText.text = string.Format("{0:n0}", playerLogic.score);
    }

    //life Appear
    public void UpdateLife(int life)
    {
        //Life Disable
        for (int i = 0; i < life; i++)
        {
            lifeImage[i].color = new Color(1, 1, 1, 0);
        }
        
        //Life Active
        for (int i = 0; i < life; i++)
        {
            lifeImage[i].color = new Color(1, 1, 1, 1);
        }
    }
    
    void SpawnEnemy()
    {
        int ranEnemy = Random.Range(0, enemyObjs.Length);
        int ranPoint = Random.Range(0, 5);
        Instantiate(enemyObjs[ranEnemy],
            spawnPoints[ranPoint].position,
            spawnPoints[ranPoint].rotation);
    }

    public void GameOver()
    {
        gameOverSet.SetActive(true);
    }

    public void GameRetry()
    {
        SceneManager.LoadScene(0);
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }
    
    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }
}
