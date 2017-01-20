namespace Wave.Controls
{
    using Tobii.EyeTracking;

    using UnityEngine;
    using UnityEngine.Events;

    public class GazeEvents : MonoBehaviour
    {
        public UnityEvent GazeFocusGained;

        public UnityEvent GazeFocusLost;

        public GazeAware Target;

        private bool hasGazeFocus;

        private void Reset()
        {
            if (this.Target == null)
            {
                this.Target = this.GetComponent<GazeAware>();
            }
        }

        private void Update()
        {
            if (this.Target == null)
            {
                return;
            }

            var hasGazeFocusNow = this.Target.HasGazeFocus;
            if (this.hasGazeFocus != hasGazeFocusNow)
            {
                if (hasGazeFocusNow)
                {
                    this.GazeFocusGained.Invoke();
                }
                else
                {
                    this.GazeFocusLost.Invoke();
                }

                this.hasGazeFocus = hasGazeFocusNow;
            }
        }
    }
}