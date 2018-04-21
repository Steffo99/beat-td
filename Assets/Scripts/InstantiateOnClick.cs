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
                Vector3 position = new Vector3(transform.position.x, transform.position.y, 0);
                Instantiate(original, position, transform.rotation);
            }
        }
	}
}
