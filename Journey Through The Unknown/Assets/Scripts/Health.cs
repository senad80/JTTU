using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth;

    public Slider slider;

    public float visualSpeed;

    float health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.maxValue = maxHealth;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Mathf.Lerp(slider.value,health,visualSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10f);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        health = Mathf.Clamp(health,0f,maxHealth);
    }
}
