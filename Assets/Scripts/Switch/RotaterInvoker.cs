using System;
using UnityEngine;

namespace Switch
{
    public class RotaterInvoker : MonoBehaviour
    {
        [SerializeField] private float _minRotation;
        [SerializeField] private float _maxRotation;
        [SerializeField] private float _startRotation;

        public event Action<float> Rotated;

        private void Start()
        {
            SetMinValue();
        }

        public void SetRotation(float rotationY)
        {
            if (rotationY < 0 && transform.rotation.y <= _minRotation)
            {
                return;
            }
            else if (rotationY > 0 && transform.rotation.y >= _maxRotation)
            {
                return;
            }

            transform.RotateAround(transform.position, transform.up, rotationY);
            Rotated?.Invoke(transform.rotation.y);
        }

        private void SetMinValue()
        {
            transform.RotateAround(transform.position, transform.up, _minRotation);
        }
    }
}