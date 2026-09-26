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

        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10f,0.3f, 0.3f);
        }
    }

    public void TakeDamage(float damage, float intensity, float randomness)
    {
        health -= damage;

        health = Mathf.Clamp(health,0f,maxHealth);

        Camerashake.Instance.Shake(intensity, Random.Range(0.1f,0.2f), randomness, 10, 30f, Vector3.up);

        followDelay = followDelaySet;
        canFollow = false;
    }
}
