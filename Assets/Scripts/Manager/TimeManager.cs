using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class TimeManager : SingletonMonoBehaviour<TimeManager>
{
    // シークバーのValueを公開するプロパティ
    public float SeekBarValue => _timer / _gameOverTime;
    public float GameOverTime => _gameOverTime;
    public float Timer => _timer;
    public bool IsFireTime => _isFireTime;

    [SerializeField]
    [Header("プレイ時間の初期値")]
    private float _gameOverTime = 90;

    [SerializeField]
    [Header("炎上タイムの長さ(ミリ秒)")]
    private int _fireTimeLength;

    [SerializeField]
    [Header("最初の炎上タイム")]
    private float _firstFireTime = 30;

    [SerializeField]
    [Header("2番目の炎上タイム")]
    private float _secondFireTime = 60;

    [SerializeField]
    [Header("リザルト画面のシーン名")]
    private string _resultSceneName;

    private float _timer;
    private bool _isTimerStop = true;
    private bool _isFireTime = false;
    private bool _wasFirstFireTime = false;
    private bool _wasSecondFireTime = false;

    protected override void Awake()
    {
        base.Awake();
        GameManager.OnGameStart += TimerStart;
        GameManager.OnGameOver += () => SceneChanger.Instance.GoToOtherScene(_resultSceneName);
    }

    private void Update()
    {
        if (_isTimerStop) return;
        if(_timer > _gameOverTime)
        {
            _isTimerStop = true;
            GameManager.GameOver();
        }
        if(!_isFireTime)
        {
            FireTimeCheck();
        }
        _timer += Time.deltaTime;
    }

    private void TimerStart()
    {
        _timer = 0;
        _isTimerStop = false;
    }

    /// <summary>
    /// プレイ時間を減らす関数
    /// </summary>
    /// <param name="num"></param>
    public void DecreaseGameOverTime(float num)
    {
        _gameOverTime -= num;
    }

    private void FireTimeCheck()
    {
        if (_wasSecondFireTime) return;
        if(_timer > _secondFireTime)
        {
            FireTime();
            _wasSecondFireTime = true;
            return;
        }
        if (_wasFirstFireTime) return;
        if(_timer > _firstFireTime)
        {
            FireTime();
            _wasFirstFireTime = true;
            return;
        }
    }

    private async void FireTime()
    {
        _isFireTime = true;
        await Task.Delay(_fireTimeLength);
        _isFireTime = false;
    }
}
