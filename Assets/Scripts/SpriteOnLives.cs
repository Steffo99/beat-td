using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOnLives : MonoBehaviour {

    public Sprite higherSprite;
    public Sprite lowerSprite;
    public int livesThreshold;

    private GameStatus gameStatus;
    private SpriteRenderer spriteRenderer;

	void Start () {
        gameStatus = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameStatus>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	void Update () {
		if(gameStatus.lives >= livesThreshold)
        {
            spriteRenderer.sprite = higherSprite;
        }
        else
        {
            spriteRenderer.sprite = lowerSprite;
        }
	}
}
