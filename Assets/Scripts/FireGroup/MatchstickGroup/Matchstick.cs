using System;
using UnityEngine;

namespace FireGroup
{
    public class Matchstick : MonoBehaviour
    {
        public Action<Matchstick> IsBurned;

        private void OnTriggerStay(Collider collider)
        {
            if (collider.TryGetComponent(out BurnerFirerer burnerFirerer))
            {
                if (burnerFirerer.IsFirePossible)
                {
                    burnerFirerer.ChangeFire(true);
                    IsBurned?.Invoke(this);
                }
            }
        }
    }
}
