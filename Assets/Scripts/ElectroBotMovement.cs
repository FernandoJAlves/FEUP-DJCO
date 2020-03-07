using UnityEngine;

public class ElectroBotMovement : MonoBehaviour
{
    private Transform playerTransform;

    public enum ElectroBotState
    {
        TOP, BOTTOM, RISING, FALLING
    }

    // bot movement state
    public ElectroBotState botState = ElectroBotState.TOP;

    // movement variables
    public float movementSpeed = 0.7f;
    private float timeInCurrentState = 0f;
    private float maxTimeHorizontal = 1.5f;
    private float maxTimeDiagonal = 0.2f;

    // Bot destruction score
    public int destructionScore = 30;

    void Start()
    {
        // create a reference to the player position
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {

        switch (botState)
        {
            case ElectroBotState.TOP:
            case ElectroBotState.BOTTOM:
                if (timeInCurrentState >= maxTimeHorizontal)
                    changeState();
                break;

            case ElectroBotState.FALLING:
            case ElectroBotState.RISING:
                if (timeInCurrentState >= maxTimeDiagonal)
                    changeState();
                break;

            default:
                Debug.LogError("INVALID STATE!");
                break;
        }

        timeInCurrentState += Time.deltaTime;
    }

    private void FixedUpdate()
    {

        switch (botState)
        {
            case ElectroBotState.TOP:
            case ElectroBotState.BOTTOM:
                transform.position += new Vector3(-1, 0, 0) * movementSpeed * Time.deltaTime;
                break;
            case ElectroBotState.FALLING:
                transform.position += new Vector3(-1, -3, 0) * movementSpeed * Time.deltaTime;
                break;

            case ElectroBotState.RISING:
                transform.position += new Vector3(-1, 3, 0) * movementSpeed * Time.deltaTime;
                break;
        }

    }

    private void changeState()
    {
        switch (botState)
        {
            case ElectroBotState.TOP:
                botState = ElectroBotState.FALLING;
                break;
            case ElectroBotState.FALLING:
                botState = ElectroBotState.BOTTOM;
                break;
            case ElectroBotState.BOTTOM:
                botState = ElectroBotState.RISING;
                break;
            case ElectroBotState.RISING:
                botState = ElectroBotState.TOP;
                break;
            default:
                Debug.LogError("INVALID STATE!");
                break;
        }

        timeInCurrentState = 0f;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("ElectroBot collided with " + hitInfo.name);
        GameStateController.instance.Score(this.destructionScore);
        Destroy(gameObject);
    }

}
