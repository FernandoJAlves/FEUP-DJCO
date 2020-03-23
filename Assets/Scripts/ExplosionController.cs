using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public Animator explosionAnimation;
    // Start is called before the first frame update
    void Start()
    {
        Destroy (gameObject, explosionAnimation.GetCurrentAnimatorStateInfo(0).length); 
    }
}
