using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public GameObject selected = null;
    SpriteRenderer cursorSprite;

    void Start()
    {
        cursorSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update () {
        //Check if there's nothing else under the cursor
        Collider2D collider = Physics2D.OverlapPoint(transform.position);
        if (collider == null)
        {
            cursorSprite.color = Color.white;
        }
        else
        {
            cursorSprite.color = Color.red;
        }
        if (Input.GetMouseButtonDown(0))
        {
            //Check if something is selected
            if (selected == null) return;
            //Ensure there is nothing below
            if (collider != null) return;
            //Place the item
            Vector3 position = new Vector3(transform.position.x, transform.position.y, 0);
            Instantiate(selected, position, transform.rotation);
        }
	}
}
