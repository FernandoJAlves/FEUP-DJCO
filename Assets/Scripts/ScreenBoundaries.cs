using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundaries : MonoBehaviour
{

    //The Screen Boundaries
    private Vector2 ScreenBounds;
    private float playerWidth;
    private float playerHeight;

    // Start is called before the first frame update
    void Start()
    {
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        playerHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -1 * ScreenBounds.x, ScreenBounds.x);
        viewPos.y = Mathf.Clamp(viewPos.y, -1 * ScreenBounds.y + 2 * playerHeight, ScreenBounds.y);
        transform.position = viewPos;
    }
}
