using UnityEditor;

namespace Mosaic.Base.TweenActions.Editor
{
    [CustomEditor(typeof(ResponsiveTweenAction)), CanEditMultipleObjects]
    public class ResponsiveTweenActionEditor : UnityEditor.Editor
	{   
        public SerializedObject action;
        public SerializedProperty transformActionTProp;
        public SerializedProperty setAtProp, localProp, multiplyProp, multiplierProp;
        public SerializedProperty v2ValueAtProp, v2ValueAddProp;
        public SerializedProperty durationProp, easeProp, customEaseProp, easeCurveProp;

        void OnEnable() 
        {
            action = serializedObject;
            transformActionTProp = action.FindProperty("transformActionType");

            setAtProp = action.FindProperty("setAt");
            localProp = action.FindProperty("local");
            multiplyProp = action.FindProperty("multiply");
            multiplierProp = action.FindProperty("multiplier");

            v2ValueAtProp = action.FindProperty("v2ValueAt");
            v2ValueAddProp = action.FindProperty("v2ValueAdd");

            durationProp = action.FindProperty("duration");
            easeProp = action.FindProperty("ease");
            customEaseProp = action.FindProperty("customEase");
            easeCurveProp = action.FindProperty("easeCurve");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
			DrawTransform();

			EditorGUILayout.PropertyField(durationProp);

            EditorGUILayout.PropertyField(customEaseProp);
            if(!customEaseProp.boolValue)
                EditorGUILayout.PropertyField(easeProp);
            else
                EditorGUILayout.PropertyField(easeCurveProp);

            serializedObject.ApplyModifiedProperties();
        }

        void DrawTransform()
        {
            EditorGUILayout.PropertyField(transformActionTProp);
            EditorGUILayout.PropertyField(setAtProp);

            TransformActionType state = (TransformActionType)transformActionTProp.enumValueIndex;
            switch(state)
            {    
                case TransformActionType.Scale:
                    if(setAtProp.boolValue)
                    {
                        EditorGUILayout.PropertyField(v2ValueAtProp);
                        break;
                    }

                    EditorGUILayout.PropertyField(multiplyProp);

                    if(multiplyProp.boolValue)
                        EditorGUILayout.PropertyField(multiplierProp);
                    else
                        EditorGUILayout.PropertyField(v2ValueAddProp);

                    break;

                default:
                    EditorGUILayout.PropertyField(localProp);

                    if(setAtProp.boolValue)
                    {
                        EditorGUILayout.PropertyField(v2ValueAtProp);
                        break;
                    }

                    EditorGUILayout.PropertyField(v2ValueAddProp);
                    break;
            }
        }
    }
}