using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackgroundScript : MonoBehaviour
{
    private Renderer background;

    [SerializeField]
    private float scrollSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Renderer> ();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2 (scrollSpeed * Time.deltaTime, 0);
 
        background.material.mainTextureOffset += offset;
    }
}
