
using UnityEngine;

public class FallingRock : MonoBehaviour
{
    [Header("Rock Settings")]
    [SerializeField] private float destroyAfterImpact = 2f;
    [SerializeField] private int damage = 1;

    private bool hasImpacted = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (hasImpacted)
            return;

        hasImpacted = true;

        // Check whether the rock collided with the rabbit
        RabbitHealth rabbitHealth =
            collision.gameObject.GetComponentInParent<RabbitHealth>();

        if (rabbitHealth != null)
        {
            rabbitHealth.TakeDamage(damage);
            Debug.Log("Rock hit the rabbit!");
        }
        else
        {
            Debug.Log("Rock hit: " + collision.gameObject.name);
        }

        // Destroy the rock after impact
        Destroy(gameObject, destroyAfterImpact);
    }
}
