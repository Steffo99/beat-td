using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignToGridContinuous : MonoBehaviour {
	
	void Update () {
        float x = Mathf.Round(transform.position.x);
        float y = Mathf.Round(transform.position.y);
        float z = Mathf.Round(transform.position.z);
        transform.position = new Vector3(x, y, z);
    }
}
