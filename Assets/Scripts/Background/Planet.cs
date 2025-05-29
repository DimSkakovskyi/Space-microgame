using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float speed;//the speed of the planet
    public bool isMoving;//flag to make the planet scroll down the screen
    public float minY;

    Vector2 min;//bottom-left
    Vector2 max;//top-right

    private Vector2 startPosition;

    private void Awake()
    {
        isMoving = false;

        startPosition = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            return;
        }

        //Get the current position
        Vector2 position = transform.position;

        //Compute the planet's new position
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        //Update the planet's position
        transform.position = position;

        //if the planet gets to the minimum y position. then stop moving the planet
        if (transform.position.y < minY)
        {
            isMoving = false;
        }
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
    }
}
