using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    float z = 0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos.z = 0f;

        Vector3 dir = (mousePos - transform.position).normalized;

        z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.localRotation = Quaternion.Euler(0f,0f,z);
    }
}
