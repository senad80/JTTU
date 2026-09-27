using UnityEngine;

public class Room : MonoBehaviour
{
    public Targeting[] enemies;

    public string attackTag;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Targeting enemy in enemies)
            {
                enemy.target = other.transform;
            }
        }
    }
}
