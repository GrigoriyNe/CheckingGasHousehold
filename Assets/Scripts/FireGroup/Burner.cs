using System;
using UnityEngine;
using Switch;

namespace FireGroup
{
    public class Burner : MonoBehaviour
    {
        [SerializeField] private GameObject _fireEffect;
        [SerializeField] private GameObject _gasEffect;
        [SerializeField] private GasRegulator _gasRegulator;

        public bool IsChecked { get; private set; }

        public bool IsFirePossible =>
            _gasRegulator.transform.rotation.z > 0;

        public event Action Checked;

        private void OnEnable()
        {
            IsChecked = false;
            _gasRegulator.Rotated += OnSwitchRotated;
        }

        private void OnDisable()
        {
            _gasRegulator.Rotated -= OnSwitchRotated;
        }

        public void ChangeFire(bool isActiveFire)
        {
            if (isActiveFire)
            {
                Checked?.Invoke();
                IsChecked = true;
            }

            _fireEffect.SetActive(isActiveFire);
            _gasEffect.SetActive(!isActiveFire);
        }

        private void OnSwitchRotated(float value)
        {
            if (value <= 0)
            {
                ChangeFire(false);
            }
        }
    }
}
