using UnityEngine;

public class ElectroBotBolt : MonoBehaviour
{
    public float speed = 2.0f;
    public Rigidbody2D body;
    
    void Start() {
        // aim bolt to current player position
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        Vector3 firingDirection = playerPosition - transform.position;
        body.velocity = firingDirection.normalized * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        Debug.Log("ELETRO BOLT HIT SOMETHING!!!");
        Destroy(gameObject);
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}

