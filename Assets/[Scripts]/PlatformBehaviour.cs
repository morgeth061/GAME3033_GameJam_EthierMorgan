using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum platformType
{
    TUBE,
    PLATFORM,
    RAIL
}

public class PlatformBehaviour : MonoBehaviour
{
    public platformType type = platformType.PLATFORM;
    private float moveSpeed;

    public GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = gameController.GetComponent<GameController>().moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - moveSpeed);

        if (transform.position.z < -10 && type == platformType.PLATFORM)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 45.0f);
        }
        else if(transform.position.z < -10 && type != platformType.PLATFORM)
        {
            Destroy(gameObject);
        }
        
    }
}
