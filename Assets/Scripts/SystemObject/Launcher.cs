
    using UnityEngine;

    public class Launcher : MonoBehaviour
    {

        [SerializeField]
        private GameObject _bullet;
        


        public void Shoot()
        {
            var position = gameObject.transform.position;
            var rotation = gameObject.transform.rotation;
            var bullet = Instantiate(_bullet, position, rotation);
            var direction = (transform.position - transform.parent.position).normalized;
            bullet.GetComponent<Bullet>().SetDirection(direction);
        }



    }
