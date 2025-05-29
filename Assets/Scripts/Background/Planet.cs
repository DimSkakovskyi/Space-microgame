using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float speed;//the speed of the planet
    public bool isMoving;//flag to make the planet scroll down the screen

    Vector2 min;//bottom-left
    Vector2 max;//top-right

    private void Awake()
    {
        isMoving = false;

        //This is the bottom-left point of the screen
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //This is the top-right point of the screen
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //add the planet sprite half height to max y
        max.y = max.y + GetComponent<SpriteRenderer>().sprite.bounds.extents.y;

        //substracts the planet sprite half the height to min y
        min.y = min.y - GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMoving)
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
        if(transform.position.y < min.y)
        {
            isMoving = false;
        }
    }

    public void ResetPosition()
    {
        //transform.position = new Vector2 (Random.Range ())
    }
}
