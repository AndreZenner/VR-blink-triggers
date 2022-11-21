using System.Collections;
using UnityEngine;

namespace BT
{
    public class ApproachingObject : BlinkTrigger
    {

        [SerializeField] private GameObject _objectPrefab;
        [SerializeField] private float _size = 0.1f;
        [SerializeField] private Vector3 _offsetStart = new Vector3(0,0,4);
        [SerializeField] private float _duration = 2f;
      
        private GameObject objectClone;
        private Vector3 startPosition;

        public void Awake()
        {
            Camera.main.nearClipPlane = 0.01f;
        }

        public void SetupTrigger(float duration)
        {
            _duration = duration;
        }

        public override void StartTrigger()
        {
            StopBlinkTriggerCoroutines();
            TriggerManager.Instance.OnTriggerStart?.Invoke();
            startPosition = Camera.main.transform.TransformPoint( _offsetStart);
            objectClone = Instantiate(_objectPrefab, startPosition, Quaternion.identity, Camera.main.gameObject.transform);
            objectClone.transform.localScale = new Vector3(_size, _size, _size);
            StartCoroutine("MovingObjectCoroutine"); 
        }

        IEnumerator MovingObjectCoroutine()
        {
            float elapsedTime = 0.0f;

            while (elapsedTime < _duration)
            {
              
                elapsedTime += Time.deltaTime;

                objectClone.transform.localPosition = Vector3.Lerp(_offsetStart, Vector3.zero, (elapsedTime / _duration));
                
                yield return null;
            }
            Destroy(objectClone);
            TriggerManager.Instance.OnTriggerEnd?.Invoke();
        }

        public override void StopBlinkTriggerCoroutines()
        {
            StopCoroutine("MovingObjectCoroutine");
            if(objectClone) Destroy(objectClone);
            TriggerManager.Instance.OnTriggerEnd?.Invoke();
        }
    }
}
