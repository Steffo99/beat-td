using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeEnemyMovement : MonoBehaviour {

    public Vector3[] path;
    public float speed = 1;

    public Sprite rightSprite;
    public Sprite upSprite;
    public Sprite downSprite;

    private int nextStop = 0;
    private GameStatus gameStatus;
    private SongData songData;
    private SpriteRenderer spriteRenderer;

	void Start () {
        gameStatus = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameStatus>();
        songData = GameObject.FindGameObjectWithTag("GameController").GetComponent<SongData>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
	
	void Update () {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, path[nextStop], speed * Mathf.Pow(Mathf.Cos(songData.songTime * Mathf.PI * songData.bpm / 240), 2) * Time.deltaTime);
        Vector3 difference = newPosition - transform.position;
        if (difference.y > 0)
        {
            spriteRenderer.sprite = upSprite;
        }
        else if (difference.y < 0)
        {
            spriteRenderer.sprite = downSprite;
        }
        else
        {
            spriteRenderer.sprite = rightSprite;
        }

        if (difference.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (difference.x > 0)
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
