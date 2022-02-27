using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    public GameObject gameController;

    private int randomStart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - gameController.GetComponent<GameController>().moveSpeed);
    }

    public void Setup()
    {
        randomStart = Random.Range(1, 4);

        if (randomStart == 1)
        {
            transform.position = new Vector3(-4.0f, 0.65f, 67.5f);
        }
        else if (randomStart == 2)
        {
            transform.position = new Vector3(-2.5f, 0.65f, 67.5f);
        }
        else if (randomStart == 3)
        {
            transform.position = new Vector3(-1.0f, 0.65f, 67.5f);
        }
    }
}
