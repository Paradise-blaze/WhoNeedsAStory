using UnityEngine;

public class Enemy: MonoBehaviour {
    public static int enemyCount = 0;
    public int maxHealth = 100;
    public int damage;
    public int CurrentHealth;

    public GameObject Player;


    private void Awake() {
        enemyCount++;
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
        enemyCount--;
        Destroy(gameObject);
        Debug.Log(transform.name + " is Dead.");
    }
}
