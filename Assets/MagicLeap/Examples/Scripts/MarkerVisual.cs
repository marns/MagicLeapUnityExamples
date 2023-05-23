using System.Collections;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

namespace MagicLeap.Examples
{
    public class MarkerVisual : MonoBehaviour
    {
		// Correction for ML2 to match Unity coords system
		private static readonly Quaternion rotationCorrection = Quaternion.Euler(-90f, -180f, 0f);

		[SerializeField] 
        private TextMesh dataText;

        public float Timestamp { get; private set; }
        public string DataString => dataText != null ? dataText.text : string.Empty;
        public MLMarkerTracker.MarkerType Type { get; set; }

        public void Set(MLMarkerTracker.MarkerData data, string dataString = null)
        {
            Timestamp = Time.time;

            Type = data.Type;
            transform.position = data.Pose.position;
            transform.rotation = data.Pose.rotation * rotationCorrection;
            dataText.text = dataString ?? data.ToString();
            gameObject.SetActive(true);
        }
    }
}
