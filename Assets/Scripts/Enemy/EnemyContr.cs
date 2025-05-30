using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContr : MonoBehaviour
{
    GameObject scoreUITextGo;

    public GameObject ScoutDeath;

    public int damage = 1;

    public int minY; // Minimum Y position for the enemy to be destroyed

    float speed; // Speed of the enemy movement

    //Loot Table
    [Header("Loot")]
    public List<LootItem> lootTable = new List<LootItem>();


    // Start is called before the first frame update
    void Start()
    {
        speed = 2f; // Set the speed of the enemy

        scoreUITextGo = GameObject.FindGameObjectWithTag("ScoreTextTag");
        if (scoreUITextGo == null)
        {
            Debug.LogError("Score Text GameObject not found! Make sure it has the tag 'ScoreTextTag'.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position; // Get the current position of the enemy

        position = new Vector2(position.x, position.y - speed * Time.deltaTime); // Move the enemy downwards

        transform.position = position; // Update the enemy's position
        

        if(position.y < minY) // Check if the enemy has moved below the camera view
        {
            if (scoreUITextGo.GetComponent<GameScore>().Score > 0)
            {
                scoreUITextGo.GetComponent<GameScore>().Score -= 100;
            }
                
            Destroy(gameObject); // Destroy the enemy if it goes out of bounds
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
        {
            PlayDeath();

            scoreUITextGo.GetComponent<GameScore>().Score += 100; // Increase the score by 100 points

            //Go around loot table and spawn item
            foreach (LootItem lootItem in lootTable)
            {
                if (Random.Range(0f, 100f) <= lootItem.dropChance)
                {
                    InstantiateLoot(lootItem.itemPrefab);
                    break;
                }
            }

            Destroy(gameObject);
        }
    }

    void InstantiateLoot(GameObject loot)
    {
        if(loot)
        {
            GameObject droppedLoot = Instantiate(loot, transform.position, Quaternion.identity);
        }
    }

    void PlayDeath()
    {
        GameObject death = (GameObject)Instantiate(ScoutDeath);

        death.transform.position = transform.position; // Set the position of the explosion effect to the enemy's position
    }
}
