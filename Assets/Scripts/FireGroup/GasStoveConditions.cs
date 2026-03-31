using System.Collections.Generic;
using UnityEngine;

namespace FireGroup
{
    public class GasStoveConditions : MonoBehaviour
    {
        [SerializeField] private int _countDestroedBurner;
        [SerializeField] private List<BurnerView> _fires;

        private void Start()
        {
            if (_countDestroedBurner > 0)
            {
                if (_countDestroedBurner > _fires.Count)
                {
                    _countDestroedBurner = _fires.Count;
                }

                for (int i = 0; i < _countDestroedBurner; i++)
                {
                    BurnerView fire = _fires[Random.Range(0, _fires.Count)];

                    if (fire.IsBroken == false)
                    {
                        fire.Break();
                    }
                }
            }
        }

        public void Randomize()
        {
            _countDestroedBurner = Random.Range(0, _fires.Count);
        }
    }
}
