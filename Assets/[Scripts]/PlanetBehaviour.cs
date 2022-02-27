using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehaviour : MonoBehaviour
{
    public float movementSpeed;
    public GameObject GameController;
    private float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, 1000 - movementSpeed * timer);

        if (transform.position.z < 275.0f)
        {
            movementSpeed = 0;
            GameController.GetComponent<GameController>().moveSpeed = 0;
            GameController.GetComponent<GameController>().ShowEndUI(true);
        }
    }
}
