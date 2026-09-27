using UnityEngine;

public class Hit : Attackable
{
    public float offset;

    public RotationCanceling canceling;

    public override void Act(Vector3 dir)
    {
        float z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        canceling.rotation = Quaternion.Euler(0f, 0, z+offset);
    }
}
