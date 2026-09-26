using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    public GameObject attack;

    public PlayerMovement movement;

    public CharacterMotor motor;

    public MouseRotate rotate;

    public float dashAmount;

    public float delay;

    public float duration;

    public float cooldown;

    bool canAttack = true;

    void Start()
    {
        attack.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            Camerashake.Instance.Shake(0.3f,0.2f,0.05f,10f,4f,transform.right, false);
            StartCoroutine(AttackCor());   
        }
    }

    IEnumerator AttackCor()
    {
        canAttack = false;
        movement.enabled = false;
        rotate.enabled = false;
        motor.Move(Vector3.zero, 0f);
        motor.SetForce(transform.right,dashAmount);

        yield return new WaitForSeconds(delay);

        attack.SetActive(true);

        yield return new WaitForSeconds(duration);

        attack.SetActive(false);
        rotate.enabled = true;
        movement.enabled = true;

        yield return new WaitForSeconds(cooldown);

        canAttack = true;
    }
}
