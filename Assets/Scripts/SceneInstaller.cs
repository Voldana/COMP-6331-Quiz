using AI;
using UI;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private EndPanel endPanel;

    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<GameEvents.OnEntityDestroy>();
        Container.DeclareSignal<GameEvents.OnGameOver>();
        Container.BindFactory<GroupAI.Type, EndPanel, EndPanel.Factory>().FromComponentInNewPrefab(endPanel).AsSingle();
    }
}