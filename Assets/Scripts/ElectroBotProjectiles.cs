using UnityEngine;

public class ElectroBotProjectiles : MonoBehaviour
{

    public float timeSinceLastShot = 0f;
    public float maxTimeBetweenShots = 2f; // fire once every 2 seconds

    public GameObject eletroBotBoltPrefab;

    public SpriteRenderer spriteRenderer;
    public GameObject helix;
    public Sprite[] sprites;

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= maxTimeBetweenShots)
        {
            // now the bot should fire
            timeSinceLastShot = 0f;
            // Aim the Player
            UpdateAim();
            // FIRE!
            Shoot();
        }
    }

    public void Shoot()
    {
        Debug.Log("FIRE!!!");
        Instantiate(eletroBotBoltPrefab, transform.position, Quaternion.identity);
    }

    void UpdateAim()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        Vector3 botPosition = transform.position;
        Vector3 aimPosition = new Vector3(-1,0,0);
        Vector3 helixPosition = helix.transform.localPosition;

        bool flip = false;

        if (playerPosition.x > botPosition.x) {
            flip = true;
            aimPosition.x *= -1;
            helixPosition.x *= -1;
            helix.transform.localPosition = helixPosition;
        }

        spriteRenderer.flipX = flip;

        if (playerPosition.y >= botPosition.y)
        {
            spriteRenderer.sprite = sprites[0];
            return;
        }

        float angle = Vector3.Angle(playerPosition, aimPosition);

        if (0 < angle && angle <= 22.5)
        {
            spriteRenderer.sprite = sprites[1];
            return;
        }

        if (22.5 < angle && angle <= 45)
        {
            spriteRenderer.sprite = sprites[2];
            return;
        }

        if (45 < angle && angle <= 67.5)
        {
            spriteRenderer.sprite = sprites[3];
            return;
        }

        if (67.5 < angle && angle <= 90)
        {
            spriteRenderer.sprite = sprites[4];
            return;
        }
    }
}
