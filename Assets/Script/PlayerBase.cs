using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// プレイヤー挙動管理
/// ステータス管理
/// </summary>
public class PlayerBase : MonoBehaviour
{
    public int LifePoint = 0;
    private int _scorePoint = 0;
    private static PlayerBase _instance;
    [SerializeField] private LifeBase _lifeBase;
    [SerializeField] private ScoreBase _scoreBase;
    [SerializeField] private Animator _playerAnimation;
    [SerializeField] private GameOverBase _gameOverBase;
    private float _damageTimer = 1.0f;
    private float _attackTimer = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        LifePoint = 5;
        _scorePoint = 0;
        _lifeBase.SetLife(LifePoint);
        _scoreBase.SetScore(_scorePoint);
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerAnimation.GetBool("Damage"))
        {
            _damageTimer -= Time.deltaTime;
            if (_damageTimer <= 0)
            {
                _playerAnimation.SetBool("Damage", false);
            }
        }
        if (_playerAnimation.GetBool("Attack"))
        {
            _attackTimer -= Time.deltaTime;
            if (_attackTimer <= 0)
            {
                _playerAnimation.SetBool("Attack", false);
            }
        }
    }

    public static PlayerBase GetInstance()
    {
        return _instance;
    }

    public void PlayerDamage()
    {
        if (LifePoint == 0)
        {
            return;
        }
        LifePoint--;
       _playerAnimation.SetBool("Damage", true);
       _damageTimer = 1.0f;
       _lifeBase.SetLife(LifePoint);
        Debug.Log(LifePoint);
        if (LifePoint == 0)
        {
            //死亡した
            _gameOverBase.GameOverStart();
        }
   }
    public void AddScore(int score)
    {
        _scorePoint += score;
        _scoreBase.SetScore(_scorePoint);
    }

    public void PlayerAttack()
    {
        _playerAnimation.SetBool("Attack", true);
        _attackTimer = 1.0f;
    }
}
