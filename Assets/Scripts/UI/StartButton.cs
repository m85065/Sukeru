using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AnimeTask;
using Cysharp.Threading.Tasks;
using UnityEngine;
public class StartButton : MonoBehaviour
{
    private GameObject _mainCamera;
    private UnityEngine.UI.Button _startButton;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera =GameObject.Find("Main Camera");
        _startButton = GetComponent<UnityEngine.UI.Button>();
        _startButton.onClick.AddListener(GameStart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public async void GameStart()
    {
        await Easing.Create<InQuart>(to: 0.8f, duration: 0.1f).ToLocalScale(_startButton);
        await UniTask.Delay(TimeSpan.FromSeconds(0.1));
        await Easing.Create<OutElastic>(to: 1f, duration: 0.4f).ToLocalScale(_startButton);
        var rootobjs = FindObjectsByType<GameObject>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        var spawnPoint = rootobjs.First( x => x.name == "SpawnPoint");
        spawnPoint.SetActive(true);
        GameManager.Instance.StartGame();
        
    }



    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(GameStart);
        Destroy(gameObject);
    }
}
