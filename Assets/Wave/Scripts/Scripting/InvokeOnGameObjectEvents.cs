using System;
using UnityEngine;
using UnityEngine.Events;

namespace SuprStijl.Buddy.Unity.Modules.Scripting.Invocation
{
    public class InvokeOnGameObjectEvents : MonoBehaviour
    {
        public DisableEvent Disabled;

        public EnableEvent Enabled;

        private void OnDisable()
        {
            this.Disabled.Invoke();
        }

        private void OnEnable()
        {
            this.Enabled.Invoke();
        }

        [Serializable]
        public class EnableEvent : UnityEvent
        {
        }

        [Serializable]
        public class DisableEvent : UnityEvent
        {
        }
    }
}