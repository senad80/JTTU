using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    void Awake()
    {
        Instance = this;
    }

    public CharacterMotor motor;

    public float speed;

    public float acceleration;

    public float deceleration;

    float x;

    float y;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 0f)
            x = Mathf.Lerp(x, 0f, deceleration * Time.deltaTime);
        if (Input.GetAxisRaw("Vertical") == 0f)
            y = Mathf.Lerp(y, 0f, deceleration * Time.deltaTime);

        if (Input.GetAxisRaw("Horizontal") != 0f)
        x = Mathf.Lerp(x,Input.GetAxisRaw("Horizontal"), acceleration * Time.deltaTime);
        if (Input.GetAxisRaw("Vertical") != 0f)
        y = Mathf.Lerp(y,Input.GetAxisRaw("Vertical"), acceleration * Time.deltaTime);

        Vector3 dir = Vector3.up * y + Vector3.right * x;

        motor.Move(dir,speed);
    }
}
