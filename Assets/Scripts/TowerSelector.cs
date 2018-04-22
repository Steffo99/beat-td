using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour {

    public GameObject[] towerList;

    private int index;
    private TowerPlacer towerPlacer;
    private SpriteRenderer towerGhost;

	void Start () {
        index = 0;
        towerPlacer = gameObject.GetComponent<TowerPlacer>();
        SpriteRenderer[] spriteRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer spriteRenderer in spriteRenderers)
        {
            if(spriteRenderer.gameObject == gameObject)
            {
                continue;
            }
            towerGhost = spriteRenderer;
        }
	}
	
	void Update () {
		if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            //Go to the next tower
            index++;
            if (index >= towerList.Length)
            {
                index = 0;
            }
            towerPlacer.selected = towerList[index];
            towerGhost.sprite = towerList[index].GetComponent<SpriteRenderer>().sprite;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            //Go to the previous tower
            index--;
            if (index < 0)
            {
                index = towerList.Length - 1;
            }
            towerPlacer.selected = towerList[index];
            towerGhost.sprite = towerList[index].GetComponent<SpriteRenderer>().sprite;
        }
	}
}
