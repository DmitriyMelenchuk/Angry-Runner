using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _bird.ScoreChange += OnScoreChange;
    }

    private void OnDisable()
    {
        _bird.ScoreChange -= OnScoreChange;
    }

    private void OnScoreChange(int score)
    {
        _score.text = score.ToString();
    }
}
