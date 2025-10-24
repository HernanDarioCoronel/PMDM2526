using UnityEngine;
using UnityEngine.UIElements;

public class HeartsBarController : MonoBehaviour
{
    public PlayerStats playerStats;
    private VisualElement heartsContainer;

    void OnEnable()
    {
        playerStats.ResetScore();
        playerStats.ResetHealth();
        var root = GetComponent<UIDocument>().rootVisualElement;
        heartsContainer = root.Q<VisualElement>("hearts-container");
        UpdateHearts();
    }

    public void UpdateHearts()
    {
        heartsContainer.Clear();

        for (int i = 1; i <= playerStats.maxHealth; i++)
        {
            VisualElement heart = new VisualElement();
            heart.AddToClassList("heart");

            if (i <= playerStats.health)
                heart.AddToClassList("full");
            else
                heart.AddToClassList("empty");

            heartsContainer.Add(heart);
        }
    }

    // Ejemplo: resta vida
    public void TakeDamage(int amount)
    {
        playerStats.ApplyDamage(amount);
        UpdateHearts();
    }

    // Ejemplo: cura vida
    public void Heal(int amount)
    {
        playerStats.Heal(1);
        UpdateHearts();
    }
}
