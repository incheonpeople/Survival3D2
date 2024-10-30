using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagalbe // (62)
{
    void TakePhysicalDamage(int damage);
}

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } } // (54)
    Condition hunger { get { return uiCondition.hunger; } } // (55)
    Condition stamina { get { return uiCondition.stamina; } }  // (56)

    public float noHungerHealthDecay; // (60)

    public event Action onTakeDamage; // (65)

    private void Update()
    {
        hunger.Subtract(hunger.passiveValue * Time.deltaTime); // (57)
        stamina.Add(stamina.passiveValue * Time.deltaTime); // (58)

        if (hunger.curValue == 0f) // (59) Hunger가 0이되면, HP가 닳아서
        {
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        }

        if (health.curValue == 0f) // (60)
        {
            Die();
        }
    }

    public void Die() // (61)
    {
        Debug.Log("Die");
    }

    public void TakePhysicalDamage(int damage) // (63)
    {
        health.Subtract(damage); // (64)
        onTakeDamage?.Invoke(); // (66) // DamageIndicator flash 함수와 연결됨.
    }

}
