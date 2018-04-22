using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickCollision : MonoBehaviour {

    public int frames;
    public int damage;

	void Start () {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)));
        Invoke("Disappear", Time.fixedDeltaTime * frames);
	}
	
    void Disappear ()
    {
        Destroy(gameObject);
    }

}
