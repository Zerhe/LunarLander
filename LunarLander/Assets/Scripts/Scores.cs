using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour {
    [SerializeField]
    private PlayerState playerState;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _maxScoreText;
    private int _score;
    private int _maxScore;

	void Start () {
        playerState.win = SumarScore;
        _score = PlayerPrefs.GetInt("Score", 0);
        _scoreText.text = "Score: " + _score;
        _maxScore = PlayerPrefs.GetInt("MaxScore", 0);
        _maxScoreText.text = "MaxScore: " + _maxScore;
    }
	
	void Update () {
       
	}
    void SumarScore(int score)
    {
        _score += score;
        PlayerPrefs.SetInt("Score", _score);
        if (_score > _maxScore)
        {
            _maxScore = _score;
            PlayerPrefs.SetInt("MaxScore", _maxScore);
        }
        PlayerPrefs.Save();
    }
}
