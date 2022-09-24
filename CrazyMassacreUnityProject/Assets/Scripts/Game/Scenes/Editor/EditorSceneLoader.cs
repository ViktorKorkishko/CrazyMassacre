using System.IO;
using System.Linq;
using Game.Scenes.Enums;
using Game.Scenes.Providers;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Game.Scenes.Editor
{
    public static class EditorSceneLoader
    {
        private static ScenesProvider ScenesProvider => AssetDatabase.LoadAssetAtPath<ScenesProvider>(_scenesProviderPath);
        private const string _scenesProviderPath = "Assets/ScriptableObjects/Providers/SO_Providers_scenes.asset";
        private const string _unitySceneExtension = ".unity";
        private static string[] _allSceneFiles = Directory.GetFiles(Application.dataPath, $"*{_unitySceneExtension}", SearchOption.AllDirectories);

        private static void LoadScene(SceneID sceneID)
        {
            var fullScenePath = GetFullScenePath(sceneID);
            EditorSceneManager.OpenScene(fullScenePath);

            static string GetFullScenePath(SceneID sceneID)
            {
                var sceneName = ScenesProvider[sceneID].SceneName;
                var sceneFile = _allSceneFiles.First(x => x.EndsWith(sceneName + _unitySceneExtension));

                return sceneFile;
            }
        }

        [MenuItem("SceneLoader/Lobby")]
        private static void LoadLobbyScene() => LoadScene(SceneID.Lobby);

        [MenuItem("SceneLoader/Game")]
        private static void LoadGameScene() => LoadScene(SceneID.Game);
    }
}