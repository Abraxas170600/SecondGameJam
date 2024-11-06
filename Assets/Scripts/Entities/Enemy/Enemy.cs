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
    protected Animator enemyAnim;
    protected Player player;

    [Header("Events")]
    [SerializeField] protected UltEvent respawnEvent;
    private UltEvent defeatEvent;
    public UltEvent DefeatEvent { get => defeatEvent; set => defeatEvent = value; }

    protected override void Start()
    {
        base.Start();
        enemyNav = GetNavMesh();
        enemyAnim = GetAnimator();
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
        enemyNav.isStopped = true;
    }
    private NavMeshAgent GetNavMesh() => GetComponent<NavMeshAgent>();
    private Animator GetAnimator() => GetComponent<Animator>();
    private Player GetPlayer() => FindObjectOfType<Player>();
}
