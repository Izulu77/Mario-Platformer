using Codice.CM.Client.Differences;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuildLevel : EditorWindow
{
    private TextAsset _curLevel;
    private GameObject _world;

    [MenuItem("Tools/Level Creator")]
    public static void ShowWindow()
    {
        GetWindow<BuildLevel>("Level Creator");
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Assign Level File:");
        _curLevel = EditorGUILayout.ObjectField(_curLevel,typeof(TextAsset),false) as TextAsset;

        EditorGUILayout.LabelField("Assign Parent Transform:");
        _world = EditorGUILayout.ObjectField(_world, typeof(GameObject), true) as GameObject;

        if (GUILayout.Button("Create Level") && _curLevel != null)
        {
            CreateLevel();
        }
    }

    //try to replace with reflections
    private void CreateLevel()
    {
        Debug.Log("Starting to create a level from file: " + _curLevel.name);
        try 
        {
            string jsonData = _curLevel.text;
            Dictionary<string, object> gameData = MiniJSON.Json.Deserialize(jsonData) as Dictionary<string, object>;
            int height = int.Parse(gameData["height"].ToString());
            int width = int.Parse(gameData["width"].ToString());
            Debug.Log("Level: " + width + "x" + height);

            List<object> layers = (List<object>)gameData["layers"];
            foreach(object obj in layers)
            {
                Dictionary<string, object> layerData = obj as Dictionary<string, object>;
                if (layerData.ContainsKey("data"))
                {
                    List<object> levelTiles = (List<object>)layerData["data"];
                    for(int i = 0; i < levelTiles.Count;i++)
                    {
                        switch(levelTiles[i].ToString())
                        {
                            case "1": CreateGameObject("Prefab_FireFlower", i, height, width); break;
                            case "2": CreateGameObject("Prefab_Star", i, height, width); break;
                            case "3": CreateGameObject("Prefab_Mario", i, height, width); break;
                            case "4": CreateGameObject("Prefab_Floor", i, height, width); break;
                            case "5": CreateGameObject("Prefab_Coin", i, height, width); break;
                            case "6": CreateGameObject("Prefab_Spikes", i, height, width); break;
                            case "7": CreateGameObject("Prefab_Key", i, height, width); break;
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void CreateGameObject(string prefabName,int index,int height, int width)
    {
        GameObject temp = Instantiate(Resources.Load(prefabName)) as GameObject;
        int colCalc = index % width;
        string col = (colCalc).ToString();
        if (colCalc < 10)
            col = "0" + (colCalc).ToString();

        int rowCalc = (int)((height - 1) - ((int)(index / width)));
        string row = rowCalc.ToString();
        if (rowCalc < 10)
            row = "0" + rowCalc.ToString();

        temp.name = row + col;
        temp.transform.localPosition = new Vector3(colCalc, rowCalc, 0);

        if (_world != null)
            temp.transform.SetParent(_world.transform);
    }
}
