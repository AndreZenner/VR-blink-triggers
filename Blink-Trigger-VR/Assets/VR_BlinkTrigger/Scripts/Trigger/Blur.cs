using System.Collections;
using UnityEngine;

namespace BT
{
    public class Blur : BlinkTrigger
    {
        [Range(0.0f, 0.05f)]
        public float maxBlurIntesity = 0.04f;

        [SerializeField] private Material _material;
        [SerializeField] private float _fadeInDuration =  2f;
        [SerializeField] private float _totalBlurDuration =  4f;

        public void SetupTrigger(float maxIntensity, float fadeInDuration, float totalBlurDuration)
        {
            maxBlurIntesity = maxIntensity;
            _fadeInDuration = fadeInDuration;
            _totalBlurDuration = totalBlurDuration;
        } 

        public override void StartTrigger()
        {
            StopAllCoroutines();
            TriggerManager.Instance.OnTriggerStart?.Invoke();
            cameraImageEffect.SetShaderMaterial(_material);
            StartCoroutine("BlurCoroutine");
        }

        IEnumerator BlurCoroutine()
        {
            float elapsedTime = 0.0f;

            while(elapsedTime < _totalBlurDuration)
            {
                elapsedTime += Time.deltaTime;
                float blurSize = Mathf.Lerp(0f, maxBlurIntesity, (elapsedTime / _fadeInDuration));
                _material.SetFloat("_BlurSize", blurSize);

                yield return null;
            }
            _material.SetFloat("_BlurSize", 0);
            cameraImageEffect.SetShaderMaterial(null);
            TriggerManager.Instance.OnTriggerEnd?.Invoke();
        }

        public override void StopBlinkTriggerCoroutines()
        {
            StopCoroutine("BlurCoroutine");
            _material.SetFloat("_BlurSize", 0);
            cameraImageEffect.SetShaderMaterial(null);
            TriggerManager.Instance.OnTriggerEnd?.Invoke();
        }
    }
}