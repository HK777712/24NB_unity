using UnityEngine;
using System.Collections;
using UnityEditor;
 
 
[CustomPropertyDrawer(typeof (NewDs4button))]
public class NewDs4Draw : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        float[] widthes = { position.width * 0.3f, position.width * 0.4f, position.width * 0.3f };
        //とりあえずlabelなしで半分にした入力フィールドをつくる
        position.width = widthes[0];
        EditorGUI.PropertyField(position, property.FindPropertyRelative("ds4button"), GUIContent.none);
 
        position.x += position.width;
        position.width = widthes[1];
        EditorGUI.PropertyField(position, property.FindPropertyRelative("button"), GUIContent.none);

        position.x += position.width;
        position.width = widthes[2];
        EditorGUI.PropertyField(position, property.FindPropertyRelative("panel"), GUIContent.none);
    }
}