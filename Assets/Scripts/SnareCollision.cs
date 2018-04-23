using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnareCollision : MonoBehaviour {
    
    public int damage;
    public float maxRange;
    public float speed;
    private float distance = 0;

    private void Update()
    {
        if(distance >= maxRange)
        {
            Destroy(gameObject);
        }
        distance += speed * Time.deltaTime;
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    

}
