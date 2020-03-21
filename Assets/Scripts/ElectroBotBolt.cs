using UnityEngine;

public class ElectroBotBolt : MonoBehaviour
{
    public float speed = 2.0f;
    public Rigidbody2D body;
    public SpriteRenderer sprite;
    
    void Start() {
        // aim bolt to current player position
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        Vector3 firingDirection = playerPosition - transform.position;
        body.velocity = firingDirection.normalized * speed;
        RotateBolt(firingDirection, playerPosition);
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        Debug.Log("ELETRO BOLT HIT SOMETHING!!!");
        Destroy(gameObject);
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    void RotateBolt(Vector3 firingDirection, Vector3 playerPosition) {
        Vector3 aimPosition = new Vector3(-1,0,0);
        float angle = 0;

        if (playerPosition.x > transform.position.x) {
            sprite.flipX = true;
            aimPosition *= -1;
            angle = Vector3.Angle(firingDirection, aimPosition);

            if (playerPosition.y < transform.position.y) {
                angle *= -1;
            }
        }

        else if (playerPosition.x < transform.position.x) {
            angle = Vector3.Angle(firingDirection, aimPosition);

            if (playerPosition.y > transform.position.y) {
                angle *= -1;
            }
        }

        transform.Rotate(0, 0, angle);
    }
}

