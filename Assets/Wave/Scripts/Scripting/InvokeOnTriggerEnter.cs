using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Events;

namespace SuprStijl.Buddy.Unity.Modules.Enemies.Views
{
    public class InvokeOnTriggerEnter : MonoBehaviour
    {
        public TriggerEnteredEvent TriggerEntered;

        public string TriggerTag = "Projectile";

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == this.TriggerTag)
            {
#if UNITY_EDITOR
                //EditorApplication.isPaused = true;
#endif
                this.TriggerEntered.Invoke(other.attachedRigidbody != null
                    ? other.attachedRigidbody.gameObject
                    : other.gameObject);
            }
        }

        [Serializable]
        public class TriggerEnteredEvent : UnityEvent<GameObject>
        {
        }
    }
}