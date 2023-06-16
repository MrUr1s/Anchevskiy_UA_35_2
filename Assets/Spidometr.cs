using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spidometr : MonoBehaviour
{
    private const float c_convertMeterInSecFromKmInH = 3.6f;
    [SerializeField]
    private float _delay;
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private TMPro.TMP_Text _text;
    private void Start()
    {
        StartCoroutine(Speed());
    }

    private IEnumerator Speed()
    {
        var prevPos=_player.position;
        while (true) {
            var distance = Vector3.Distance(prevPos, _player.position);
            var speed=System.Math.Round(distance/_delay* c_convertMeterInSecFromKmInH,1);
            _text.text= speed.ToString();
            prevPos=_player.position;  
        yield return new WaitForSeconds(_delay);
        }
    }
}
