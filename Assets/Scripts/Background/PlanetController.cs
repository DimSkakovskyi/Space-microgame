using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public GameObject[] Planets;// an arrat of planet prefabs

    //Queue to hold the planets
    Queue<GameObject> availablePlanets = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //add the planets to the Queue
        for (int i = 0; i < Planets.Length; i++)
        {
            availablePlanets.Enqueue(Planets[i]);
        }

        InvokeRepeating("MovePlanetDown", 0, 20f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Function to dequeue a planet and make it scroll down
    void MovePlanetDown()
    {

        if (availablePlanets.Count == 0)
        {
            EnqueuePlanets();
            return;
        }

        //get a planet from queue
        GameObject aPlanet = availablePlanets.Dequeue();

        //set the planet isMoving to true
        aPlanet.GetComponent<Planet>().isMoving = true;
    }

    //function to enqueue planets that are below the screen and are not moving
    void EnqueuePlanets()
    {
        foreach (GameObject aPlanet in Planets)
        {
            if ((aPlanet.transform.position.y < 0) && (!aPlanet.GetComponent<Planet>().isMoving))
            {
                aPlanet.GetComponent<Planet>().ResetPosition();

                availablePlanets.Enqueue(aPlanet);
            }
        }
    }
}
