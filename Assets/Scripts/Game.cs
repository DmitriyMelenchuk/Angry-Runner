using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    //[SerializeField] private Spawner _enemySpawner;

    //[SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private AudioSource _soundGame;
    [SerializeField] private AudioSource _gameOverSound;
    [SerializeField] private BirdCollisionHandler _collisionHandler;
    [SerializeField] private BirdMover _birdMover;

    private void Awake()
    {
        //_enemySpawner.Initialize();
        _collisionHandler.Init(_bird);
        _birdMover.Init();
        SetTimeScale(0);
        _startScreen.Open();
    }

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void SetTimeScale(int timeScale)
    {
        Time.timeScale = timeScale;
    }

    private void OnPlayButtonClick()
    {
        _soundGame.Play();
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _soundGame.Play();
        _gameOverSound.Stop();
        _gameOverScreen.Close();
        //_pipeGenerator.ResetPool();  делать ресет спавна енему
        StartGame();
    }

    private void StartGame()
    {
        SetTimeScale(1);
        _bird.ResetPlayer();
    }

    public void OnGameOver()
    {
        _soundGame.Stop();
        SetTimeScale(0);
        _gameOverScreen.Open();
        _gameOverSound.Play();
    }
}