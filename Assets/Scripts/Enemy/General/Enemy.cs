using UnityEngine;

public class Enemy: MonoBehaviour {
    public int maxHealth = 100;
    public int damage;
    public int CurrentHealth;


    private void Awake() {
        CurrentHealth = maxHealth;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            TakeDamage(50);
        }
    }
    public void TakeDamage(int damage) {
        CurrentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (CurrentHealth <= 0) {
            Die();
        }

    }

    public virtual void Die() {
        Destroy(gameObject);
        Debug.Log(transform.name + " is Dead.");
    }
}
