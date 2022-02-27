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
        transform.Rotate(new Vector3(0.5f * Time.deltaTime, 1.5f * Time.deltaTime, 0), Space.World);

        if (transform.position.z < 150.0f)
        {
            //movementSpeed = 0;
            GameController.GetComponent<GameController>().moveSpeed = 0;
            GameController.GetComponent<GameController>().ShowEndUI(true);
        }
    }
}
