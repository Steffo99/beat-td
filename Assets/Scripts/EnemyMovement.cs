using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Vector3[] path;
    public float speed = 1;

    private int nextStop = 0;
    private GameStatus gameStatus;

	void Start () {
        gameStatus = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameStatus>();
    }
	
	void Update () {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, path[nextStop], speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, newPosition) == 0)
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
