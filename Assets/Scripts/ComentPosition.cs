using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComentPosition : MonoBehaviour
{
    [SerializeField] float _destroyPosition;
    [SerializeField] Transform _lastPosition;
    [SerializeField] bool _anticoment;
    [SerializeField] int _score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_lastPosition.transform.position.x < _destroyPosition)
        {           
            if(_anticoment)
            {
                ScoreManager.AddLowRating(_score);
            }
            else
            {
                ScoreManager.AddHighlyRated(_score);
            }
            Destroy(gameObject);
        }
    }
}
