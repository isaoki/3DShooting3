using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotBase : MonoBehaviour
{
    /// <summary>
    /// ‰½‚©‚É‚Ô‚Â‚©‚Á‚½‚ç
    /// </summary>
    // Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Enemy")
        {
            if (other.tag == "MainCamera")
            {
                PlayerBase.GetInstance().PlayerDamage();
            }
            Destroy(gameObject);
        }
    }

}
