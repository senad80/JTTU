using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Health health;

    public Animator gameOver;

    // Update is called once per frame
    void Update()
    {
        if (health.IsDead())
        {
            Time.timeScale = 0f;

            gameOver.SetTrigger("GameOver");
        }
    }
}
