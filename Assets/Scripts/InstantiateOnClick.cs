using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOnClick : MonoBehaviour
{
    public GameObject original = null;

	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            if (original != null)
            {
                Instantiate(original, transform.position, transform.rotation);
            }
        }
	}
}
