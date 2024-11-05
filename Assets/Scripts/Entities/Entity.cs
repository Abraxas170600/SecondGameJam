using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Entity : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;

    [Header("Attributes")]
    [SerializeField] protected float speed;

    [Header("Dependences")]
    protected Rigidbody entityRb;
    public float RemainingHealthPercentage
    {
        get
        {
            return currentHealth / maxHealth;
        }
    }
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
            Defeat();
        }
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
    }
    public void FullHealth()
    {
        currentHealth = maxHealth;
    }
}
