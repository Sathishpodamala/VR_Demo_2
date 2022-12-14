using Mono.Cecil;
using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[AttributeUsage(AttributeTargets.Method)]
public class DebugButtonAttribute:System.Attribute
{
    public string menuItemName;
    public DebugButtonAttribute(string name)
    {
        menuItemName = name;
    }

}


public static class ShowAll
{
    [MenuItem("ShowAll/Print")]
    public static void PrintAllMethods()
    {
        // Get an array of types containing all the classes in the current assembly
        Type[] types = Assembly.GetExecutingAssembly().GetTypes();

        // Loop through the array of types
        foreach (Type type in types)
        {
            // Get an array of MethodInfo objects containing all the methods
            // defined in the current class
            MethodInfo[] methods = type.GetMethods();

            // Loop through the array of MethodInfo objects
            foreach (MethodInfo method in methods)
            {
                // Check if the method has the custom attribute "CustomAttribute" applied to it
                if (method.IsDefined(typeof(DebugButtonAttribute), false))
                {
                    // The method has the custom attribute, so print its name
                    Debug.Log( $" {type.Name} , {method.Name}");
                }
            }
        }
    }
}