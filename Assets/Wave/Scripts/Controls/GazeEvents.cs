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

	        public bool HasGazeFocus
	        {
	            get
	            {
	                return this.hasGazeFocus;
	            }
	            set
	            {
	                if (value == this.hasGazeFocus)
	                {
	                    return;
	                }
	                this.hasGazeFocus = value;

	                if (value)
	                {
	                    this.GazeFocusGained.Invoke();
	                }
	                else
	                {
	                    this.GazeFocusLost.Invoke();
	                }
	            }
	        }
	        
	        private void Reset()
	        {
	            if (this.Target == null)
	            {
	                this.Target = this.GetComponent<GazeAware>();
	            }
	        }

	        private void Update()
	        {
	            if (this.Target != null)
	            {
	                this.HasGazeFocus = this.Target.HasGazeFocus;
	            }
	        }
	    }

}