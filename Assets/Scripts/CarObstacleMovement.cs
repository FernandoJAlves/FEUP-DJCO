using UnityEngine;

public class CarObstacleMovement : MonoBehaviour
{
    public float movementSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(-1, 0, 0) * movementSpeed * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        // only destroy if on the left of the screen
        if (transform.position.x <= 0) {
            Destroy(gameObject);
        }
    }
}
