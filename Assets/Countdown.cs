using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;
    private int _time = 5;

    public void Start()
    {
        StartCoroutine(StartTimer());
    }
    IEnumerator StartTimer()
    {
        while (_time > 0)
        {
            _text.fontSize=36;
            _time--;
            if (_time != 0)
                _text.text = _time.ToString();
            else
                _text.text = "GO";
            yield return new WaitForSeconds(0.5f);
            if (_time <= 3)
                _text.fontSize = 72;
            yield return new WaitForSeconds(0.5f);
        }
        GameManager.Instance.RaceStart();
        gameObject.SetActive(false);
    }

}
