using UnityEngine;

public class MecGirlScrew : MonoBehaviour
{
    public Vector2 force = new Vector2(-180.0f, 300.0f);
    public float timeBetweenRotates = 0.2f;

    private float nextRotate = 0f;
    private bool firstTime = true;

    private void Update() {

        if (Time.time > nextRotate) {
            nextRotate = Time.time + timeBetweenRotates;
            transform.Rotate(Vector3.forward * 90);
        }

    }

    void FixedUpdate () {
        if (firstTime) {
            GetComponent<Rigidbody2D>().AddForce(force);
            firstTime = false;
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        // Debug.Log("MEC GIRL SCREW HIT SOMETHING!!!");
        Destroy(gameObject);
    }

    void OnBecameInvisible() {
        if (transform.position.y < 0) {
            Destroy(gameObject);
        }
    }
}
