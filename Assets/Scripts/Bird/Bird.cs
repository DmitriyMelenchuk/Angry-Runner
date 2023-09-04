using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _birdMover;
    private int _score;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChange;

    public void ResetPlayer()
    {
        _birdMover = GetComponent<BirdMover>();
        ScoreChange?.Invoke(_score);
        _score = 0;
        _birdMover.Reset();
    }

    public void Die()
    {
        GameOver?.Invoke();
    }

    public void AddScore()
    {
        _score++;
        ScoreChange?.Invoke(_score);
    }
}
