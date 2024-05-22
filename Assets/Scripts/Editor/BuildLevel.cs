using Codice.CM.Client.Differences;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuildLevel : EditorWindow, ICreateLevel
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

    public void CreateLevel()
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
                        try
                        {
                            GameObject temp = Instantiate(Resources.Load(levelTiles[i].ToString())) as GameObject;
                            Vector2Int pos = CalculatePosition(i, height, width);

                            string col = (pos.x).ToString();
                            if (pos.x < 10)
                                col = "0" + (pos.x).ToString();

                            string row = pos.y.ToString();
                            if (pos.y < 10)
                                row = "0" + pos.y.ToString();

                            temp.name = row + col;
                            temp.transform.localPosition = new Vector3(pos.x, pos.y, 0);

                            if (_world != null)
                                temp.transform.SetParent(_world.transform);
                        }
                        catch(Exception e) { Debug.LogError(e); }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    //insert to DLL
    private Vector2Int CalculatePosition(int index, int height, int width)
    {
        int colCalc = index % width;
        int rowCalc = (int)((height - 1) - ((int)(index / width)));
        return new Vector2Int(colCalc, rowCalc);
    }

}
