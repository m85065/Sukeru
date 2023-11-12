using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private void OnEnable()
    {

        var mainCamera = Camera.main;
        gameObject.transform.position = mainCamera.transform.position + new Vector3(mainCamera.rect.xMax+50.0f, 0, 0)  ;
    }

    // Start is called before the first frame update
    void Start()
    {
        // TODO: Spawn a new player object
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
