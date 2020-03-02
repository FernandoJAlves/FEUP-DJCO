using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 4.0f;

    // Start is called every time a bolt is set as active
    void Update() {
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
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
}
