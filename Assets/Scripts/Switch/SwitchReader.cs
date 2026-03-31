using UnityEngine;

namespace Switch
{
    public partial class SwitchReader : MonoBehaviour
    {
        private const float MaxAngle = 90f;

        [SerializeField] private GasRegulator _rotator;
        [SerializeField] private float _minRotation;
        [SerializeField] private float _maxRotation;

        private bool _isTaked = false;

        private void Start()
        {
            transform.rotation = Quaternion.identity;
        }

        private void Update()
        {
            if (_isTaked)
                _rotator.SetRotation(transform.rotation.z);
        }

        public void StartRotate()
        {
            _isTaked = true;
        }

        public void StopRotate()
        {
            _isTaked = false;

            if (transform.rotation.z < _minRotation)
            {
                transform.rotation = Quaternion.identity;
            }
            if (transform.rotation.z > _maxRotation)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, MaxAngle));
            }
        }
    }
}
