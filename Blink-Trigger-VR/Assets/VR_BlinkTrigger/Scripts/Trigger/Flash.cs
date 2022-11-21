using System.Collections;
using UnityEngine;

namespace BT
{
    public class Flash : BlinkTrigger
    {
        [SerializeField] private Material _material;
        [SerializeField] private Color _color;

        public override void StartTrigger()
        {
            StopAllCoroutines();
            TriggerManager.Instance.OnTriggerStart?.Invoke();
            _material.color = _color;
            StartCoroutine("FlashCoroutine");
        }

        IEnumerator FlashCoroutine()
        {
            yield return null;
            cameraImageEffect.SetShaderMaterial(_material);
            yield return null;
            cameraImageEffect.SetShaderMaterial(null);
            TriggerManager.Instance.OnTriggerEnd?.Invoke();
        }

        public override void StopBlinkTriggerCoroutines()
        {
            StopCoroutine("FlashCoroutine");
            cameraImageEffect.SetShaderMaterial(null);
            TriggerManager.Instance.OnTriggerEnd?.Invoke();
        }

        public void SetupTrigger(Color col)
        {
            _color = col;
        }
    }
}