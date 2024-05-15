using Codice.CM.Client.Differences;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class PrefabSpawnerWindow : EditorWindow
{
    private static bool isSpawningEnabled = false;
    private int selectedIndex = 0;
    private GUIStyle labelStyle;

    private static Dictionary<string, GameObject> prefabDictionary;
    private string[] dropdownOptions = new string[]
    {
        "Prefab_FireFlower",
        "Prefab_Star",
        "Prefab_Mario",
        "Prefab_Floor",
        "Prefab_Coin",
        "Prefab_Spikes",
        "Prefab_Key"
    };

    private void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI;
        labelStyle = new GUIStyle();
        labelStyle.normal.textColor = Color.white;

        if (prefabDictionary == null || prefabDictionary.Count == 0)
            LoadPrefabs();
    }

    private void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
    }

    [MenuItem("Tools/Prefab Spawner")]
    public static void ShowWindow()
    {
        var window = GetWindow<PrefabSpawnerWindow>();
        window.titleContent = new GUIContent("Prefab Spawner");
        window.Show();
    }

    private void OnGUI()
    {
        EditorGUILayout.Space();
        selectedIndex = EditorGUILayout.Popup("Select Option",selectedIndex, dropdownOptions);
        EditorGUILayout.Space();

        if (GUILayout.Button("Toggle Prefab Spawning"))
            TogglePrefabSpawning();
        GUILayout.Label("Prefab Spawning Status: " + 
            (isSpawningEnabled ? "<color=yellow>Enabled</color>" : "<color=yellow>Disabled</color>"), labelStyle);
    }


    private void OnSceneGUI(SceneView sceneView)
    {
        if (isSpawningEnabled && prefabDictionary != null
            && prefabDictionary.ContainsKey(dropdownOptions[selectedIndex]))
        {
            Event current = Event.current;
            if (current.type == EventType.MouseDown && current.button == 1)
            {
                Vector2 mousePosition = Event.current.mousePosition;
                Ray ray = HandleUtility.GUIPointToWorldRay(mousePosition);
                Vector3 mouseWorldPos = ray.origin;
                Vector3 mouseWorldPosRounded = new Vector3(Mathf.RoundToInt(mouseWorldPos.x), Mathf.RoundToInt(mouseWorldPos.y), 0);
                Instantiate(prefabDictionary[dropdownOptions[selectedIndex]],
                   mouseWorldPosRounded, Quaternion.identity);
                Debug.Log("Mouse Position in Scene: " + mouseWorldPosRounded);
            }
        }
    }

    private void TogglePrefabSpawning()
    {
        isSpawningEnabled = !isSpawningEnabled;
    }
    private void LoadPrefabs()
    {
        prefabDictionary = new Dictionary<string, GameObject>();
        foreach (string n in dropdownOptions)
            prefabDictionary.Add(n,Resources.Load<GameObject>(n));

        Debug.Log(prefabDictionary.Count);
    }

}
