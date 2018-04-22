using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEverySeconds : MonoBehaviour {

    public GameObject target;
    public float period;

    private float cooldown = 0;
    
	void Update () {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            Instantiate(target, transform.position, transform.rotation);
            cooldown = period;
        }
	}
}
