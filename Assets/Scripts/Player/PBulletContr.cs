using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PBulletContr : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed= 15f; // Set the speed of the bullet
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position; // Get the current position of the bullet

        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        transform.position = position; // Update the position of the bullet

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // Get the top-right corner of the camera view

        if (transform.position.y > max.y) // Check if the bullet has moved out of the camera view
        {
            Destroy(gameObject); // Destroy the bullet if it is out of view
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyShipTag") // Check if the bullet collides with an enemy ship or bullet
        {
            Destroy(gameObject); // Destroy the bullet
        }
    }
}
