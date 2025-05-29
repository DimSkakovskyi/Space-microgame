using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{

    public GameObject Bolt; // Prefab for the bullet

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireEnemyBullet", 1f, 2f); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.Find("PlayerGo");

        if (playerShip != null)
        {
            GameObject bullet = (GameObject)Instantiate(Bolt);

            bullet.transform.position = transform.position; // Set the position of the bullet to the gun's position

            Vector2 direction = Vector2.down; //shot down by default
            Debug.Log("all good");
            bullet.GetComponent<Bolt>().SetDirection(direction);
        }
    }
}
