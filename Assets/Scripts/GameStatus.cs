using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {
    // configurable params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;

    // state of the game
    [SerializeField] int currentScore = 0;

    private void Awake() {
        int gameObjectsCount = FindObjectsOfType<GameStatus>().Length;
        if (gameObjectsCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() {
        scoreText.text = currentScore.ToString();
    }

    void Update () {
        Time.timeScale = gameSpeed;
	}

    public void AddToScore() {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

}
