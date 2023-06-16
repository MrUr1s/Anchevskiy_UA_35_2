using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeLap : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;
    private float _timer = 0;
    public float Timer => _timer;
    private Coroutine _coroutine;
    public void StartTimer()=> _coroutine=StartCoroutine(StartTimerCor());
    public void StopTimer()=>StopCoroutine(_coroutine);

    public IEnumerator StartTimerCor()
    {
        _timer = 0;
        while (true) 
        {
            yield return new WaitForEndOfFrame();
            _timer += Time.deltaTime;
            _text.text= TimeSpan.FromSeconds(_timer).ToString("mm':'ss':'f");
        }
    }

}
