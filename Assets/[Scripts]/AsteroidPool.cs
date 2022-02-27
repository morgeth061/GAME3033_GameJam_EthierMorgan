using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPool : MonoBehaviour
{
    public float spawnTime;

    public List<GameObject> asteroids;
    private LinkedList<GameObject> inPlayAsteroids;
    private GameObject currentAsteroid;

    private float clock = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        inPlayAsteroids = new LinkedList<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;

        if (clock > spawnTime) //Spawn Asteroid
        {
            clock = 0;
            currentAsteroid = asteroids[0];
            asteroids.RemoveAt(0);

            currentAsteroid.gameObject.SetActive(true);
            currentAsteroid.GetComponent<AsteroidBehaviour>().Setup();
            inPlayAsteroids.AddLast(currentAsteroid);
        }

        if (inPlayAsteroids.Count != 0) //Despawn Asteroid
        {
            if(inPlayAsteroids.First.Value.transform.position.z < 0)
            {
                currentAsteroid = inPlayAsteroids.First.Value;
                inPlayAsteroids.RemoveFirst();

                currentAsteroid.gameObject.SetActive(false);
                currentAsteroid.transform.position = Vector3.zero;
                asteroids.Add(currentAsteroid);
            }
        }
    }
}
