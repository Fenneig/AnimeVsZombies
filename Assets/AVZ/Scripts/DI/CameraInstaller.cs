using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace AVZ.DI
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private CinemachineCamera _cinemachineCamera;

        public override void InstallBindings() => 
            Container.Bind<CinemachineCamera>().FromInstance(_cinemachineCamera).AsSingle();
    }
}
