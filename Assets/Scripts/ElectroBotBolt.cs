using UnityEngine;

public class ElectroBotBolt : MonoBehaviour
{
    public float speed = 4.0f;
    public Rigidbody2D body;
    
    // Start is called before the first frame update
    void Start() {
        body.velocity = -transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("ELETRO BOLT HIT SOMETHING!!!");
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

