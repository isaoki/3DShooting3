using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敵の生成を管理する
/// </summary>
public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyBase _originalEnemy;
    private float _createTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_createTimer < 5.0f)
        {
            _createTimer += Time.deltaTime;
            return;
        }
        _createTimer = 0;

        //敵の複製を作る
        EnemyBase enemyBase = (EnemyBase)Instantiate(_originalEnemy,
            new Vector3(UnityEngine.Random.Range(-80.0f,80.0f),
            UnityEngine.Random.Range(-60.0f, 80.0f),
            UnityEngine.Random.Range(20.0f, 180.0f)),
            Quaternion.identity
            );
        //こちらを向かせる
        enemyBase.gameObject.transform.LookAt(Camera.main.transform.localPosition);
    }
}
