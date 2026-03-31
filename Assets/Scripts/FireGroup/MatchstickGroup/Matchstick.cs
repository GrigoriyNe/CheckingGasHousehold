using System;
using UnityEngine;

namespace FireGroup
{
    public class Matchstick : MonoBehaviour
    {
        public Action<Matchstick> IsBurned;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out BurnerFirerer burnerFirerer))
            {
                burnerFirerer.ChangeFire(true);
                IsBurned?.Invoke(this);
            }
        }
    }
}