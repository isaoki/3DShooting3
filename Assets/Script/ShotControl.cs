using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 射撃制御
/// </summary>
public class ShotControl : MonoBehaviour
{
    /// <summary>
    /// コピー元の弾丸Object
    /// </summary>
    [SerializeField] private GameObject _shotOriginal;

    /// <summary>
    /// 射撃間隔のためのタイマー
    /// </summary>
    private float _timer = 0;

    /// <summary>
    /// 常に呼ばれる
    /// </summary>

   
    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer <= 0.25f)
        {
            return;
        }
        _timer = 0;

        //レイの作成
        Ray ray = new Ray(Camera.main.transform.localPosition, Camera.main.transform.forward);
        RaycastHit hit;

        const float maxDistance = 600;

        //例にヒットしたオブジェクトがあった場合
        if(Physics.Raycast(ray,out hit,maxDistance))
        {
            GameObject hitObject = hit.collider.gameObject;
            if(hitObject == null)
            {
                return;
            }
            if(hitObject.tag != "Enemy")
            {
                return;
            }
            //射撃の発生場所
            Vector3 position = Camera.main.transform.localPosition;
            //射撃のクローン
            GameObject shotClone = (GameObject)Instantiate(_shotOriginal, position, Quaternion.identity);
            //AddForceで撃ち出す
            Rigidbody shotRigidbody = shotClone.gameObject.GetComponent<Rigidbody>();
            //カメラの向きの方向へパワーを加える
            shotRigidbody.AddForce(Camera.main.transform.forward * 10000);
            PlayerBase.GetInstance().PlayerAttack();
        }
    }
}
