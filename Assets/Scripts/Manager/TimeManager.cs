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
    private float _gameOverTime = 90f;

    [SerializeField]
    [Header("����^�C���̒���(�~���b)")]
    private int _fireTimeLength;

    [SerializeField]
    [Header("�ŏ��̉���^�C��")]
    private float _firstFireTime = 30f;

    [SerializeField]
    [Header("2�Ԗڂ̉���^�C��")]
    private float _secondFireTime = 60f;

    [SerializeField]
    [Header("���U���g��ʂ̃V�[����")]
    private string _resultSceneName;

    [SerializeField]
    private int _damageThreshold = 5;

    [SerializeField]
    private float _time = 5f;

    [SerializeField]
    private AudioClip _fireBGM;

    [SerializeField]
    private AudioClip _playBGM;

    [SerializeField]
    private GameObject _beforPanel;

    [SerializeField]
    private float _firstBeforFireTime = 28f;

    [SerializeField]
    private float _secondBeforFireTime = 58f;

    private bool _wasBeforSecondFireTime;
    private bool _wasBeforFirstFireTime;
    private int _damageNum = 0;
    private float _timer;
    private bool _isTimerStop = true;
    private bool _isFireTime = false;
    private bool _wasFirstFireTime = false;
    private bool _wasSecondFireTime = false;

    protected override void Awake()
    {
        base.Awake();
        GameManager.OnGameStart += TimerStart;
        GameManager.OnGameStart += () => _beforPanel.SetActive(false);
        GameManager.OnGameOver += () => SceneChanger.GoToOtherScene(_resultSceneName);
    }

    private void Update()
    {
        if (_isTimerStop) return;
        if(_timer > _gameOverTime)
        {
            _isTimerStop = true;
            GameManager.GameOver();
            Debug.Log("Over");
        }
        BeforFireCheck();
        if (!_isFireTime)
        {
            FireTimeCheck();
        }
        _timer += Time.deltaTime;
    }

    public void OnDamage()
    {
        _damageNum++;
        if (_damageNum >= _damageThreshold)
        {
            DecreaseGameOverTime(_time);
            Debug.Log(TimeManager.Instance.GameOverTime);
            _damageNum = 0;
        }
    }

    /// <summary>
    /// �v���C���Ԃ����炷�֐�
    /// </summary>
    /// <param name="num"></param>
    private void DecreaseGameOverTime(float num)
    {
        _gameOverTime -= num;
    }

    private void TimerStart()
    {
        _timer = 0;
        _isTimerStop = false;
    }

    private void BeforFireCheck()
    {
        if (_wasBeforSecondFireTime) return;
        if(_timer > _secondBeforFireTime)
        {
            BeforFireTime();
            _wasBeforSecondFireTime = true;
        }
        if (_wasBeforFirstFireTime) return;
        if(_timer >_firstBeforFireTime)
        {
            BeforFireTime();
            _wasBeforFirstFireTime = true;
        }
    }

    private void BeforFireTime()
    {
        _beforPanel.SetActive(true);
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
        _beforPanel.SetActive(false);
        Debug.Log("Fire");
        SoundManager.Instance.PlayBGM(_fireBGM);
        _isFireTime = true;
        await Task.Delay(_fireTimeLength);
        SoundManager.Instance.PlayBGM(_playBGM);
        _isFireTime = false;
    }

}
