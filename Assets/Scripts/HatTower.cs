using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatTower : MonoBehaviour {

    public Sprite standardSprite;
    public Sprite alternateSprite;
    public GameObject projectile;
    public float maxRange = 1.5f;
    public float maxDamage = 4f;

    private AudioSource hatSource;
    private SongData songData;
    private SpriteRenderer spriteRenderer;
    private float cooldown;
    private float cooldownRemaining = 0;
    private bool diagonal = false;

    private Vector3[] diagDirections =
    {
        (Vector3.up + Vector3.left) / 1.414f,
        (Vector3.up + Vector3.right) / 1.414f,
        (Vector3.down + Vector3.left) / 1.414f,
        (Vector3.down + Vector3.right) / 1.414f,
    };

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
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //Calculate the power of the 
            //power = Sqrt(Cos(pi * t))
            float power = Mathf.Abs(Mathf.Cos(songData.songTime * Mathf.PI * songData.bpm / 30)) * ((cooldown - cooldownRemaining) / cooldown);
            //Play the sound
            hatSource.volume = power;
            hatSource.Play();
            //Instantiate the projectiles
            if(diagonal)
            {
                foreach(Vector3 direction in diagDirections)
                {
                    GameObject proj = Instantiate(projectile, transform.position, transform.rotation);
                    proj.transform.localScale = new Vector3(0.5f * power, 0.5f * power, 1);
                    SnareCollision sc = proj.GetComponent<SnareCollision>();
                    sc.direction = direction;
                    sc.maxRange = maxRange * power;
                    sc.damage = Mathf.CeilToInt(maxDamage * power);
                }
            }
            else
            {
                foreach(Vector3 direction in new Vector3[] { Vector3.up, Vector3.down, Vector3.left, Vector3.right })
                {
                    GameObject proj = Instantiate(projectile, transform.position, transform.rotation);
                    proj.transform.localScale = new Vector3(0.5f * power, 0.5f * power, 1);
                    SnareCollision sc = proj.GetComponent<SnareCollision>();
                    sc.direction = direction;
                    sc.maxRange = maxRange * power;
                    sc.damage = Mathf.CeilToInt(maxDamage * power);
                }
            }
            diagonal = !diagonal;
            //Start the cooldown
            cooldownRemaining = cooldown;
            //Change the sprite
            spriteRenderer.sprite = alternateSprite;
            Invoke("OnEndAnimation", Time.fixedDeltaTime * 6);
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
