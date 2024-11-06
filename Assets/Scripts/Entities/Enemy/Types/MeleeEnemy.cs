using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            Attack();
            player.Push(transform);
        }
    }
    protected override void Defeat()
    {
        base.Defeat();
        enemyAnim.Play("Enemy-01-Death");
    }
    public void Desactive()
    {
        enemyAnim.SetTrigger("Respawn");
        gameObject.SetActive(false);
        respawnEvent.Invoke();
        FullHealth();
    }
}
