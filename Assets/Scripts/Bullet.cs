using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 4.0f;
    public Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
}
