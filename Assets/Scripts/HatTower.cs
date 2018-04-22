using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatTower : MonoBehaviour {

    private AudioSource hatSource;
    private SongData songData;
    private SpriteRenderer spriteRenderer;
    private float cooldown;
    private float cooldownRemaining = 0;

    void Start()
    {
        hatSource = gameObject.GetComponent<AudioSource>();
        songData = GameObject.FindGameObjectWithTag("GameController").GetComponent<SongData>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //The period is 30 / bpm
        cooldown = 11 / songData.bpm;
        //Find next beat
        float nextBeatIn = 30 / songData.bpm - (songData.songTime - (Mathf.Floor(songData.songTime / 30 * songData.bpm) * 30 / songData.bpm));
        InvokeRepeating("OnBeat", nextBeatIn, 30 / songData.bpm);
    }

    void Update () {
        cooldownRemaining -= Time.deltaTime;
        if (cooldownRemaining <= 0)
        {
            cooldownRemaining = 0;
            if (Input.GetKeyDown(KeyCode.Z))
            {
                //Calculate the power of the 
                //power = Sqrt(Cos(pi * t))
                float power = Mathf.Pow(Mathf.Abs(Mathf.Cos(songData.songTime * Mathf.PI * songData.bpm / 30)), 2);
                //Play the sound
                hatSource.Play();
                //Log the power to console
                Debug.Log(power.ToString("0.00"));
                //Start the cooldown
                cooldownRemaining = cooldown;
            }
        }
	}

    void OnBeat()
    {
        spriteRenderer.color = Color.black;
        Invoke("ResetColor", Time.fixedDeltaTime * 2);
    }

    void ResetColor()
    {
        spriteRenderer.color = Color.white;
    }
}
