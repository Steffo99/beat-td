using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour {

    public int livesCost = 1;
    public int masks = 1;
    public float baseHealth = 10f;
    public float healthPerSecond = 0.6f;

    private GameStatus gameStatus;
    private SongData songData;
    private float health;

    void Start()
    {
        gameStatus = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameStatus>();
        songData = GameObject.FindGameObjectWithTag("GameController").GetComponent<SongData>();
        health = baseHealth + healthPerSecond * songData.songTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        KickCollision kickCollision = collision.GetComponent("KickCollision") as KickCollision;
        SnareCollision snareCollision = collision.GetComponent("SnareCollision") as SnareCollision;
        if (kickCollision != null)
        {
            health -= kickCollision.damage;
        }
        if (snareCollision != null)
        {
            health -= snareCollision.damage;
            Destroy(snareCollision.gameObject);
        }
    }

    void Update()
    {
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        gameStatus.money += masks;
        Destroy(gameObject);
    }
}
