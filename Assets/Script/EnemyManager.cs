using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// “G‚Ì¶¬‚ğŠÇ—‚·‚é
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

        //“G‚Ì•¡»‚ğì‚é
        EnemyBase enemyBase = (EnemyBase)Instantiate(_originalEnemy,
            new Vector3(UnityEngine.Random.Range(-80.0f,80.0f),
            UnityEngine.Random.Range(-60.0f, 80.0f),
            UnityEngine.Random.Range(20.0f, 180.0f)),
            Quaternion.identity
            );
        //‚±‚¿‚ç‚ğŒü‚©‚¹‚é
        enemyBase.gameObject.transform.LookAt(Camera.main.transform.localPosition);
    }
}
