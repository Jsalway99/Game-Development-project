using UnityEngine;
public class EnemyDamage : MonoBehaviour
{
    public int damage = 20;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth health = other.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}