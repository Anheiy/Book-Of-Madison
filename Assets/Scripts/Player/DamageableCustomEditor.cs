using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Health))]
public class DamageableCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Damageable damageableScript = (Damageable)target;
        damageableScript.health = EditorGUILayout.IntField("Health", damageableScript.health);
        damageableScript.maxHealth = EditorGUILayout.IntField("Health", damageableScript.maxHealth);

        if(GUILayout.Button("Deal 1 Damage"))
        {
            damageableScript.ReduceHealth(1);
        }
        if (GUILayout.Button("Heal 1 Damage"))
        {
            damageableScript.IncreaseHealth(1);
        }
    }
    

}
