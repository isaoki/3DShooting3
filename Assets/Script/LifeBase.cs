using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeBase : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _lifeText;
    public void SetLife(int life)
    {
        _lifeText.text = "LIFE:" + life;
    }
}
