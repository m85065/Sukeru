
    using System;
    using UnityEngine;

    public class EnemyController: MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private Camera _mainCamera;
        private float _speed = 0.3f;

        private void Awake()
        {
            _mainCamera = Camera.main;

        }

        private void OnEnable()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.velocity = new Vector2(_speed, 0.0f);
            
        }

        private void FixedUpdate()
        {
            Vector3 screenPosition = _mainCamera.WorldToViewportPoint(transform.position);
            Vector3 bottomLeft = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
            if (screenPosition.x < bottomLeft.x)
            {
                _speed *= 1.02f;
            }
            else
            {
                _speed = 0.2f * GameManager.Instance.GetGameSpeed();
            }
           
                _rigidbody2D.velocity = new Vector2(_speed,0.0f) * GameManager.Instance.GetGameSpeed();
            
        }
        

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameManager.Instance.GameOver();
            }
            if (other.gameObject.CompareTag("Obstacle"))
            {
                _speed *= 0.8f;
            }
        }
    }
