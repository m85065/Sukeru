using UnityEngine;
using UnityEngine.InputSystem;
    public class TargetLocator: MonoBehaviour
    {
        private Camera _camera;
        private Mouse _mouse;
        private Vector3 _mousePosition;
        
        private void Start()
        {
            _mouse = Mouse.current;
            _camera = Camera.main;
        }
        
        
        private void FixedUpdate()
        {
 
            TrackMouse();

        }
        
        
        private void TrackMouse()
        {
            _mousePosition = _camera.ScreenToWorldPoint(_mouse.position.value);
            _mousePosition.z = 0;
            Vector3 rotation = _mousePosition - transform.position;
            float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        }
        
    }
