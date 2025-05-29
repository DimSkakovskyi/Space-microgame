using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public HealthUI healthUI;

    SpriteRenderer spriteRenderer;

    public GameObject dead;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthUI.SetMaxHearts(maxHealth);

        spriteRenderer = GetComponent<SpriteRenderer>();
        HealthItem.OnHealthCollect += Heal;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bolt bolt = collision.GetComponent<Bolt>();
        if(bolt)
        {
            TakeDamage(bolt.damage);
        }
    }

    void Heal(int amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthUI.UpdatedHearts(currentHealth);
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthUI.UpdatedHearts(currentHealth);

        //Flash
        StartCoroutine(FlashRed());

        if(currentHealth == 0)
        {
            //player dead
            OnDestroy();            
        }
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }

    void OnDestroy()
    {
        GameObject death = (GameObject)Instantiate(dead);

        death.transform.position = transform.position; // Set the position of the explosion to the player's position

        Destroy(gameObject);
    }

}
