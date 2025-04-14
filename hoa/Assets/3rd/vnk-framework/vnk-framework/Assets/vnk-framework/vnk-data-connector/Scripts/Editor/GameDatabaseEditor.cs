using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using GoogleSheetsToUnity.ThirdPary;
using UnityEditor;
using UnityEngine;

namespace Yoolax.Framework
{
    public class GameDatabaseEditor : EditorWindow
    {
        [MenuItem("Tools/Game Database Editor")]
        public static void OpenWindow()
        {
            EditorWindow window = EditorWindow.GetWindow(typeof(GameDatabaseEditor));
            window.minSize = new Vector2(320, 320);
            window.maxSize = new Vector2(320, 640);
        }

        Dictionary<string, DB_Base> _assets = new Dictionary<string, DB_Base>();

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
            RenderPullAll();
            HorizontalLine();
            CheckDatabasse();
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

        private void CheckDatabasse()
        {
            EditorGUILayout.BeginVertical();
            if (GUILayout.Button("Check Database"))
            {
                foreach (var asset in _assets)
                {
                    if (!asset.Value.CheckDatabase())
                    {
                        ShowNotification(new GUIContent(asset.Key + " -ERROR!!!"), 3.0);
                        return;
                    }
                }

                ShowNotification(new GUIContent("OK!!!"), 1.0);
            }

            EditorGUILayout.EndVertical();
        }

        private void RenderPullAll()
        {
            EditorGUILayout.BeginVertical();
            if (GUILayout.Button("Pull All"))
            {
                editorCoroutine = EditorCoroutineRunner.StartCoroutineWithUI(PullAll(), "Waiting...", true);
            }

            EditorGUILayout.EndVertical();
        }

        private void RenderTable(DB_Base database)
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Ping", GUILayout.Height(15), GUILayout.Width(40)))
            {
                Selection.activeObject = database;
            }

            if (GUILayout.Button("Pull", GUILayout.Height(15), GUILayout.Width(50)))
            {
                if (database == null)
                {
                    ShowNotification(new GUIContent("Database is null"));
                    return;
                }

                editorCoroutine = EditorCoroutineRunner.StartCoroutineWithUI(Pull(database), "Waiting...", true);
            }

            EditorGUILayout.LabelField(database.name, GUILayout.MaxWidth(position.width / 3));
            EditorGUILayout.ObjectField(database, typeof(DB_Base), false);

            EditorGUILayout.EndHorizontal();
        }

        private IEnumerator Pull(DB_Base database)
        {
            EditorCoroutine routine = null;
            try
            {
                routine = EditorCoroutineRunner.StartCoroutine(database.PullDatabase());
            }
            catch (System.Exception)
            {
                EditorCoroutineRunner.KillCoroutine(ref routine);
                EditorCoroutineRunner.KillCoroutine(ref editorCoroutine);
            }

            yield return routine;
            EditorCoroutineRunner.UpdateUIProgressBar(1);
            EditorUtility.SetDirty(database);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            ShowNotification(new GUIContent("Pull Success " + database.name), 1.0);
        }

        private IEnumerator PullAll()
        {
            progressValue = 0;
            for (int i = 0; i < _assets.Count; i++)
            {
                EditorCoroutine routine = null;
                try
                {
                    EditorCoroutineRunner.UpdateUILabel(_assets.ElementAt(i).Key);
                    routine = EditorCoroutineRunner.StartCoroutine(_assets.ElementAt(i).Value.PullDatabase());
                }
                catch (System.Exception)
                {
                    EditorCoroutineRunner.KillCoroutine(ref routine);
                    EditorCoroutineRunner.KillCoroutine(ref editorCoroutine);
                }

                yield return routine;
                progressValue = (float)(i + 1) / (float)_assets.Count;
                EditorCoroutineRunner.UpdateUIProgressBar(progressValue);
                EditorUtility.SetDirty(_assets.ElementAt(i).Value);
            }

            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
            ShowNotification(new GUIContent("Success"), 3.0);
        }

        private List<DB_Base> GetListAssets()
        {
            var results = new List<DB_Base>();
            var paths = UnityEditor.AssetDatabase.FindAssets("t:DB_Base");
            foreach (var path in paths)
            {
                var guid = UnityEditor.AssetDatabase.GUIDToAssetPath(path);
                var asset = UnityEditor.AssetDatabase.LoadAssetAtPath<DB_Base>(guid);
                results.Add(asset);
            }

            return results;
        }
    }
}