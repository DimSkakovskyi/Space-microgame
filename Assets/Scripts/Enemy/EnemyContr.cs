using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContr : MonoBehaviour
{
    public GameObject ScoutDeath;

    public int damage = 1;

    float speed; // Speed of the enemy movement


    // Start is called before the first frame update
    void Start()
    {
        speed = 2f; // Set the speed of the enemy
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position; // Get the current position of the enemy

        position = new Vector2(position.x, position.y - speed * Time.deltaTime); // Move the enemy downwards

        transform.position = position; // Update the enemy's position

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // Get the bottom-left corner of the camera view

        if(position.y < min.y) // Check if the enemy has moved below the camera view
        {
            Destroy(gameObject); // Destroy the enemy if it goes out of bounds
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
        {
            PlayDeath();
            Destroy(gameObject);
        }
    }

    void PlayDeath()
    {
        GameObject death = (GameObject)Instantiate(ScoutDeath);

        death.transform.position = transform.position; // Set the position of the explosion effect to the enemy's position
    }
}
