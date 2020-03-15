using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltGun : MonoBehaviour
{

    public Transform FirePoint;
    public GameObject boltPrefab;

    private float extraSpeed = 1;
    private float shootingAngle = 0;

    // Start is called before the first frame
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !PauseMenu.GameIsPaused)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        float maxAngle = shootingAngle;
        float minAngle = 0 - maxAngle;

        for (float angle = minAngle; angle <= maxAngle; angle += 45)
        {
            GameObject bolt = ObjectPooler.sharedInstance.GetPooledObject();
            if (bolt != null)
            {
                bolt.transform.position = FirePoint.position;
                bolt.transform.rotation = FirePoint.rotation;
                bolt.transform.Rotate(0,0,angle);

                Bullet bulletScript = bolt.GetComponent<Bullet>();

                bulletScript.setExtraSpeed(extraSpeed);
                
                bolt.SetActive(true);

                bulletScript.setRotation(angle);
            }
        }

    }

    public void multiplySpeed(float speedFactor)
    {
        extraSpeed *= speedFactor;
    }

    public void divideSpeed(float speedFactor)
    {
        extraSpeed /= speedFactor;
    }

    public void increaseAngle(float angle)
    {
        shootingAngle += angle;
    }

    public void decreaseAngle(float angle)
    {
        shootingAngle -= angle;
    }

    public float getAngle() {
        return shootingAngle;
    }
}
