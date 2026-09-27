using System.Linq;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    public float airResistance;

    public Vector2 size;

    public float removeCollider;

    public float addDistance;

    public LayerMask wallMask;

    Vector3 move;

    Vector3 force;

    // Update is called once per frame
    void Update()
    {
        force = Vector3.Lerp(force,Vector3.zero,airResistance * Time.deltaTime);

        Vector3 final = (move + force)*Time.deltaTime;

        if (final !=  Vector3.zero)
        {
            Vector3 horizontal = new Vector3(final.x, 0f, 0f);

            Collider2D[] hor = Physics2D.OverlapBoxAll(transform.position + horizontal + horizontal.normalized * addDistance
                , new Vector2(size.x, size.y - removeCollider), 0, wallMask);

            if ( hor.Length > 0)
            {
                foreach (Collider2D col in hor)
                {
                    if (col.gameObject != gameObject)
                    {
                        horizontal = Vector3.zero;
                        break;
                    }
                }
            }

            transform.position += horizontal;

            Vector3 vertical = new Vector3(0f,final.y,0f);

            Collider2D[] ver = Physics2D.OverlapBoxAll(transform.position + vertical + vertical.normalized * addDistance,
                new Vector2(size.x - removeCollider, size.y), 0, wallMask);

            if (ver.Length > 0)
            {
                foreach (Collider2D col in ver)
                {
                    if (col.gameObject != gameObject)
                    {
                        vertical = Vector3.zero;
                        break;
                    }
                }
            }

            transform.position += vertical;
        }
    }

    public void Move(Vector3 dir, float speed)
    {
        move = dir * speed;
    }

    public void Accelerate(Vector3 dir, float speed)
    {
        force += dir * speed;
    }

    public void SetForce(Vector3 dir, float amount)
    {
        force = dir * amount;
    }

    public void AddForce(Vector3 dir, float amount)
    {
        force += dir * amount;
    }
}
