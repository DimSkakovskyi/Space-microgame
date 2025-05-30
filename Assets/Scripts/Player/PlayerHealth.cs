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

    [SerializeField] private GameObject shield;
    public float shieldDuration;

    [SerializeField] private GameScore gameScore;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthUI.SetMaxHearts(maxHealth);

        spriteRenderer = GetComponent<SpriteRenderer>();
        HealthItem.OnHealthCollect += Heal;

        Shield.OnShieldActivate += ActivateShield;

        shield.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag != "PlayerWithShield")
        {
            Bolt bolt = collision.GetComponent<Bolt>();
            if (bolt)
            {
                TakeDamage(bolt.damage);
            }

            EnemyContr enemy = collision.GetComponent<EnemyContr>();
            if (enemy)
            {
                TakeDamage(enemy.damage);
            }
        }
        

        IItem item = collision.GetComponent<IItem>();
        if (item != null)
        {
            item.Collect();
        }
    }


    void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
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

        if (currentHealth == 0)
        {
            //player dead
            Die();
        }
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }

    public void ActivateShield()
    {
        StartCoroutine(ShieldRoutine());
    }

    private IEnumerator ShieldRoutine()
    {
        gameObject.tag = "PlayerWithShield";
        shield.SetActive(true);
        yield return new WaitForSeconds(shieldDuration - 1);
        for (double i = 0; i < 2; i+=0.4)
        {
            shield.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.2f);
            shield.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
        shield.SetActive(false);
        gameObject.tag = "PlayerShipTag";
    }

    void Die()
    {
        GameObject death = (GameObject)Instantiate(dead);

        death.transform.position = transform.position; // Set the position of the explosion to the player's position

        gameScore.isDead = true;

        GameManager.Instance.ShowGameOver();

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        HealthItem.OnHealthCollect -= Heal; // prevent memory leaks
    }
}
