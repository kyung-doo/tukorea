using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Main))]
public class MainEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("audio skip"))
        {
            Main.Instance.SkipAudio();
        }
    }
}