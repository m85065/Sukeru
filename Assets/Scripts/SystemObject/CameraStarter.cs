
    using System;
    using UnityEngine;

    public class CameraStarter : MonoBehaviour
    {        
        private GameObject _mainCamera; 
        private Vector3 _targetPosition;
        private Vector3 _currentVelocity = Vector3.zero;

        private void Start()
        {
            _mainCamera = GameObject.Find("Main Camera");
        }

        private void MoveCameraStart()
        {
            _mainCamera.transform.position = Vector3.SmoothDamp(_mainCamera.transform.position, _targetPosition, ref _currentVelocity, 0.3f);
        }
        
        public void SetTargetPosition(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
        }
        
        private void LateUpdate()
        {
            if (GameManager.Instance.IsGameStarted())
            {
                if (Vector2.Distance(_mainCamera.transform.position, _targetPosition) > 0.1f)
                {
                    MoveCameraStart();
                }
                else
                {
                    _mainCamera.GetComponent<CameraFollower>().enabled = true;
                    this.enabled = false;
                }
            
            }


        }
    }
