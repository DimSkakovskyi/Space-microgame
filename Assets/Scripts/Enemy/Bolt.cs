using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    float speed = 25f; // Speed of the bolt]
    Vector2 _direction;
    bool isReady;

    public int damage = 1;

    void Awake()
    {
        speed = 5f; // Set the speed of the bolt
        isReady = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized; // Normalize the direction vector
        isReady = true; // Mark the bolt as ready to move
    }

    // Update is called once per frame
    void Update()
    {
        if(isReady)
        {
            // Move the bolt in the specified direction
            Vector2 position = transform.position;

            position += _direction * speed * Time.deltaTime; // Move the bolt based on its speed and direction

            transform.position = position; // Update the bolt's position

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // Get the bottom-left corner of the camera view
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // Get the top-right corner of the camera view

            if((transform.position.x < min.x) || (transform.position.x > max.x) || 
               (transform.position.y < min.y) || (transform.position.y > max.y)) // Check if the bolt is out of bounds
            {
                Destroy(gameObject); // Destroy the bolt if it goes out of bounds
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerShipTag" || col.tag == "PlayerWithShield") // Check if the bullet collides with an enemy ship or bullet
        {
            Destroy(gameObject); // Destroy the bullet
        }
    }
}
