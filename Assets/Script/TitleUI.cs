using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    [SerializeField] private Button _gameStartButton;
    [SerializeField] private Animator _playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        _playerAnimation.SetBool("Opening", true);
        _gameStartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("main");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
