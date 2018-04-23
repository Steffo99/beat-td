using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyMovement : MonoBehaviour {

    public Vector3[] path;
    public float speed = 1;

    private int nextStop = 0;
    private GameStatus gameStatus;
    private SongData songData;

	void Start () {
        gameStatus = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameStatus>();
        songData = GameObject.FindGameObjectWithTag("GameController").GetComponent<SongData>();
    }

    void Update()
    {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, path[nextStop], speed * Mathf.Pow(Mathf.Sin(songData.songTime * Mathf.PI * songData.bpm / 480), 10) * Time.deltaTime);
        if ((newPosition - transform.position).x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if ((newPosition - transform.position).x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Vector3.Distance(transform.position, path[nextStop]) == 0)
        {
            nextStop++;
            if (nextStop >= path.Length)
            {
                gameStatus.EnemyFinishedPath(gameObject);
            }
        }
        transform.position = newPosition;
    }
}
