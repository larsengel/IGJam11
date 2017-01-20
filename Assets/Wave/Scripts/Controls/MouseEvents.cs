namespace Wave.Controls
{
    using UnityEngine;
    using UnityEngine.Events;

    public class MouseEvents : MonoBehaviour
    {
        public UnityEvent MouseEnter;

        public UnityEvent MouseExit;

        private void OnMouseEnter()
        {
            this.MouseEnter.Invoke();
        }

        private void OnMouseExit()
        {
            this.MouseExit.Invoke();
        }
    }
}