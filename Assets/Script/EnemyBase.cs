using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int LifePoint = 3;
    private float _timer = 0;
    [SerializeField] private GameObject _shotOriginal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer <=9.0)
        {
            return;
        }
        _timer = 0;
        //射撃のクローン
        GameObject shotClone = (GameObject)Instantiate(_shotOriginal, transform.localPosition, Quaternion.identity);
        shotClone.transform.LookAt(Camera.main.transform.localPosition);
        //AddForceで撃ち出す
        Rigidbody shotRigidbody = shotClone.gameObject.GetComponent<Rigidbody>();
        //カメラの向きの方向へパワーを加える
        shotRigidbody.AddForce(shotClone.transform.forward * 1000);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag != "Enemy")
        {
            LifePoint--;
            if(LifePoint ==0)
            {
                PlayerBase.GetInstance().AddScore(10);
                Destroy(gameObject);
            }
        }
    }
}
