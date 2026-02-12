using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class StartSplash : MonoBehaviour
{
    [SerializeField] GameObject _startScreen;
    [SerializeField] TMP_Text _preText, _countText, _postText;
    [SerializeField] KillCounter _killCounterScript;
    [SerializeField] string _preString, _postString;
    [SerializeField] UnityEvent _startEvent;

    void Awake()
    {
        if (_killCounterScript == null) 
            _killCounterScript = FindAnyObjectByType<KillCounter>();

        _startEvent?.Invoke();

        _preText.text = _preString;
        _countText.text = _killCounterScript.MaxScore.ToString();
        _postText.text = _postString;
    }
}
