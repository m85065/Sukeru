
    using System;
    using UnityEngine;

    public class CameraFollower : MonoBehaviour
    {
        
        private GameObject _player;
        private Camera _mainCamera;
        private float _horizontalMargin = 0.3f;
        private float _verticalMargin = 0.4f;
        private float _depth = -10.0f;
        private Vector3 _targetPosition;
        private Vector3 _lastPosition;
        private Vector3 _currentVelocity ;
        [SerializeField]
        private float _smoothTime = 0.3f;

        private void OnEnable()
        {
            _player = GameObject.FindWithTag("Player");
            _mainCamera = Camera.main;
            //_lastPosition = _player.transform.position;

        }

        private void LateUpdate()
        {
            SetTargetPosition();
            CameraMove();

        }

        private void SetTargetPosition()
        {
            Vector3 movement = _player.transform.position - _lastPosition;
            Vector3 screenPosition = _mainCamera.WorldToViewportPoint(_player.transform.position);
            Vector3 bottomLeft = _mainCamera.ViewportToWorldPoint(new Vector3(_horizontalMargin, _verticalMargin, 0));
            Vector3 topRight = _mainCamera.ViewportToWorldPoint(new Vector3(1 - _horizontalMargin, 1 - _verticalMargin, 0));
            if (screenPosition.x < bottomLeft.x || screenPosition.x > topRight.x)
            {
                _targetPosition.x += movement.x * GameManager.Instance.GetGameSpeed();
            }
            if (screenPosition.y < bottomLeft.y || screenPosition.y > topRight.y)
            {
                _targetPosition.y += movement.y* GameManager.Instance.GetGameSpeed();
            }
            _targetPosition.z = _depth;
            
            _lastPosition = _player.transform.position;
        }

        private void CameraMove()
        {
          transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _currentVelocity, _smoothTime);
        }
    }
