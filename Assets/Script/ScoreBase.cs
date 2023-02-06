using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBase : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    public void SetScore(int score)
    {
        _scoreText.text = "SCORE:" + score;
    }
}
