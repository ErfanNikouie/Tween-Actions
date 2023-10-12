using UnityEditor;

namespace Mosaic.Base.TweenActions
{
    [CustomEditor(typeof(TweenAction)), CanEditMultipleObjects]
    public class TweenActionEditor : Editor
    {   
        public SerializedObject action;
        public SerializedProperty actionTProp, transformActionTProp, colorActionTProp;
        public SerializedProperty setAtProp, localProp, vector3Prop, multiplyProp, fValueAtProp, fValueAddProp, multiplierProp;
        public SerializedProperty v2ValueAtProp, v3ValueAtProp, v2ValueAddProp, v3ValueAddProp;
        public SerializedProperty cValueAtProp;
        public SerializedProperty durationProp, easeProp, customEaseProp, easeCurveProp;

        void OnEnable() 
        {
            action = serializedObject;
            actionTProp = action.FindProperty("actionType");
            transformActionTProp = action.FindProperty("transformActionType");
            colorActionTProp = action.FindProperty("colorActionType");

            setAtProp = action.FindProperty("setAt");
            localProp = action.FindProperty("local");
            multiplyProp = action.FindProperty("multiply");
            vector3Prop = action.FindProperty("vector3");
            fValueAtProp = action.FindProperty("fValueAt");
            fValueAddProp = action.FindProperty("fValueAdd");
            multiplierProp = action.FindProperty("multiplier");

            v2ValueAtProp = action.FindProperty("v2ValueAt");
            v3ValueAtProp = action.FindProperty("v3ValueAt");
            v2ValueAddProp = action.FindProperty("v2ValueAdd");
            v3ValueAddProp = action.FindProperty("v3ValueAdd");

            cValueAtProp = action.FindProperty("cValueAt");

            durationProp = action.FindProperty("duration");
            easeProp = action.FindProperty("ease");
            customEaseProp = action.FindProperty("customEase");
            easeCurveProp = action.FindProperty("easeCurve");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(actionTProp);

            ActionType state = (ActionType)actionTProp.enumValueIndex;

            switch(state)
            {
                case ActionType.Transform:
                    DrawTransform();
                    break;
                    
                case ActionType.RectTransform:
                    DrawTransform();
                    break;

                case ActionType.Color:
                    DrawColor();
                    break;
            }

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
                        EditorGUILayout.PropertyField(vector3Prop);
                        if(vector3Prop.boolValue)
                            EditorGUILayout.PropertyField(v3ValueAtProp);
                        else
                            EditorGUILayout.PropertyField(v2ValueAtProp);
                        break;
                    }
                    EditorGUILayout.PropertyField(multiplyProp);
                    if(multiplyProp.boolValue)
                        EditorGUILayout.PropertyField(multiplierProp);
                    else
                    {
                        EditorGUILayout.PropertyField(vector3Prop);
                        if(vector3Prop.boolValue)
                            EditorGUILayout.PropertyField(v3ValueAddProp);
                        else    
                            EditorGUILayout.PropertyField(v2ValueAddProp);
                    }
                    break;

                default:
                    EditorGUILayout.PropertyField(localProp);
                    EditorGUILayout.PropertyField(vector3Prop);
                    if(setAtProp.boolValue)
                    {
                        if(vector3Prop.boolValue)
                            EditorGUILayout.PropertyField(v3ValueAtProp);
                        else
                            EditorGUILayout.PropertyField(v2ValueAtProp);
                        break;
                    }
                    if(vector3Prop.boolValue)
                        EditorGUILayout.PropertyField(v3ValueAddProp);
                    else
                        EditorGUILayout.PropertyField(v2ValueAddProp);
                    break;
            }
        }

        void DrawColor()
        {
            EditorGUILayout.PropertyField(colorActionTProp);
            EditorGUILayout.PropertyField(cValueAtProp);
        }
    }
}