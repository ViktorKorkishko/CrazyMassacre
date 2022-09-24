using UnityEngine;
using Core.Providers;
using Game.Scenes.Enums;
using System;

using Object = UnityEngine.Object;

namespace Game.Scenes.Providers
{
    [Serializable]
    public class ProvidedScene
    {
        [SerializeField] private Object _scene;
        public string SceneName => _scene.name;
    }

    [CreateAssetMenu(fileName = "SO_Providers_scenes", menuName = "Providers/Scenes", order = 0)]
    public class ScenesProvider : EnumSafeProviderScriptable<SceneID, ProvidedScene>
    {   
        [EnumNamedArray(typeof(SceneID))]
        [SerializeField] private ProvidedScene[] _data;
        protected override ProvidedScene[] Data => _data;
    }
}
