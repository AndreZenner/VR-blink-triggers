using System.Collections;
using System.IO.Ports;
using UnityEngine;

namespace BT
{
    public class AirPuff : BlinkTrigger
    {
        public string portName;
        public SerialPort arduino;

        [SerializeField] private float _duration = 0.3f;

        public override void StartTrigger()
        {
            StopAllCoroutines();
            TriggerManager.Instance.OnTriggerStart?.Invoke();
            arduino.Write(_duration.ToString());
            StartCoroutine("AirPuffCoroutine");
        }

        IEnumerator AirPuffCoroutine()
        {
            float elapsedTime = 0.0f;

            while (elapsedTime < _duration)
            {
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            TriggerManager.Instance.OnTriggerEnd?.Invoke();
        }

        public override void StopBlinkTriggerCoroutines()
        {
            StopCoroutine("AirPuffCoroutine");
            TriggerManager.Instance.OnTriggerEnd?.Invoke();
        }

        public void SetupArduino()
        {
            arduino = new SerialPort(portName, 9600);
            if (!arduino.IsOpen)
            {
                arduino.Open();
            }
        }

        public void SetupTrigger(float dur)
        {
            _duration = dur;
        }
    }
}