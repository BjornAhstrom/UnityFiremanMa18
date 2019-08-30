using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int lives = 3;
    int points = 0;

    public TextMeshPro scoreText;

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
        lives--;
    }

    private void Start()
    {
        UpdateScoreText();
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
