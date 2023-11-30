
    using System.Linq;
    using UnityEngine;

    public class GameManager : GenericSingleton<GameManager>
    {
        
        private bool _isGameStarted = false;
        private bool _isGameOver = false;
        private bool _enemySpawned = false;
        
        private GameObject _mainCamera; 
        private GameObject _player;

        [SerializeField]
        private float _gamespeed = 1.0f;
        
        private float _time;
        void Start()
        {
           
        _mainCamera = GameObject.Find("Main Camera");
        _time = 0f;

        }
        
        void Update()
        {
            if (_isGameStarted)
            {
                _time +=  Time.deltaTime*Time.timeScale;
                if (_time > 5.0f)
                {
                    _gamespeed += 0.01f;
                    _time = 0f;
                    if (!_enemySpawned)
                    {
                        var enemy = FindObjectsByType<GameObject>(FindObjectsInactive.Include, FindObjectsSortMode.None);;
                        enemy.First( x => x.name == "Monster").SetActive(true);
                        _enemySpawned = true;
                    }

                }
            }
        }
        
        public void StartGame()
        {
            _isGameStarted = true;
            _player = GameObject.FindWithTag("Player");
            GameObject _mainMenu = GameObject.Find("MainMenu");
            _mainMenu.SetActive(false);
            Vector3 targetPosition = _player.transform.position;
            targetPosition.z = -10;
            _mainCamera.GetComponent<CameraStarter>().SetTargetPosition(targetPosition);
            _mainCamera.GetComponent<CameraStarter>().enabled = true;
            
        }
        
        public void GameOver()
        {
            _isGameOver = true;
            Time.timeScale = 0.0f;
            
        }
        public bool IsGameStarted()
        {
            return _isGameStarted;
        }


        public float GetGameSpeed()
        {
            return _gamespeed;
        }
    }
