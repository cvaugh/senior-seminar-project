using UnityEditor;

[CustomEditor(typeof(DroppedItem))]
public class DroppedItemEditor : Editor {
    SerializedProperty item;

    private void OnEnable() {
        item = serializedObject.FindProperty("itemIndex");
    }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        string[] options = new string[ItemRegistry.Items.Count];
        int i = 0;
        foreach(AbstractInventoryItem item in ItemRegistry.Items) {
            options[i] = item.id;
            i++;
        }
        int selected = EditorGUILayout.Popup("Item", item.intValue, options);
        if(ItemRegistry.Items.Count > 0) {
            item.intValue = selected;
            serializedObject.ApplyModifiedProperties();
        }
    }
}
