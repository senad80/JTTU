using UnityEngine;

public class Door : Attackable
{
    public Animator anim;

    public string playerTag;

    public float z;

    public bool right;

    public override void Act(Vector3 dir)
    {
        if (right)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, z);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(180f, 0f, z);
        }

        anim.SetBool("Open", true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            anim.SetBool("Open", false);
        }
    }
}
