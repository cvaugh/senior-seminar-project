using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DroppedItem))]
public class DroppedItemEditor : Editor {
    SerializedProperty item;

    private void OnEnable() {
        item = serializedObject.FindProperty("itemIndex");
    }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        int selected = 0;
        string[] options = new string[ItemRegistry.Items.Count];
        int i = 0;
        foreach(AbstractInventoryItem item in ItemRegistry.Items) {
            options[i] = item.id;
            i++;
        }
        selected = EditorGUILayout.Popup("Item", item.intValue, options);
        if(ItemRegistry.Items.Count > 0) {
            item.intValue = selected;
            serializedObject.ApplyModifiedProperties();
        }
    }
}
