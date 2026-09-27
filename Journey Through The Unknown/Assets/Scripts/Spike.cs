using UnityEngine;
using System.Linq;

public class Spike : MonoBehaviour
{
    public string[] damageTags;

    public float damage;

    public float push;

    public Transform safe;

    void OnTriggerEnter2D(Collider2D other)
    {
        Health health;

        if (other.TryGetComponent<Health>(out health) && damageTags.Contains(other.gameObject.tag) && other.transform != safe)
        {
            health.TakeDamage(damage, 0.3f, 0.5f);
        }

        CharacterMotor motor;

        if (other.TryGetComponent<CharacterMotor>(out motor) && damageTags.Contains(other.gameObject.tag) && other.transform != safe)
        {
            Vector3 dir = (other.transform.position - (Vector3)GetComponent<Collider2D>().ClosestPoint(other.transform.position)).normalized;

            motor.SetForce(dir, push);
        }

        Attackable attack;

        if (other.TryGetComponent<Attackable>(out attack) && other.transform != safe)
        {
            attack.Act((other.transform.position - transform.position).normalized);
        }

        if (damageTags.Contains(other.gameObject.tag) && other.transform != safe)
            Camerashake.Instance.Shake(0.3f, 0.2f, 0.3f, 10f, 30f, transform.up, false);
    }
}
