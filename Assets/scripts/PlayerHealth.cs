using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] heartSprites;
    [SerializeField] private GameObject deathPanel;

    private int currentHealth = 3;

    private void Start()
    {
        deathPanel.SetActive(false);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        UpdateHearts();
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < heartSprites.Length; i++)
            heartSprites[i].enabled = (i <  currentHealth);
    }

    public void Die()
    {
        deathPanel?.SetActive(true);
        enabled = false;
        Time.timeScale = 0f;
    }
}
