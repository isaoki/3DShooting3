using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �e�ۂ̏���
/// </summary>
public class ShotMove : MonoBehaviour
{
    private float _shotLifeTimer = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���Ԃ����炷
        _shotLifeTimer -= Time.deltaTime;
        //�������Ԃ������Ȃ�
        if(_shotLifeTimer <= 0)
        {
            Destroy(gameObject);    
        }
    }
    /// <summary>
    /// �����ɂԂ�������Ăяo����鏈��
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
            
    }
}
