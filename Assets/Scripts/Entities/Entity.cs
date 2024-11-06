using System.Collections;
using System.Collections.Generic;
using UltEvents;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Entity : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private UltEvent<float> healthEvent;
    [SerializeField] private UltEvent deathEvent;
    public float RemainingHealthPercentage
    {
        get
        {
            return currentHealth / maxHealth;
        }
    }

    [Header("Attributes")]
    [SerializeField] protected float speed;
    protected bool isDeath;

    [Header("Dependences")]
    protected Rigidbody entityRb;
    protected virtual void Start()
    {
        entityRb = GetComponent<Rigidbody>();
    }
    protected virtual void Update()
    {
        Movement();
    }
    protected abstract void Movement();
    protected abstract void Defeat();

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDeath = true;
            deathEvent.Invoke();
            Defeat();
        }

        healthEvent.Invoke(RemainingHealthPercentage);
    }

    public void AddHealth(float amountToAdd)
    {
        if (currentHealth == maxHealth)
        {
            return;
        }

        currentHealth += amountToAdd;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthEvent.Invoke(RemainingHealthPercentage);
    }
    public void FullHealth()
    {
        currentHealth = maxHealth;
    }
}
