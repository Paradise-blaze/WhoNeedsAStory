using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius = 2f;

    Transform player;

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if(distance <= radius)
        {
            Debug.Log("Interact");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
