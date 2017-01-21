using System;
using UnityEngine;
using UnityEngine.Events;

namespace SuprStijl.Buddy.Unity.Modules.Enemies.Views
{
    public class InvokeOnCollisionEnter : MonoBehaviour
    {
        public string ColliderTag = "Projectile";

        public EnteredEvent Entered;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag == this.ColliderTag)
            {
                this.Entered.Invoke(collision.collider.gameObject, collision.contacts[0].point);
            }
        }

        [Serializable]
        public class EnteredEvent : UnityEvent<GameObject, Vector3>
        {
        }
    }
}