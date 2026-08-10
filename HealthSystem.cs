using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(transform.name + " تلقى ضرر مقدار: " + damage + " | الصحة المتبقية: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(transform.name + " مات!");
        // تدمير الكائن عند الموت أو تشغيل أنيميشن الموت
        Destroy(gameObject);
    }
}
