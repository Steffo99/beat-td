using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFromCost : MonoBehaviour {

    TowerSelector towerSelector;
    GameStatus gameStatus;
    Text text;

	// Use this for initialization
	void Start () {
        towerSelector = GetComponentInParent<TowerSelector>();
        text = GetComponent<Text>();
        gameStatus = GetComponentInParent<GameStatus>();
	}
	
	void Update () {
        text.text = gameStatus.towerCosts[towerSelector.index].ToString();
	}
}
