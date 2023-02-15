using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public float multiplier;

    public void AddToScore(int amount)
    {
        score += (int)(amount * multiplier);
    }

    public  void ReduceScore(int amount)
    {
        score -= amount;
    }
}
