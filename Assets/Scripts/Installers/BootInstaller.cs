using UnityEngine;
using Zenject;

public class BootInstaller : MonoInstaller
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform position;
    public override void InstallBindings()
    {
        
    }
}