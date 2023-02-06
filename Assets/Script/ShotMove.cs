using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ’eŠÛ‚Ìˆ—
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
        //ŠÔ‚ğŒ¸‚ç‚·
        _shotLifeTimer -= Time.deltaTime;
        //¶‘¶ŠÔ‚ª–³‚¢‚È‚ç
        if(_shotLifeTimer <= 0)
        {
            Destroy(gameObject);    
        }
    }
    /// <summary>
    /// ‰½‚©‚É‚Ô‚Â‚©‚Á‚½‚çŒÄ‚Ño‚³‚ê‚éˆ—
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
