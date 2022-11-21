using UnityEngine;
using UnityEngine.Events;

namespace BT
{

    public class TriggerManager : MonoBehaviour
    {
        //Blink Trigger
        public Flash Flash { get; private set; }
        public Blur Blur { get; private set; }
        public ApproachingObject ApproachingObject { get; private set; }
        public AirPuff AirPuff { get; private set; }
        public Dummy Dummy {get; private set;}


        public BlinkTrigger CurrentTrigger { get; private set; }
        
        
        public UnityEvent OnTriggerStart;
        public UnityEvent OnTriggerEnd;


        public static TriggerManager Instance;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }

            Flash = GetComponent<Flash>();
            Blur = GetComponent<Blur>();
            ApproachingObject = GetComponent<ApproachingObject>();
            AirPuff = GetComponent<AirPuff>();
            Dummy = GetComponent<Dummy>();
        }


        public void SetTrigger(TriggerType trigger)
        {
            switch (trigger)
            {
                case TriggerType.FlashTrigger:
                    CurrentTrigger = Flash;
                    break;
                case TriggerType.BlurTrigger:
                    CurrentTrigger = Blur;
                    break;
                case TriggerType.AirPuffTrigger:
                    CurrentTrigger = AirPuff;
                    break;
                case TriggerType.ApproachingObjectTrigger:
                    CurrentTrigger = ApproachingObject;
                    break;
                case TriggerType.DummyTrigger:
                    CurrentTrigger = Dummy;
                    break;
            }
        }

        public void StartTrigger()
        {
            CurrentTrigger.StartTrigger();
        }

        public void StartTrigger(TriggerType trigger)
        {
            switch (trigger)
            {
                case TriggerType.FlashTrigger:
                    Flash.StartTrigger();
                    break;
                case TriggerType.BlurTrigger:
                    Blur.StartTrigger();
                    break;
                case TriggerType.AirPuffTrigger:
                    AirPuff.StartTrigger();
                    break;
                case TriggerType.ApproachingObjectTrigger:
                    ApproachingObject.StartTrigger();
                    break;
                case TriggerType.DummyTrigger:
                    Dummy.StartTrigger();
                    break;
            }
        }

        public void StopCurrentTrigger()
        {
            CurrentTrigger.StopBlinkTriggerCoroutines();
        }

        public void StopCurrentTrigger(TriggerType trigger)
        {
            switch (trigger)
            {
                case TriggerType.FlashTrigger:
                    Flash.StopBlinkTriggerCoroutines();
                    break;
                case TriggerType.BlurTrigger:
                    Blur.StopBlinkTriggerCoroutines();
                    break;
                case TriggerType.AirPuffTrigger:
                    AirPuff.StopBlinkTriggerCoroutines();
                    break;
                case TriggerType.ApproachingObjectTrigger:
                    ApproachingObject.StopBlinkTriggerCoroutines();
                    break;
                case TriggerType.DummyTrigger:
                    Dummy.StopBlinkTriggerCoroutines();
                    break;
            }
        }
    }

    public enum TriggerType { FlashTrigger, BlurTrigger, AirPuffTrigger, ApproachingObjectTrigger, DummyTrigger}
}