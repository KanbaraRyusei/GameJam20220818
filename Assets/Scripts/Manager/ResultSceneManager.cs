using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSceneManager : MonoBehaviour
{
    [SerializeField] Text _highlyRatedText;
    [SerializeField] Text _lowRatingText;

    int _highlyRatedScore;
    int _lowRatingScore;

    // Start is called before the first frame update
    void Start()
    {
        _highlyRatedScore = ScoreManager.HighlyRated;
        _lowRatingScore = ScoreManager.LowRating;

        _highlyRatedText = GameObject.Find("KouhyoukaText").GetComponent<Text>();
        _lowRatingText = GameObject.Find("TeihyoukaText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _highlyRatedText.text = "çÇï]âø   " + _highlyRatedScore.ToString();
        _lowRatingText.text = "í·ï]âø   " + _lowRatingScore.ToString();
    }
}
