using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition UICondition;
    private Condition health { get { return UICondition.Health; } }
    private Condition hunger { get { return UICondition.Hunger; } }
    private Condition energy { get { return UICondition.Energy; } }

    public float noHungerHealthLossRate;
    void Update()
    {
        energy.Add(energy.passiveValue * Time.deltaTime);
        health.Add(health.passiveValue * Time.deltaTime);
        if (hunger.curValue <= 0)
        {
            health.Subtract(noHungerHealthLossRate * Time.deltaTime);
        }
        else
        {
            hunger.Subtract(hunger.passiveValue * Time.deltaTime);
        }
        if(health.curValue <= 0)
        {
            Die();
        }
    }
    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Eat(float amount)
    {
        hunger.Add(amount);
    }
    public void Die()
    {
        Debug.Log("Player has died.");
    }
}
