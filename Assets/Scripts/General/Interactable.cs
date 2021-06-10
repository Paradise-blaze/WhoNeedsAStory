using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius = 3f;
    [SerializeField]
    public Transform interactiontransform;

    bool hasInteracted = false;

    Transform player;

    public virtual void Interact() {
        Debug.Log("Interacting with: " + transform.name);
    }

	private void Start() {
	}

	void Update()
    {
		if (!hasInteracted) {
            float distance = Vector3.Distance(Player.playerObject.transform.position, interactiontransform.position);
            if (distance <= radius && Input.GetButton("E")) {
                Interact();
                hasInteracted = true;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if(interactiontransform == null) {
            interactiontransform = transform;
		}
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactiontransform.position, radius);
    }
}
