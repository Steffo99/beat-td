using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthFromY : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

	void Start () {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = Mathf.CeilToInt(-transform.position.y * 100);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
