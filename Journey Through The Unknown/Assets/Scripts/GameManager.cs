using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Animator animator;

    public float delay;

    public void StartRestarting()
    {
        animator.SetTrigger("Restart");

        StartCoroutine(RestartCor());
    }

    IEnumerator RestartCor()
    {
        yield return new WaitForSecondsRealtime(delay);

        Restart();
    }
    
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
