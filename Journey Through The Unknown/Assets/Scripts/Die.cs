using UnityEngine;

public class Die : MonoBehaviour
{
    public MonoBehaviour[] disabled;

    public Health health;

    // Update is called once per frame
    void Update()
    {
        if (health.IsDead())
        {
            foreach (MonoBehaviour mono in disabled)
            {
                mono.enabled = false;
            }
        }
    }
}
