﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickTower : MonoBehaviour {

    public Sprite standardSprite;
    public Sprite alternateSprite;
    public GameObject collisionObject;

    private AudioSource kickSource;
    private SongData songData;
    private SpriteRenderer spriteRenderer;
    private float cooldown;
    private float cooldownRemaining = 0;

    void Start()
    {
        kickSource = gameObject.GetComponent<AudioSource>();
        songData = GameObject.FindGameObjectWithTag("GameController").GetComponent<SongData>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //The period is 120 / bpm
        cooldown = 44 / songData.bpm;
        //Find next beat
        float nextBeatIn = 120 / songData.bpm - (songData.songTime - (Mathf.Floor(songData.songTime / 120 * songData.bpm) * 120 / songData.bpm));
        InvokeRepeating("OnBeat", nextBeatIn, 120 / songData.bpm);
    }

    void Update () {
        cooldownRemaining -= Time.deltaTime;
        if (cooldownRemaining <= 0)
        {
            cooldownRemaining = 0;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            //Calculate the power of the 
            //power = Sqrt(Cos(pi * t))
            float power = Mathf.Pow(Mathf.Abs(Mathf.Cos(songData.songTime * Mathf.PI * songData.bpm / 120)) * ((cooldown - cooldownRemaining) / cooldown), 2);
            //Create the hitbox based on the power
            GameObject hit = Instantiate(collisionObject, transform.position, transform.rotation);
            hit.transform.localScale = new Vector3(power * 1.5f, power * 1.5f, 1);
            //Play the sound
            kickSource.volume = power;
            kickSource.Play();
            //Start the cooldown
            cooldownRemaining = cooldown;
            //Change the sprite
            spriteRenderer.sprite = alternateSprite;
            Invoke("OnEndAnimation", Time.fixedDeltaTime * 20);
        }
	}

    void OnEndAnimation()
    {
        spriteRenderer.sprite = standardSprite;
    }

    void OnBeat()
    {
        spriteRenderer.color = Color.yellow;
        Invoke("ResetColor", Time.fixedDeltaTime * 2);
    }

    void ResetColor()
    {
        spriteRenderer.color = Color.white;
    }

}
