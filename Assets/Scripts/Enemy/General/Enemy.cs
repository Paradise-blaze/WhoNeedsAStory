using UnityEngine;

public class Enemy: MonoBehaviour {
    public int maxHealth = 100;
    public int damage;
    public int CurrentHealth;

    public GameObject Player;

    public void Start()
    {
        EnemyManager.instance.enemyCount++;
    }

    private void Awake() {
        CurrentHealth = maxHealth;
        Player = GameObject.Find("Player");
    }

    public void TakeDamage(int damage) {
        CurrentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (CurrentHealth <= 0) {
            Die();
        }

    }

    public virtual void Die() {
        EnemyManager.instance.enemyCount--;
        Destroy(gameObject);
        Debug.Log(transform.name + " is Dead.");
    }
}
