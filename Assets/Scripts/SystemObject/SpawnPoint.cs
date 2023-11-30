using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    
    private GameObject _player;
    private void OnEnable()
    {

        var mainCamera = Camera.main;
        gameObject.transform.position = mainCamera.transform.position + new Vector3(mainCamera.rect.xMax+10.0f, 0, 0)  ;
        _player = Resources.Load<GameObject>("Prefabs/Player");
        Vector3 spawnPosition;
        spawnPosition.x = gameObject.transform.position.x;
        spawnPosition.y = gameObject.transform.position.y;
        spawnPosition.z = 0;
        
        Instantiate(_player, spawnPosition, Quaternion.identity);
        
        Destroy(gameObject);
    }


}
