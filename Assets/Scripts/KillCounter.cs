using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class KillCounter : MonoBehaviour
{
    public int MaxScore 
    { get => _maxScore; }

    [SerializeField] TMP_Text _scoreText;
    [SerializeField] int _maxScore = 10;
    [SerializeField] UnityEvent _winEvent;

    public void UpdateScore(int score)
    {
        int currentscore = int.Parse(_scoreText.text);
        int newscore = currentscore + score;
        _scoreText.text = $"{newscore}";
        if (newscore >= _maxScore) _winEvent?.Invoke();
    }
}
