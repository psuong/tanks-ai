using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TankHealth))]
public class TankHealthInspector : Editor {

    TankHealth tankHealth;

    
    void OnEnable() {
        tankHealth = (TankHealth)target;
    }

    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        var rect = EditorGUILayout.BeginVertical();
        EditorGUI.ProgressBar(
            rect, 
            tankHealth.CurrentHealth / tankHealth.tankHealth,
            "Current Health");

        GUILayout.Space(20);

        EditorGUILayout.EndVertical();
    }

}
