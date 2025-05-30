using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject PBulletGo;

    public GameObject LeftGun;
    public GameObject MidGun;
    public GameObject RightGun;

    public GameObject dead;

    public float fireRate = 5f;
    private float fireTimer = 0f;
    private int shotNumber = 1; // Counter for the number of shots fired

    public float speed; // Speed of the player


    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) // Check if the space key is pressed
        {

            float deltaTime = Time.deltaTime;
            fireTimer += deltaTime; // Increment the fire timer
            if (fireTimer >= 1f / fireRate) // Check if enough time has passed to fire
            {
                Shot(shotNumber); // Call the Shot method to fire bullets
                SoundEffectManager.Play("Piu");
                fireTimer = 0f; // Reset the fire timer
                shotNumber+=1; // Increment the shot number
            }
        }
        else
        {
            fireTimer = 1f/fireRate; // Reset the fire timer if space is not pressed
        }


        float x = Input.GetAxisRaw("Horizontal"); // Get horizontal input and scale by speed
        Vector2 direction = new Vector2(x, 0); // Create a direction vector based on input

        Move(direction);
    }

    void Shot(int shotNumber)
    {
        if (shotNumber % 2 == 0)
        {
            GameObject bulletLeft = Instantiate(PBulletGo);
            bulletLeft.transform.position = LeftGun.transform.position;
        }
        else 
        {
            GameObject bulletRight = Instantiate(PBulletGo);
            bulletRight.transform.position = RightGun.transform.position;
        }

            
    }

    void Move(Vector3 direction)
    {
        Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)); // Get bottom left corner of the camera view
        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1)); // Get top right corner of the camera view
        
        max.x -= 2f; // Adjust min x to account for player width
        min.x += 2f; // Adjust max x to account for player width

        Vector3 pos = transform.position; // Get current position of the player

        pos.x += direction.x * speed * Time.deltaTime; // Update x position based on input and speed

        pos.x = Mathf.Clamp(pos.x, min.x, max.x); // Clamp x position within camera bounds

        transform.position = pos;
    }

    public void Init()
    {
        
    }

}