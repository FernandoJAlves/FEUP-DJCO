using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{

    // The current health the player has.
    public int healthPoints = 3;

    private BoxCollider2D boxCollider;
    private SpriteRenderer[] spriteRenderers;
    private GameObject parent;
    
    private float timeToEnable = 0f;
    private float timeInDamaged = 2f;

    private float timeInFlicker = 0f;
    private float maxTimeInFlicker = 0.1f;

    private void Start() {
        boxCollider = GetComponentInParent<BoxCollider2D>();

        parent = transform.parent.gameObject;
        spriteRenderers = Array.ConvertAll(parent.GetComponentsInChildren(typeof(SpriteRenderer)), item => item as SpriteRenderer);
    }

    private void Update() {
    
        if (!boxCollider.enabled) {
            // re-enable the collider and stop flickering
            if (Time.time > timeToEnable) {
                boxCollider.enabled = true;
                enableSprites();
            }
            // flicker the player sprite
            else {
                FlickerPlayer();
            }
        }
    }

    public void TakeDamage() {
        Debug.Log("Took Damage");

        this.healthPoints--;

        if (this.healthPoints <= 0) {
            GameStateController.instance.GameOver();
        } else {
            boxCollider.enabled = false;
            timeToEnable = Time.time + timeInDamaged;
        }
    }

    public void FlickerPlayer() {
        if (Time.time > timeInFlicker) {
            timeInFlicker = Time.time + maxTimeInFlicker;
            toggleSprites();
        }
    }

    public void toggleSprites() {
        for (int index = 0; index < spriteRenderers.Length; index++) {
            spriteRenderers[index].enabled = !spriteRenderers[index].enabled;
        }
    }

    public void enableSprites() {
        for (int index = 0; index < spriteRenderers.Length; index++) {
            spriteRenderers[index].enabled = true;
        }
    }
}
