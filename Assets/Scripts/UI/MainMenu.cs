
    using System;
    using UnityEngine;

    public class MainMenu : MonoBehaviour
    {
        private GameObject _startButton;
        private GameObject _exitButton;
        
        
        void Start()
        {
            _startButton = GameObject.Find("StartButton");
            _exitButton = GameObject.Find("ExitButton");
        }
        
        
        private void OnDisable()
        {
            _startButton.SetActive(false);
            _exitButton.SetActive(false);
            gameObject.SetActive(false);
        }
    }
