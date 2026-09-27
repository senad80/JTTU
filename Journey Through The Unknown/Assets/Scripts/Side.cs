using UnityEngine;

public class Side : MonoBehaviour
{
    public Door door;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(door.playerTag))
            door.right = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(door.playerTag))
            door.right = false;
    }
}
