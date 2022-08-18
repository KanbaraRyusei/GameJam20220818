using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{
    [SerializeField] Transform[] _generateposition;
    [SerializeField] GameObject[] _text;
    [SerializeField] float _interval;
    [SerializeField] float _highInterval;
    float _timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _interval)
        {
            int number = Random.Range(0, _generateposition.Length);
            int num = Random.Range(0, _text.Length);
            Instantiate(_text[num], _generateposition[number]);
            _timer = 0;
        }
    }
}
