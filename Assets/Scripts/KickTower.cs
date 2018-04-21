using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickTower : MonoBehaviour {

    private AudioSource kickSource;
    private SongData songData;
    private float cooldown;
    private float cooldownRemaining = 0;

    void Start()
    {
        kickSource = gameObject.GetComponent<AudioSource>();
        songData = GameObject.FindGameObjectWithTag("GameController").GetComponent<SongData>();
        //The period is 120 / bpm
        cooldown = 44 / songData.bpm;
    }

    void Update () {
        cooldownRemaining -= Time.deltaTime;
        if (cooldownRemaining <= 0)
        {
            cooldownRemaining = 0;
            if (Input.GetKeyDown(KeyCode.X))
            {
                //Calculate the power of the 
                //power = Sqrt(Cos(pi * t))
                float power = Mathf.Pow(Mathf.Abs(Mathf.Cos(songData.songTime * Mathf.PI * songData.bpm / 120)), 2);
                //Play the sound
                kickSource.Play();
                //Log the power to console
                Debug.Log(power.ToString("0.00"));
                //Start the cooldown
                cooldownRemaining = cooldown;
            }
        }
	}
}
