using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(DebugButtonAttribute))]
public class DebugButtonAttributeEditor : Editor
{
    // Override the OnInspectorGUI method to draw the context menu
    public override void OnInspectorGUI()
    {
        // Draw the default inspector
       
        //base.OnInspectorGUI();

        // Get the MonoBehaviour instance
        var example = target as MonoBehaviour;

        // Get the Type object for the MonoBehaviour
        Type type = example.GetType();

        // Get all of the methods marked with the custom attribute
        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        foreach (MethodInfo method in methods)
        {
            object[] attributes = method.GetCustomAttributes(typeof(DebugButtonAttribute), false);
            if (attributes.Length > 0)
            {
                // Create a button for each method marked with the custom attribute
                if (GUILayout.Button(((DebugButtonAttribute)attributes[0]).menuItemName))
                {
                    // Invoke the method when the button is clicked
                    method.Invoke(example, null);
                }
            }
        }
    }
}
