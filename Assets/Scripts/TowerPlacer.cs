using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public GameObject selected = null;

    GameStatus gameStatus;
    TowerSelector towerSelector;
    SpriteRenderer cursorSprite;
    SpriteRenderer towerGhost;

    void Start()
    {
        gameStatus = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameStatus>();
        towerSelector = gameObject.GetComponent<TowerSelector>();
        SpriteRenderer[] spriteRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        {
            if (spriteRenderer.gameObject == gameObject)
            {
                cursorSprite = spriteRenderer;
                continue;
            }
            towerGhost = spriteRenderer;
        }
    }

    void Update () {
        //Check if the player has enough money to place the tower
        bool hasEnoughMoney = gameStatus.money >= gameStatus.towerCosts[towerSelector.index];
        //Check if there's nothing else under the cursor
        Collider2D collider = Physics2D.OverlapPoint(transform.position);
        if (collider == null || collider.tag == "Hit")
        {
            if (hasEnoughMoney)
            {
                cursorSprite.color = Color.white;
            }
            else
            {
                cursorSprite.color = Color.yellow;
            }
            towerGhost.color = new Color(towerGhost.color.r, towerGhost.color.g, towerGhost.color.b, 1);
        }
        else
        {
            cursorSprite.color = Color.red;
            towerGhost.color = new Color(towerGhost.color.r, towerGhost.color.g, towerGhost.color.b, 0);
        }
        if (Input.GetMouseButtonDown(0))
        {
            //Check if the player has enough money
            if (!hasEnoughMoney) return;
            //Ensure there is nothing below
            if (collider != null && collider.tag != "Hit") return;
            //Place the item
            Vector3 position = new Vector3(transform.position.x, transform.position.y, 0);
            Instantiate(selected, position, transform.rotation);
            //Deduct the money 
            gameStatus.money -= gameStatus.towerCosts[towerSelector.index];
            //Increase the costs
            if(gameStatus.towerCosts[towerSelector.index] == 0)
            {
                //TODO: quick hack
                gameStatus.towerCosts = new int[] { 1, 1, 1 };
            }
            else
            {
                gameStatus.towerCosts[towerSelector.index] *= 2;
            }
            
        }
	}
}
