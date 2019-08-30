using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int StartLives = 3;
    int points = 0;

    public TextMeshPro scoreText;
    public LivesController livesController;

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

    public void JumperCrashed()
    {
        
        if (!livesController.RemoveLifes())
        {
            Debug.Log("Game over");
        }
    }

    private void Start()
    {
        UpdateScoreText();
        livesController.InitializedLives(StartLives);
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
}
