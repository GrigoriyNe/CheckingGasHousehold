using UnityEngine;

namespace Switch
{
    public partial class SwitchReader : MonoBehaviour
    {
        [SerializeField] private RotaterInvoker _rotater;

        private bool _isTaked = false;

        private void Update()
        {
            if (_isTaked)
                _rotater.SetRotation(transform.rotation.y);
        }

        public void StartRotate()
        {
            _isTaked = true;
        }

        public void StopRotate()
        {
            _isTaked = false;
        }
    }
}