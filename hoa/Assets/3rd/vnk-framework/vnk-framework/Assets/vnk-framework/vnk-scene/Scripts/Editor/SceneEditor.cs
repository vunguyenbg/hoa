
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using GoogleSheetsToUnity.ThirdPary;
using UnityEditor;
using UnityEngine;

namespace Yoolax.Framework
{
    public class SceneEditor : EditorWindow
    {
        [MenuItem("Tools/Scene Editor")]
        public static void OpenWindow()
        {
            EditorWindow window = EditorWindow.GetWindow(typeof(SceneEditor));
            window.minSize = new Vector2(320, 320);
            window.maxSize = new Vector2(320, 640);
        }

        Dictionary<string, SceneAsset> _assets = new Dictionary<string, SceneAsset>();

        private void OnEnable()
        {
            foreach (var asset in GetListAssets())
            {
                if (!_assets.ContainsKey(asset.name))
                {
                    _assets.Add(asset.name, asset);
                }
            }
        }

        float progressValue = 0;
        Vector2 scroll = Vector2.zero;
        EditorCoroutine editorCoroutine;

        void OnGUI()
        {
            scroll = EditorGUILayout.BeginScrollView(scroll);
            HorizontalLine();
            foreach (var asset in _assets)
            {
                RenderTable(asset.Value);
            }

            HorizontalLine();
            EditorGUILayout.EndScrollView();
            HorizontalLine();
            HorizontalLine();
            HorizontalLine();
        }

        private void HorizontalLine()
        {
            GUIStyle horizontalLine;
            horizontalLine = new GUIStyle();
            horizontalLine.normal.background = EditorGUIUtility.whiteTexture;
            horizontalLine.margin = new RectOffset(4, 4, 4, 4);
            horizontalLine.fixedHeight = 1;

            var c = GUI.color;
            GUI.color = Color.grey;
            GUILayout.Box(GUIContent.none, horizontalLine);
            GUI.color = c;
        }

        private void RenderTable(SceneAsset database)
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Ping", GUILayout.Height(15), GUILayout.Width(40)))
            {
                Selection.activeObject = database;

            }
            //if (GUILayout.Button("Select", GUILayout.Height(15), GUILayout.Width(40)))
            //{
            //    Selection. = database;

            //}

            EditorGUILayout.LabelField(database.name, GUILayout.MaxWidth(position.width / 3));
            EditorGUILayout.ObjectField(database, typeof(SceneAsset), false);

            EditorGUILayout.EndHorizontal();
        }

        private List<SceneAsset> GetListAssets()
        {
            var results = new List<SceneAsset>();
            foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            {
                var asset = UnityEditor.AssetDatabase.LoadAssetAtPath<SceneAsset>(scene.path);
                results.Add(asset);
            }

            return results;
        }
    }
}