
    using System;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class PlayerController: MonoBehaviour
    {
        private bool _isRunning = true;
        private Transform _transform;
        private Vector3 _movement;
        [SerializeField]
        private float _speed = 2.0f;
        [SerializeField]
        private float _jumpForce = 15.0f;
        private Rigidbody2D _rigidbody2D;
        
        private bool _isGrounded;
        private bool _isJumping;
        private Vector3 _lastPosition;
        private Vector3 _targetPosition;
        private Vector3 _currentVelocity;
        [SerializeField]
        private float _smoothTime = 0.3f;

        [SerializeField]
        private PlayerInput _playerInput;

        
        
        [SerializeField]
        private float _radius = 0.5f;
        private void Awake()
        {
            _transform = gameObject.transform;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerInput = GetComponent<PlayerInput>();
            _playerInput.camera = Camera.main;

            
            _playerInput.actions["Jump"].performed += Jump;
            _playerInput.actions["ScaleUp"].performed += OnScaleUp;
            _playerInput.actions["ScaleDown"].performed += OnScaleDown;

            
        }

        private void OnScaleDown(InputAction.CallbackContext obj)
        {
            var gameobj = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Launcher>();
            gameobj.Shoot();
        }

        private void OnScaleUp(InputAction.CallbackContext obj)
        {
            var gameobj = gameObject.transform.GetChild(1).GetChild(0).GetComponent<Launcher>();
            gameobj.Shoot();
        }


        private void LateUpdate()
        {
            KeepRunning();
            detectGround();

      
        }

        private void detectGround()
        {
            //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.765f, LayerMask.GetMask("Structure"));
            RaycastHit2D hit =Physics2D.CircleCast(transform.position, _radius, Vector2.down, 0.1f, LayerMask.GetMask("Structure"));
            if (hit.collider is not null && hit.collider.CompareTag("Structure"))
            {
                _isGrounded = true;
                _isJumping = false;
            }
            else
            {
                _isGrounded = false;
            }
        }


        private void KeepRunning()
        {
           
                _rigidbody2D.velocity = new Vector2(_speed * GameManager.Instance.GetGameSpeed(), _rigidbody2D.velocity.y);
            
           
            
   
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                GameManager.Instance.GameOver();
            }
            
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, _radius);

        }

        public void Jump(InputAction.CallbackContext context)
        {
             if (_isGrounded)
            {    
                _isJumping = true;
                _rigidbody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
                Debug.Log(_rigidbody2D.velocity.ToString());
                _isGrounded = false;
            }
        }
    }
