using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandUntil : MonoBehaviour {

    public float expansionSpeed = 1f;
    public float maxExpansion = 5f;
    
	void Update () {
        if (transform.localScale.x <= 5f || transform.localScale.y <= 5f)
        {
            transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x + (expansionSpeed * Time.deltaTime), 0, 5),
                                               Mathf.Clamp(transform.localScale.y + (expansionSpeed * Time.deltaTime), 0, 5),
                                               transform.localScale.z);
        }
    }
}
