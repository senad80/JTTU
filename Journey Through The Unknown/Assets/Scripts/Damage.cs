using UnityEngine;

public class Damage : MonoBehaviour
{
    public string damageTag;

    public float damage;

    public float push;

    void OnTriggerEnter2D(Collider2D other)
    {
        Health health;

        if (other.TryGetComponent<Health>(out health) && other.gameObject.CompareTag(damageTag))
        {
            health.TakeDamage(damage, 0.3f, 0.5f);

            CharacterMotor motor;

            if (other.TryGetComponent<CharacterMotor>(out motor))
            {
                Vector3 dir = (other.transform.position-transform.position).normalized;

                motor.SetForce(dir,push);
            }
        }
    }
}
