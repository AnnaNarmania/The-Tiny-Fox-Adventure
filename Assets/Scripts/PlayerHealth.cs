
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour

{
    [SerializeField] private int maxHealth = 20;
    [SerializeField] private int currentHealth;
    [SerializeField] private Animator animator;

    [SerializeField] private float damageCooldown = 3f;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private GameObject gameOverUI;
    private bool canTakeDamage = true;
    private bool isHurt = false;
    private bool isDead = false;

    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        UpdateHealthUI();
        
    }

    void Update()
{
    if (transform.position.y <= -5f)
    {
        Die();
    }
}

    private void UpdateHealthUI()
    {
       if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        if (healthText != null)
        {
            healthText.text = currentHealth + " / " + maxHealth;
        }
    }

    public void TakeDamage(int damage)
{
    if (isDead || !canTakeDamage)  // <-- check isDead first
        return;

    currentHealth -= damage;
    currentHealth = Mathf.Max(currentHealth, 0); // prevent negative health
    UpdateHealthUI();

    isHurt = true;
    animator.SetBool("IsHurt", isHurt);
    StartCoroutine(HurtAnimation());

    
    Debug.Log("Player took " + damage + " damage. Current health: " + currentHealth);

    if (currentHealth == 0)
    {
        Die();
    }

    StartCoroutine(DamageCooldown());
    SoundManager.Instance.PlayHurtSound();
}

    private IEnumerator HurtAnimation()
    {
        yield return new WaitForSeconds(0.5f); // Duration of the hurt animation
        isHurt = false;
        animator.SetBool("IsHurt", isHurt);
    }

    private IEnumerator DamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canTakeDamage = true;
    }



    private void Die()
    {
        if (isDead)
        {
            return;
        }
        isDead = true;
        Debug.Log("Player has died.");
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        SoundManager.Instance.PlayGameOverSound();
        Debug.Log(gameOverUI);
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthUI();
        SoundManager.Instance.PlayHealSound();
        Debug.Log("Player healed " + amount + " health. Current health: " + currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Heal"))
        {
            Destroy(collision.gameObject);
            Heal(5); 
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead || !canTakeDamage)
        {
            return;
        }
        
        if (collision.gameObject.CompareTag("Spike"))
        {
            TakeDamage(2);
        }
        else if (collision.gameObject.CompareTag("Frog"))
        {
            TakeDamage(3);
        }
        else if (collision.gameObject.CompareTag("Dog"))
        {
            TakeDamage(4);
        }
        else if (collision.gameObject.CompareTag("Opossum"))
        {
            TakeDamage(5);
        }
        else if (collision.gameObject.CompareTag("Pig"))
        {
            TakeDamage(6);
        }

        else if (collision.gameObject.CompareTag("Bear"))
        {
            TakeDamage(10);
        }
    }

    
}
