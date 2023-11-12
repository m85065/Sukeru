using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    private UnityEngine.UI.Button _exitButton;
    // Start is called before the first frame update
    void Start()
    {
        _exitButton = GetComponent<UnityEngine.UI.Button>();
        _exitButton.onClick.AddListener(gameExit);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void gameExit()
    {
        Application.Quit();
    }
}
