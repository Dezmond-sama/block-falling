using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float slowness = 10f;

    public int currentWave = 0;
    public Text scoreText;

    private void Start()
    {
        UpdateScore();
    }
    public void GameEnd()
    {
        StartCoroutine(RestartLevel());
    }
    IEnumerator RestartLevel()
    {
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime /= slowness;

        yield return new WaitForSeconds(1f / slowness);

        Time.timeScale = 1f;
        Time.fixedDeltaTime *= slowness;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void UpdateScore()
    {
        scoreText.text = currentWave.ToString();
    }
}
