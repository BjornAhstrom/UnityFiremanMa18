using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    string sceneName = "Main";
    public int StartLives = 3;
    private int points = 0;

    public TextMeshPro scoreText;
    public LivesController livesController;
    JumperSpawner jumperSpawner;
    public GameObject gameOverSign;
    public GameObject input;

    private void OnEnable()
    {
        JumperController.OnJumperCrash += JumperCrashed;
        JumperController.OnJumperSave += JumperSaved;
    }

    private void OnDisable()
    {
        JumperController.OnJumperCrash -= JumperCrashed;
        JumperController.OnJumperSave -= JumperSaved;
    }

    private void Start()
    {
        UpdateScoreText();
        livesController.InitializedLives(StartLives);
        jumperSpawner = GetComponent<JumperSpawner>();
        gameOverSign.SetActive(false);
    }

    public int Points()
    {
        return points;
    }

    public void JumperCrashed()
    {
        
        if (!livesController.RemoveLifes())
        {
            Debug.Log("Game over");
            GameOver();

        }
    }

    public void JumperSaved()
    {
        points++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = points.ToString();
    }

    private void GameOver()
    {
        gameOverSign.SetActive(true);
        jumperSpawner.Stop();
        input.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}
