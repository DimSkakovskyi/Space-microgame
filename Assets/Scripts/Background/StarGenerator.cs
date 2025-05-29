using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public GameObject Star;//Star prehab
    public int MaxStars;//the max number of stars

    //Array of colors
    Color[] starColors =
    {
        new Color(0.5f, 0.5f, 1f), //blue
        new Color(0, 1f, 1f), //green
        new Color(1f, 1f, 0), //yellow
        new Color(1f, 0, 0), //blue
    };

    // Start is called before the first frame update
    void Start()
    {
        //This is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //This is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //Loop to create the stars
        for (int i = 0; i < MaxStars; i++)
        {
            GameObject star = (GameObject)Instantiate(Star);

            //set the star color
            star.GetComponent<SpriteRenderer>().color = starColors[i % starColors.Length];

            //set the position of the star (random x and rando, y)
            star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            //set a random speed for the star
            star.GetComponent<Star>().speed = (1f * Random.value + 0.5f);

            //make the star a child of StarGenerator
            star.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
