using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// �W���C�X�e�B�b�N�̓������󂯎���ăv���C���[�J�����𓮂���
/// </summary>
public class PlayerCameraMove : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�̃I�u�W�F�N�g
    /// </summary>
    [SerializeField] private GameObject _player;

    /// <summary>
    /// �Q�Ƃ���C���v�b�g�p�����[�^
    /// </summary>
    [SerializeField] private InputAction _moveAction;

    /// <summary>
    /// �W���C�X�e�B�b�N�̈ړ��ʒu
    /// </summary>
    private Vector2 _joyStickPosition;
    private bool _isJoyStickMove = false;
    // Start is called before the first frame update
    void Start()
    {
        _moveAction.Enable();
        //�W���C�X�e�B�b�N�𓮂������Ƃ�
        _moveAction.performed += _ =>
        {
            Vector2 value = _moveAction.ReadValue<Vector2>();
            _joyStickPosition = value;
            _isJoyStickMove = true;
        };
        //�W���C�X�e�B�b�N���~�܂�����
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
            //�v���C���[�̊p�x���󂯎��
            Vector3 angle = _player.transform.localEulerAngles;
            angle.x -= _joyStickPosition.y * Time.deltaTime * 50;
            angle.y += _joyStickPosition.x * Time.deltaTime * 50;
            //�ҏW��̊p�x������
            _player.transform.localEulerAngles = angle;
        };
    }
}
