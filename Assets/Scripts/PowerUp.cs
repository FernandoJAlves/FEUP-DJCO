using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public int timeLimit = 10;
    public float movementSpeed = 1f;

    private void Update()
    {
        transform.position += new Vector3(-1, 0, 0) * movementSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Player")
        {
            StartCoroutine(applyPowerUp(hitInfo));
        }
    }


    IEnumerator applyPowerUp(Collider2D player)
    {
        ActivatePowerUp(player);

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        Component[] sprites = GetComponentsInChildren<SpriteRenderer>();
        Component[] colliders = GetComponentsInChildren<Collider2D>();

        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.enabled = false;
        }

        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false;
        }

        yield return new WaitForSeconds(timeLimit);

        DeactivatePowerUp(player);
        Destroy(gameObject);
    }

    protected abstract void ActivatePowerUp(Collider2D player);

    protected abstract void DeactivatePowerUp(Collider2D player);
}
