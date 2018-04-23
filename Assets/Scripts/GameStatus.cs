using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour {

    public int money = 0;
    public int lives = 10;

    public GameObject moneyTextObject;
    private Text moneyText;

    void Start()
    {
        moneyText = moneyTextObject.GetComponent<Text>();
    }

    void Update()
    {
        moneyText.text = money.ToString();
    }

    public void EnemyFinishedPath(GameObject enemy)
    {
        lives -= enemy.GetComponent<EnemyStatus>().livesCost;
        Destroy(enemy);
    }
}
