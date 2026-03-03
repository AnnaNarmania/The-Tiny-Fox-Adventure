using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int health;
    [SerializeField] private Animator animator;
    private bool isDead = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject);
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {

        isDead = true;
        animator.SetBool("IsDead", isDead);
        SoundManager.Instance.PlayEnemyDeathSound();
        Destroy(gameObject, 0.5f); // Destroy the enemy after the death animation plays
    }
}
