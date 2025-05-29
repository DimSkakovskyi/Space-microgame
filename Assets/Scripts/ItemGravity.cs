using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGravity : MonoBehaviour
{
    public float speed;
    public float minY;
    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position; // Get the current position of the enemy

        position = new Vector2(position.x, position.y - speed * Time.deltaTime); // Move the enemy downwards

        transform.position = position; // Update the enemy's position

        if (position.y < minY) // Check if the item has moved below the camera view
        {
            Destroy(gameObject); // Destroy the item if it goes out of bounds
        }
    }
}
