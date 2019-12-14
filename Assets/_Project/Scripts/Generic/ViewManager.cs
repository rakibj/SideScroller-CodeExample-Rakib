using System;
using System.Collections;
using RakibUtils;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Generic
{
    public class ViewManager : MonoBehaviour
    {
        [SerializeField] private IntVariable scoreFloatVariable;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private CanvasGroup scoreCanvasGroup;
        [SerializeField] private TextMeshProUGUI scoreScreenScoreText;
        [SerializeField] private TextMeshProUGUI scoreScreenHighScoreText;

        private void Start()
        {
            scoreCanvasGroup.interactable = false;
            scoreCanvasGroup.alpha = 0;
        }

        private void OnEnable()
        {
            GameEvents.gameOver += ShowScoreScreen;
        }

        private void OnDisable()
        {
            GameEvents.gameOver -= ShowScoreScreen;
        }

        private void Update()
        {
            scoreText.text = "Score: " + scoreFloatVariable.value;
        }

        private void ShowScoreScreen(int score)
        {
            scoreScreenScoreText.text = "Current Score: " + score;
            scoreScreenHighScoreText.text = "High Score: " + ScoreManager.GetHighScore(score);
            scoreCanvasGroup.interactable = true;
            StartCoroutine(ShowScoreRoutine());

        }

        private IEnumerator ShowScoreRoutine()
        {
            while (scoreCanvasGroup.alpha < .99f)
            {
                scoreCanvasGroup.alpha += Time.deltaTime;
                yield return null;
            }

        }
        
    }
}
