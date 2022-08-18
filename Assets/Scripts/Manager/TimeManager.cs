using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class TimeManager : SingletonMonoBehaviour<TimeManager>
{
    // �V�[�N�o�[��Value�����J����v���p�e�B
    public float SeekBarValue => _timer / _gameOverTime;
    public float GameOverTime => _gameOverTime;
    public float Timer => _timer;
    public bool IsFireTime => _isFireTime;

    [SerializeField]
    [Header("�v���C���Ԃ̏����l")]
    private float _gameOverTime = 90;

    [SerializeField]
    [Header("����^�C���̒���(�~���b)")]
    private int _fireTimeLength;

    [SerializeField]
    [Header("�ŏ��̉���^�C��")]
    private float _firstFireTime = 30;

    [SerializeField]
    [Header("2�Ԗڂ̉���^�C��")]
    private float _secondFireTime = 60;

    private float _timer;
    private bool _isTimerStop = true;
    private bool _isFireTime = false;
    private bool _wasFirstFireTime = false;
    private bool _wasSecondFireTime = false;

    protected override void Awake()
    {
        base.Awake();
        _timer = 0;
        ScoreManager.Init();
        GameManager.GameStart();
        TimerStart();
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
        _isTimerStop = false;
    }

    /// <summary>
    /// �v���C���Ԃ����炷�֐�
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
