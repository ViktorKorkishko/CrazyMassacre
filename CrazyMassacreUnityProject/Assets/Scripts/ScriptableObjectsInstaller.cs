using Game.Scenes.Providers;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ScriptableObjectsInstaller", menuName = "Installers/ScriptableObjectsInstaller")]
public class ScriptableObjectsInstaller : ScriptableObjectInstaller<ScriptableObjectsInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<ScenesProvider>().AsSingle();
    }
}