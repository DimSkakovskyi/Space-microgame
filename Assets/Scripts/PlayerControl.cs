using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed; // Speed of the player

    void Start()
    {
        
    }

    
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal"); // Get horizontal input and scale by speed
        Vector2 direction = new Vector2(x, 0); // Create a direction vector based on input

        Move(direction);
    }

    void Move(Vector3 direction)
    {
        Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)); // Get bottom left corner of the camera view
        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1)); // Get top right corner of the camera view
        
        max.x -= 0.5f; // Adjust min x to account for player width
        min.x += 0.5f; // Adjust max x to account for player width

        Vector3 pos = transform.position; // Get current position of the player

        pos.x += direction.x * speed * Time.deltaTime; // Update x position based on input and speed

        pos.x = Mathf.Clamp(pos.x, min.x, max.x); // Clamp x position within camera bounds

        transform.position = pos;
    }
}