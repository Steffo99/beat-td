using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour {

    public int livesCost = 1;
    public int health = 10;
    public int masks = 1;

    private GameStatus gameStatus;

    void Start()
    {
        gameStatus = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameStatus>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        KickCollision kickCollision = collision.GetComponent("KickCollision") as KickCollision;
        if (kickCollision != null)
        {
            health -= kickCollision.damage;
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
