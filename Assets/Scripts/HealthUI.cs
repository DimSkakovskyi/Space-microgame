using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image heartPrefab;
    public Sprite fulllHeartSprite;
    public Sprite emptyHeartSprite;

    private List<Image> hearts = new List<Image>();

    public void SetMaxHearts(int maxHearts)
    {
        foreach (Image heart in hearts)
        {
            Destroy(heart.gameObject);
        }

        hearts.Clear();

        for (int i = 0; i < maxHearts; i++)
        {
            Image newHeart = Instantiate(heartPrefab, transform);
            newHeart.sprite = fulllHeartSprite;
            newHeart.color = new Color(11f / 255f, 16f / 255f, 40f / 255f);
            hearts.Add(newHeart);
        }
    }

    public void UpdatedHearts(int currentHealth)
    {
        for(int i = 0; i < hearts.Count;i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fulllHeartSprite;
                hearts[i].color = new Color(11f / 255f, 16f / 255f, 40f / 255f);
            }
            else
            {
                hearts[i].sprite = emptyHeartSprite;
                hearts[i].color = Color.white;
            }
        }
        
    }
}
