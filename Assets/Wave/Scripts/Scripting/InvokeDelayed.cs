using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace SuprStijl.Buddy.Unity.Modules.GameOver.Views
{
    public class InvokeDelayed : MonoBehaviour
    {
        /// <summary>
        ///     Duration the event is delayed (in s).
        /// </summary>
        [Tooltip("Duration the event is delayed (in s)")]
        public float DelayDuration;

        public UnityEvent TimerExpired;

        public void StartTimer()
        {
            this.StartCoroutine(this.RunTimer(this.DelayDuration));
        }

        private IEnumerator RunTimer(float duration)
        {
            yield return new WaitForSeconds(duration);

            this.TimerExpired.Invoke();
        }
    }
}