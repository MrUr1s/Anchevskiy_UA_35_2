using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RatingField : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _postionText, _nameText, _timeText;
    public string Postion=> _postionText.text;
    public string PlayerName=> _nameText.text;

    public float Time { get; private set; }

    public void Set(string pos,string name,float time)
    {
        _postionText.text = pos;
        _nameText.text = name;
        Time=time;
        _timeText.text = TimeSpan.FromSeconds(time).ToString("mm':'ss':'f");
    }

}
