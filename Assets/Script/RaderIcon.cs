using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaderIcon : MonoBehaviour
{
    void Update()
    {
        Vector3 parentAngle = transform.parent.transform.localRotation.eulerAngles;
        gameObject.transform.rotation = Quaternion.Euler(90, parentAngle.y, parentAngle.z);
    }
}
