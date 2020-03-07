using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3.5f;

    // Start is called before the first frame update
    void Start ()
    {
        Debug.Log("Start Player!"); // here for testing purposes, can be removed later
    }

    // Update is called once per frame
    void Update ()
    {

    }

    // FixedUpdate is recomended when dealing with physics
    void FixedUpdate ()
    {
        // Move Character in the X and Y Axis
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float deltaY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        // Make it move 10 meters per second instead of 10 meters per frame...
        Vector3 vec = new Vector3(deltaX,deltaY, 0);

        // Move the Character:
        transform.Translate(vec);
    }

    // Detects when a collision occurs
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collision Detected!");
        // TODO: Collision logic
    }
}
