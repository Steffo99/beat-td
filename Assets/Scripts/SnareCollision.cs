using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnareCollision : MonoBehaviour {
    
    public int damage;
    public float maxRange;
    public float speed;
    public Vector3 direction = Vector3.down;
    private float distance = 0;

    private void Update()
    {
        if(distance >= maxRange)
        {
            Destroy(gameObject);
        }
        distance += speed * Time.deltaTime;
        transform.Translate(direction * speed * Time.deltaTime);
    }
    

}
