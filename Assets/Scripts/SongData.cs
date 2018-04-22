using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongData : MonoBehaviour {

    public float bpm;
    public float delay;
    public float songTime;
    private AudioSource song;

    void Start () {
        songTime = delay;
        song = GetComponent<AudioSource>();
        song.Play();
	}
	
	void Update () {
        songTime += Time.deltaTime;
	}
}
