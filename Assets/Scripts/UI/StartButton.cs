using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class StartButton : MonoBehaviour
{
    private GameObject _mainCamera;
    private UnityEngine.UI.Button _startButton;
    private Vector3 _targetPosition;
    private Vector3 _currentVelocity = Vector3.zero;
    private bool _gameStart = false;
    // Start is called before the first frame update
    void Start()
    {
        _mainCamera =GameObject.Find("Main Camera");
        _startButton = GetComponent<UnityEngine.UI.Button>();
        _startButton.onClick.AddListener(gameStart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (_gameStart)
        {
            if (Vector2.Distance(_mainCamera.transform.position, _targetPosition) > 0.1f)
            {
                MoveCameraStart();
            }
            else
            {
                gameObject.SetActive(false);
            }

            
        }


    }

    public void gameStart()
    {
        var rootobjs = FindObjectsByType<GameObject>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        var spawnPoint = rootobjs.First( x => x.name == "SpawnPoint");
        spawnPoint.SetActive(true);
        _targetPosition = spawnPoint.transform.position;
        _gameStart = true;
        
    }

    private void MoveCameraStart()
    {
        _mainCamera.transform.position = Vector3.SmoothDamp(_mainCamera.transform.position, _targetPosition, ref _currentVelocity, 0.3f);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(gameStart);
        Destroy(gameObject);
    }
}
