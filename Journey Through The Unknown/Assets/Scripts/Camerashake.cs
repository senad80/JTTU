using System.Collections;
using UnityEngine;

public class Camerashake : MonoBehaviour
{
    public static Camerashake Instance;

    void Awake()
    {
        Instance = this;
    }

    public Transform root;

    Vector3 destination;

    bool shaking;

    float speed;

    public void Shake(float intensity, float duration, float randomness, float shakeTimes, float speed, Vector3 startingDirection, bool freezeTime)
    {
        if (!shaking || freezeTime == true)
        StartCoroutine(ShakeCor(intensity,duration,randomness,shakeTimes,speed,startingDirection,freezeTime));
    }

    IEnumerator ShakeCor(float intensity, float duration, float randomness, float shakeTimes, float speed, Vector3 startingDirection,bool freezeTime)
    {
        this.speed = speed;

        shaking = true;

        if (freezeTime)
        {
            Time.timeScale = 0f;
        }

        for (int i = 0; i < shakeTimes; i++)
        {

            if (transform.position == root.position)
            {
                destination = root.position + startingDirection.normalized * intensity;

                destination.z = root.position.z;
            }
            else
            {
                Vector3 directionStart = (root.position - transform.position).normalized;

                Vector3 random = Random.insideUnitCircle.normalized;

                random.z = 0f;

                Vector3 direction = Vector3.Lerp(directionStart, random, randomness).normalized;

                direction.z = 0f;

                destination += direction * intensity;

                destination.z = root.position.z;
            }
            yield return new WaitForSecondsRealtime(duration / shakeTimes);
        }

        Time.timeScale = 1f;

        shaking = false;
    }

    void Update()
    {
        if (shaking)
        {
            transform.position = Vector3.Lerp(transform.position, destination, speed * Time.unscaledDeltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, root.position, speed * Time.unscaledDeltaTime);
        }
    }
}
