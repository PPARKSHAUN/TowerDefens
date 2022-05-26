using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapManager))]
public class MapManagerBase : Editor
{
    MapManager _scp = null;
    SerializedProperty _mapSize;
    SerializedProperty _tileSource;
    private void OnEnable()
    {
        _scp = target as MapManager;
        _mapSize = serializedObject.FindProperty("MapSize");
        _tileSource = serializedObject.FindProperty("TileSource");
    }
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();        
        EditorGUILayout.PropertyField(_tileSource);
        EditorGUILayout.PropertyField(_mapSize);
        if(serializedObject.ApplyModifiedProperties())
        {
            _scp.CreateMap();
        }        
    }
}
