using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �ˌ�����
/// </summary>
public class ShotControl : MonoBehaviour
{
    /// <summary>
    /// �R�s�[���̒e��Object
    /// </summary>
    [SerializeField] private GameObject _shotOriginal;

    /// <summary>
    /// �ˌ��Ԋu�̂��߂̃^�C�}�[
    /// </summary>
    private float _timer = 0;

    /// <summary>
    /// ��ɌĂ΂��
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

        //���C�̍쐬
        Ray ray = new Ray(Camera.main.transform.localPosition, Camera.main.transform.forward);
        RaycastHit hit;

        const float maxDistance = 600;

        //��Ƀq�b�g�����I�u�W�F�N�g���������ꍇ
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
            //�ˌ��̔����ꏊ
            Vector3 position = Camera.main.transform.localPosition;
            //�ˌ��̃N���[��
            GameObject shotClone = (GameObject)Instantiate(_shotOriginal, position, Quaternion.identity);
            //AddForce�Ō����o��
            Rigidbody shotRigidbody = shotClone.gameObject.GetComponent<Rigidbody>();
            //�J�����̌����̕����փp���[��������
            shotRigidbody.AddForce(Camera.main.transform.forward * 10000);
            PlayerBase.GetInstance().PlayerAttack();
        }
    }
}
