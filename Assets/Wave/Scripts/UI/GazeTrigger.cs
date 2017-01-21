namespace Wave.UI
{
    using System;

    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    public class GazeTrigger : MonoBehaviour
    {
        /// <summary>
        ///   Graphic to fill with trigger ratio.
        /// </summary>
        public Image FillImage;

        /// <summary>
        ///   Duration to focus gaze on this to invoke trigger (in s).
        /// </summary>
        [Tooltip("Duration to focus gaze on this to invoke trigger (in s)")]
        public float FocusDurationForClick = 1;

        public UnityEvent OnTrigger;

        public Button TriggerButton;

        private float focusDuration;

        private bool isFocused;

        public float FocusDuration
        {
            get
            {
                return this.focusDuration;
            }
            private set
            {
                if (Math.Abs(value - this.focusDuration) < 0.0001f)
                {
                    return;
                }

                this.focusDuration = value;

                if (this.FillImage != null)
                {
                    this.FillImage.fillAmount = this.FocusDurationForClick <= 0
                        ? 1
                        : this.focusDuration / this.FocusDurationForClick;
                }

                if (this.focusDuration >= this.FocusDurationForClick)
                {
                    this.OnTrigger.Invoke();
                    if (this.TriggerButton != null)
                    {
                        this.TriggerButton.onClick.Invoke();
                    }
                    this.isFocused = false;
                }
            }
        }

        public void GazeFocusGained()
        {
            this.FocusDuration = 0;
            this.isFocused = true;
        }

        public void GazeFocusLost()
        {
            this.FocusDuration = 0;
            this.isFocused = false;
        }

        private void Update()
        {
            if (!this.isFocused)
            {
                return;
            }

            this.FocusDuration += Time.deltaTime;
        }
    }
}