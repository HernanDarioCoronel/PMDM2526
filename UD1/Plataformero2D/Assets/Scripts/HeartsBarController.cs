using UnityEngine;
using UnityEngine.UIElements;

public class HeartsBarController : MonoBehaviour
{
    public int maxHearts = 5;
    public int currentHearts = 3;

    private VisualElement heartsContainer;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        heartsContainer = root.Q<VisualElement>("hearts-container");
        UpdateHearts();
    }

    public void UpdateHearts()
    {
        heartsContainer.Clear();

        for (int i = 0; i < maxHearts; i++)
        {
            VisualElement heart = new VisualElement();
            heart.AddToClassList("heart");

            if (i < currentHearts)
                heart.AddToClassList("full");
            else
                heart.AddToClassList("empty");

            heartsContainer.Add(heart);
        }
    }

    // Ejemplo: resta vida
    public void TakeDamage(int amount)
    {
        currentHearts = Mathf.Max(currentHearts - amount, 0);
        UpdateHearts();
    }

    // Ejemplo: cura vida
    public void Heal(int amount)
    {
        currentHearts = Mathf.Min(currentHearts + amount, maxHearts);
        UpdateHearts();
    }
}
