using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public int score = 10000;
    public int health = 3;

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
        score = 10000;
    }
}
