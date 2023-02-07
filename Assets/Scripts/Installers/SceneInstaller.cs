using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject pistolPrefab;
    [SerializeField] private Transform position;
    public override void InstallBindings()
    {
        
        PlayerData player = Container.InstantiatePrefabForComponent<PlayerData>(playerPrefab, position.position,Quaternion.identity, null);
        Container.Bind<PlayerData>().FromInstance(player).AsSingle();
        var pistol = Container.InstantiatePrefab(pistolPrefab, position);
    }
}