using UnityEngine;
using UnityEditor;
using BT;


namespace BTStudy
{
    [CustomEditor(typeof(BlinkTrigger), true)]
    public class BlinkTriggerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            BlinkTrigger trigger = (BlinkTrigger)target;
            if (GUILayout.Button("Start Trigger"))
            {
                trigger.StartTrigger();
            }
        }
    }
}