using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHighScore : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private TMP_Text _highScores;

    private int _score = 0;

    private void OnEnable()
    {
        _bird.ScoreChange += OnHighScoreChange;
    }

    private void OnDisable()
    {
        _bird.ScoreChange -= OnHighScoreChange;
    }

    private void OnHighScoreChange(int playerScore)
    {
        if (_score < playerScore)
        {
            _score = playerScore;
            _highScores.text = _score.ToString();
        }
    }
}
