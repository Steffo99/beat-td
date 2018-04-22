using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnareTower : MonoBehaviour {

    private AudioSource snareSource;
    private SongData songData;
    private SpriteRenderer spriteRenderer;
    private float cooldown;
    private float cooldownRemaining = 0;

    void Start()
    {
        snareSource = gameObject.GetComponent<AudioSource>();
        songData = GameObject.FindGameObjectWithTag("GameController").GetComponent<SongData>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //The period is 120 / bpm
        cooldown = 44 / songData.bpm;
        //Find next beat
        float nextBeatIn = 120 / songData.bpm - (songData.songTime - (Mathf.Floor((songData.songTime + 60 / songData.bpm) / 120 * songData.bpm) * 120 / songData.bpm));
        InvokeRepeating("OnBeat", nextBeatIn, 120 / songData.bpm);
    }

    void Update () {
        cooldownRemaining -= Time.deltaTime;
        if (cooldownRemaining <= 0)
        {
            cooldownRemaining = 0;
            if (Input.GetKeyDown(KeyCode.C))
            {
                //Calculate the power of the 
                //power = Sqrt(Cos(pi * t))
                float power = Mathf.Pow(Mathf.Abs(Mathf.Sin(songData.songTime * Mathf.PI * songData.bpm / 120)), 2);
                //Play the sound
                snareSource.Play();
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
