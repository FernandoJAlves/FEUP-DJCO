using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 4.0f;
    private float extraSpeed = 1;
    public Rigidbody2D body;

    // Start is called every time a bolt is set as active
    void OnEnable() {
        body.velocity = transform.right * speed * extraSpeed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        gameObject.SetActive(false);
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    public void setExtraSpeed(float extra) {
        extraSpeed = extra;
    }
}
