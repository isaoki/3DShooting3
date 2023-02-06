using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// ジョイスティックの動きを受け取ってプレイヤーカメラを動かす
/// </summary>
public class PlayerCameraMove : MonoBehaviour
{
    /// <summary>
    /// プレイヤーのオブジェクト
    /// </summary>
    [SerializeField] private GameObject _player;

    /// <summary>
    /// 参照するインプットパラメータ
    /// </summary>
    [SerializeField] private InputAction _moveAction;

    /// <summary>
    /// ジョイスティックの移動位置
    /// </summary>
    private Vector2 _joyStickPosition;
    private bool _isJoyStickMove = false;
    // Start is called before the first frame update
    void Start()
    {
        _moveAction.Enable();
        //ジョイスティックを動かしたとき
        _moveAction.performed += _ =>
        {
            Vector2 value = _moveAction.ReadValue<Vector2>();
            _joyStickPosition = value;
            _isJoyStickMove = true;
        };
        //ジョイスティックが止まった時
        _moveAction.canceled += _ =>
        {
            _isJoyStickMove = false;
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (_isJoyStickMove)
        {
            //プレイヤーの角度を受け取る
            Vector3 angle = _player.transform.localEulerAngles;
            angle.x -= _joyStickPosition.y * Time.deltaTime * 50;
            angle.y += _joyStickPosition.x * Time.deltaTime * 50;
            //編集後の角度を入れる
            _player.transform.localEulerAngles = angle;
        };
    }
}
