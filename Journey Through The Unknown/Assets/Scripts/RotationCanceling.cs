using UnityEngine;

public class RotationCanceling : MonoBehaviour
{
    public Quaternion rotation;

    public bool rotationNeeded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotationNeeded)
            transform.rotation = rotation;
        else
            transform.rotation = Quaternion.identity;
    }
}
