using System.Collections;
using UnityEngine;
using TMPro;

public class SpeedrunTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private Coroutine _timeCountCoroutine = null;

    private int _seconds = 0;
    private int _minutes = 0;

    private void Start()
    {
        _timeCountCoroutine = StartCoroutine(TimeCount());
    }

    private void UpdateTimer()
    {
        _seconds += 1;
        if (_seconds >= 60)
        {
            _minutes += 1;
            _seconds = 0;
        }

        string secondsText = _seconds < 10 ? "0" + _seconds.ToString() : _seconds.ToString();
        string minutesText = _minutes < 10 ? "0" + _minutes.ToString() : _minutes.ToString();

        timerText.text = minutesText + ":" + secondsText;
    }

    private IEnumerator TimeCount()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            UpdateTimer();
        }
    }

    public void StopTimer()
    {
        StopCoroutine(_timeCountCoroutine);
    }
}
