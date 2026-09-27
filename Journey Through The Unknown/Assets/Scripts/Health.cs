using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth;

    public Slider slider;

    public Slider followSlider;

    public float followDelaySet;

    public float visualSpeed;

    float followDelay;

    float health;

    bool canFollow;

    bool isDead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.maxValue = maxHealth;
        followSlider.maxValue = maxHealth;
        health = maxHealth;
        slider.value = health;
        followSlider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Mathf.Lerp(slider.value,health,visualSpeed * Time.deltaTime);
        
        if (canFollow)
        {
            followSlider.value = Mathf.Lerp(followSlider.value, slider.value, visualSpeed * Time.deltaTime);
        }
        else
        {
            followDelay -= Time.deltaTime;

            if (followDelay <= 0f)
            {
                canFollow = true;
            }
        }
    }

    public void TakeDamage(float damage, float intensity, float randomness)
    {
        health -= damage;

        health = Mathf.Clamp(health,0f,maxHealth);

        if (health <= 0)
        {
            isDead = true;
        }
        

        followDelay = followDelaySet;
        canFollow = false;
    }

    public bool IsDead()
    {
        return isDead;
    }
}
