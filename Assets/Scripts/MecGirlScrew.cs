using UnityEngine;

public class MecGirlScrew : MonoBehaviour
{
    public Vector2 force = new Vector2(-180.0f, 300.0f);
    
    private bool firstTime = true;

    void FixedUpdate () {
        if (firstTime) {
            GetComponent<Rigidbody2D>().AddForce(force);
            firstTime = false;
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        Debug.Log("MEC GIRL SCREW HIT SOMETHING!!!");
        Destroy(gameObject);
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
