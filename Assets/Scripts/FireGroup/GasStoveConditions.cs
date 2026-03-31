using System.Collections.Generic;
using UnityEngine;

namespace FireGroup
{
    public class GasStoveConditions : MonoBehaviour
    {
        [SerializeField] private int _countDestroedBurner;
        [SerializeField] private List<FireEffectEditior> _fires;
        [SerializeField] private bool _isGasLeak;

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
                    FireEffectEditior fire = _fires[Random.Range(0, _fires.Count)];

                    if (fire.IsBroken == false)
                    {
                        fire.Brokend();
                    }
                    else
                    {
                        i--;
                    }
                }
            }
        }
    }
}
