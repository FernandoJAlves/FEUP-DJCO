using UnityEngine;

public class MecGirlMovement : MonoBehaviour
{


    // movement variables
    public float movementSpeed = 0.7f;

    // Bot destruction score
    public int destructionScore = 30;

    void Start() {

    }

    void Update() {

    }

    private void FixedUpdate() {
        transform.position += new Vector3(-1, 0, 0) * movementSpeed * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        // only destroy if on the left of the screen
        if (transform.position.x <= 0) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("MecGirl collided with " + hitInfo.name);
        GameStateController.instance.Score(this.destructionScore);
        Destroy(gameObject);
    }

}
