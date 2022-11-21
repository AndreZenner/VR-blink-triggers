using UnityEngine;

namespace BT
{
    public abstract class BlinkTrigger: MonoBehaviour {

        [HideInInspector]
        public ImageEffect cameraImageEffect;

        public abstract void StartTrigger();

        public virtual void StopBlinkTriggerCoroutines()
        {
            StopAllCoroutines();
        }

        void Start()
        {
            cameraImageEffect = Camera.main.GetComponent<ImageEffect>();
            // Application.targetFrameRate = 90;
            // QualitySettings.vSyncCount = 1;
        }

    }
}

