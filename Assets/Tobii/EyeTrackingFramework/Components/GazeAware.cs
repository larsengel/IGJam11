//-----------------------------------------------------------------------
// Copyright 2016 Tobii AB (publ). All rights reserved.
//-----------------------------------------------------------------------

using UnityEngine;

namespace Tobii.EyeTracking
{
    using UnityEngine.EventSystems;

    [AddComponentMenu("Eye Tracking/Gaze Aware")]
    public class GazeAware : MonoBehaviour, IGazeFocusable
    {
        /// <summary>
        /// True if the user is focusing this object using his or her eye-gaze,
        /// false otherwise.
        /// </summary>
        public bool HasGazeFocus { get; private set; }

        private RectTransform rectTransform;

        void Start()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        void OnEnable()
        {
            GazeFocusHandler().RegisterFocusableComponent(this);
        }

        void OnDisable()
        {
            GazeFocusHandler().UnregisterFocusableComponent(this);
        }
        
        void Update()
        {
            if (this.rectTransform == null)
            {
                return;
            }
            var gazePoint = EyeTracking.GetGazePoint();
            var gazePosition = Input.mousePosition;
            if (gazePoint.IsValid)
            {
                gazePosition = gazePoint.GUI;
            }
            this.HasGazeFocus = RectTransformUtility.RectangleContainsScreenPoint(this.rectTransform, gazePosition);
        }

        /// <summary>
        /// Function called from the gaze focus handler when the gaze focus for
        /// this object changes.
        /// </summary>
        /// <remarks>Since the implementation is explicit, it will not be 
        /// visible on instances of this component (unless cast to 
        /// <see cref="IGazeFocusable"/>).
        /// </remarks>
        /// <param name="hasFocus">True if the game object has gaze focus, 
        /// false otherwise.</param>
        void IGazeFocusable.UpdateGazeFocus(bool hasFocus)
        {
            HasGazeFocus = hasFocus;
        }
        
        private IRegisterGazeFocusable GazeFocusHandler()
        {
            return (IRegisterGazeFocusable)EyeTrackingHost.GetInstance().GazeFocus;
        }
    }
}
