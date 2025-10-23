using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public int score;
    private int startingScore = 10000;
    public int health = 3;
    public int maxHealth = 3;

    public int Score
    {
        get { return score; }
    }

    public void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
    }

    public void SubtractPoints(int pointsToSubtract)
    {
        score -= pointsToSubtract;
        if (score < 0)
        {
            score = 0;
        }
    }

    public void ResetScore()
    {
        score = startingScore;
    }

    public int Health
    {
        get { return health; }
    }

    public int MaxHealth
    {
        get { return maxHealth; }
    }

    public void ApplyDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void ResetHealth()
    {
        health = maxHealth;
    }
}
