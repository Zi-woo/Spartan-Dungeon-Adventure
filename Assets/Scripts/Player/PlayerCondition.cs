using System;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    [SerializeField] private PlayerController playerController;
    
    Condition health { get { return uiCondition.health; } }
    
    Condition stamina { get { return uiCondition.stamina; } }
    
    public event Action onTakeDamage;

    private void Update()
    {
        if (playerController != null && playerController.IsRunning && stamina.curValue > 0)
        {
            stamina.Subtract(10f * Time.deltaTime);
        }
        else
        {
            stamina.Add(stamina.passiveValue * Time.deltaTime);    
        }

        if(health.curValue < 0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }
    

    public void Die()
    {
        Debug.Log("플레이어가 죽었다.");
    }
}