using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongData : MonoBehaviour {

    public float bpm;
    public float delay;
    public float songTime;

    void Start () {
        songTime = delay;
	}
	
	void Update () {
        songTime += Time.deltaTime;
	}
}
