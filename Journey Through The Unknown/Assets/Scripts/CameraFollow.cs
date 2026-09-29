using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float speed;

    public Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos.z = 0f;

        Bounds bounds = new Bounds(target.position, Vector3.zero);

        bounds.Encapsulate(mousePos);

        Vector3 dir = (bounds.center+offset - transform.position) * Time.deltaTime * speed;

        transform.position += dir;
    }
}
