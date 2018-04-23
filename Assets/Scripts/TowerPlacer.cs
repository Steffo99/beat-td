using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public GameObject selected = null;
    SpriteRenderer cursorSprite;
    SpriteRenderer towerGhost;

    void Start()
    {
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
        //Check if there's nothing else under the cursor
        Collider2D collider = Physics2D.OverlapPoint(transform.position);
        if (collider == null || collider.tag == "Hit")
        {
            cursorSprite.color = Color.white;
            towerGhost.color = Color.white;
        }
        else
        {
            cursorSprite.color = Color.red;
            towerGhost.color = new Color(1, 1, 1, 0);
        }
        if (Input.GetMouseButtonDown(0))
        {
            //Check if something is selected
            if (selected == null) return;
            //Ensure there is nothing below
            if (collider != null && collider.tag != "Hit") return;
            //Place the item
            Vector3 position = new Vector3(transform.position.x, transform.position.y, 0);
            Instantiate(selected, position, transform.rotation);
        }
	}
}
