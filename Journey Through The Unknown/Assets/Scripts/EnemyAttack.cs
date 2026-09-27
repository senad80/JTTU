using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject attack;

    public CharacterMotor motor;

    public EnemyAI ai;

    public float dashAmount;

    public float delay;

    public float duration;

    public float cooldown;

    public float attackRange;

    bool canAttack = true;

    void Start()
    {
        attack.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(PlayerMovement.Instance.transform.position, transform.position) <= attackRange && canAttack)
        {
            //Camerashake.Instance.Shake(0.3f,0.2f,0.05f,10f,4f,transform.right, false);
            StartCoroutine(AttackCor());
        }
    }

    void OnDisabled()
    {
        attack.SetActive(false);
    }

    IEnumerator AttackCor()
    {
        canAttack = false;
        motor.Move(Vector3.zero, 0f);
        ai.canMove = false;
        motor.SetForce(transform.right, dashAmount);

        yield return new WaitForSeconds(delay);

        attack.SetActive(true);

        yield return new WaitForSeconds(duration);

        attack.SetActive(false);
        ai.canMove = true;

        yield return new WaitForSeconds(cooldown);

        canAttack = true;
    }
}
