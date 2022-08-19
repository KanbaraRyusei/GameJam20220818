using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComentPosition : MonoBehaviour
{
    public bool IsAntiComent => _anticoment;

    [SerializeField] float _destroyPosition;
    [SerializeField] Transform _lastPosition;
    [SerializeField] bool _anticoment;
    [SerializeField] int _score;
    [SerializeField] AudioClip _se;
    
    void FixedUpdate()
    {
        if(_lastPosition.transform.position.x < _destroyPosition)
        {           
            if(_anticoment)
            {
                ScoreManager.AddLowRating(_score);
                SoundManager.Instance.PlaySE(_se);
                TimeManager.Instance.OnDamage();
            }
            else
            {
                ScoreManager.AddHighlyRated(_score);
            }
            //Debug.Log("‚•]‰¿" + ScoreManager.HighlyRated + "’á•]‰¿" + ScoreManager.LowRating);
            Destroy(gameObject);
        }
    }
}
