using UnityEngine;
using Zenject;

namespace AI
{
    public class Installer: MonoInstaller
    {
        [SerializeField] private GroupAI groupAI;

        public override void InstallBindings()
        {
            Container.BindInstance(groupAI).AsSingle();
        }
    }
}