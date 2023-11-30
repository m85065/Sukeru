    using AnimeTask;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private BulletType _bulletType;

        private Rigidbody2D _rigidbody2D;
        private Camera _camera;
        private Vector3 _mousePosition;
        private Vector3 _direction;
        private Quaternion _rotation;
        private void Awake()
        {

            _camera = Camera.main;
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        private void FixedUpdate()
        {   
            _rigidbody2D.velocity = _direction * 3.0f;
            transform.rotation = _rotation;
            CheckOutSideCamera();

        }

        private void CheckOutSideCamera()
        {
            Vector3 screenPoint = _camera.WorldToViewportPoint(transform.position);
            bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 &&
                            screenPoint.y < 1;
            if (!onScreen)
            {
                Destroy(gameObject);
            }
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction * 3.0f;
            _rotation = transform.rotation;

        }
        
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            switch(other.gameObject.tag)
            {
                case "Player":
                    ScaleObject(other);
                    break;
                case "Obstacle":
                    ScaleObject(other);
                    break;
                case "Reflector":
                    ReflectBullet(other);
                    break;
                case "Structure":
                    Destroy(gameObject);
                    break;
                default:
                    Destroy(gameObject);
                    break;
            }
            
        }

        private void ScaleObject(Collision2D other)
        {
            if (_bulletType == BulletType.ScaleUp)
            {
                Easing.Create<OutElastic>(to: 1.2f, duration: 0.2f).ToLocalScale(other.gameObject);
            }
            else if (_bulletType == BulletType.ScaleDown)
            {
                Easing.Create<InQuart>(to:0.8f, duration: 0.2f).ToLocalScale(other.gameObject);
            }
        }

        private void ReflectBullet(Collision2D other)
        {
          Vector2 inDirection = _rigidbody2D.velocity;
          Vector2 inNormal = other.contacts[0].normal;
          if (inNormal.x < 0.01f)
          {
                inNormal.x = 0f;
          }
          if (inNormal.y < 0.01f)
          {
                inNormal.y = 0f;
          }
          _direction = Vector2.Reflect(inDirection, inNormal);
          
          _rotation = Quaternion.Inverse(_rotation);
        }
    }


    public enum BulletType
    {
         ScaleUp,
         ScaleDown
    }