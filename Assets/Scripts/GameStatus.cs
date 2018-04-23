using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour {

    public int money = 0;
    public int lives = 10;

    public int[] towerCosts = new int[] { 0, 0, 0 };

    public GameObject moneyTextObject;

    private SongData songData;
    private Text moneyText;
    private bool gameOver;

    void Start()
    {
        moneyText = moneyTextObject.GetComponent<Text>();
        songData = GetComponent<SongData>();
    }

    void Update()
    {
        if (moneyText != null)
        {
            moneyText.text = money.ToString();
        }
        if (lives <= 0 && !gameOver)
        {
            GameOver();
        }
        else if(gameOver)
        {
            GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = "You survived " + songData.songTime.ToString("0.0") + " seconds.";
            Destroy(gameObject);
        }
    }

    void GameOver()
    {
        gameOver = true;
        DontDestroyOnLoad(gameObject);
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        Time.timeScale = 0;
        GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene("Over");
    }

    public void EnemyFinishedPath(GameObject enemy)
    {
        lives -= enemy.GetComponent<EnemyStatus>().livesCost;
        Destroy(enemy);
    }
}
