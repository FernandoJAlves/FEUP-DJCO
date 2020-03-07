using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes : MonoBehaviour
{

    public GameObject PlayerHealth;
    public GameObject Icon;
    private int lifesCounter;
    private int maxLifes;

    private List<GameObject> LifeIcons;

    // Awake is called once the script is loaded
    void Awake()
    {
        LifeIcons = new List<GameObject>();
        maxLifes = PlayerHealth.GetComponent<PlayerHealth>().healthPoints;
        lifesCounter = maxLifes;

        Debug.Log(maxLifes);

        Vector3 defaultPosition = Icon.transform.position;

        for (int i = 0; i < maxLifes; i++) {
            Vector3 position = new Vector3(defaultPosition.x + i * 30, 0, defaultPosition.z);
            GameObject obj = (GameObject)Instantiate(Icon, position, Quaternion.identity);
            obj.transform.SetParent(transform, false);
            obj.SetActive(true);
            LifeIcons.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        lifesCounter = PlayerHealth.GetComponent<PlayerHealth>().healthPoints;

        int lifeIndex = 0;

        for(; lifeIndex < lifesCounter; lifeIndex++) {
            LifeIcons[lifeIndex].SetActive(true);
        }

        for(; lifeIndex < maxLifes; lifeIndex++) {
            LifeIcons[lifeIndex].SetActive(false);
        }

    }
}
