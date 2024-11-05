using UltEvents;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Enemy : Entity
{
    [Header("Enemy Attributes")]
    [SerializeField] protected float damage;

    [Header("Dependences")]
    protected NavMeshAgent enemyNav;
    protected Player player;

    [Header("Events")]
    private UltEvent defeatEvent;
    public UltEvent DefeatEvent { get => defeatEvent; set => defeatEvent = value; }

    protected override void Start()
    {
        base.Start();
        enemyNav = GetNavMesh();
        player = GetPlayer();
    }
    protected virtual void Attack()
    {
        player.TakeDamage(damage);
    }
    protected override void Movement() 
    {
        enemyNav.speed = speed;
        if(player != null)
        {
            enemyNav.destination = player.transform.position;
        }
    }
    protected override void Defeat()
    {
        DefeatEvent.Invoke();
        FullHealth();
        gameObject.SetActive(false);
    }
    private NavMeshAgent GetNavMesh() => GetComponent<NavMeshAgent>();
    private Player GetPlayer() => FindObjectOfType<Player>();
    //private void OnDestroy()
    //{
    //    DefeatEvent.Clear();
    //}
}
