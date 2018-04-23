using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOnBeat : MonoBehaviour {

    public GameObject target;
    public float beats;

    private float period;
    private float cooldown;
    private SongData songData;

    void Start()
    {
        songData = GameObject.FindGameObjectWithTag("GameController").GetComponent<SongData>();
        period = beats * 60 / songData.bpm;
        cooldown = period;
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            Instantiate(target, transform.position, transform.rotation);
            cooldown = period;
        }
    }
}
