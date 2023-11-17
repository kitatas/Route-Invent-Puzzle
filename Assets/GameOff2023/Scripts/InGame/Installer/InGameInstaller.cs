using GameOff2023.InGame.Data.DataStore;
using GameOff2023.InGame.Data.Entity;
using GameOff2023.InGame.Domain.Repository;
using GameOff2023.InGame.Domain.UseCase;
using GameOff2023.InGame.Presentation.Controller;
using GameOff2023.InGame.Presentation.Presenter;
using GameOff2023.InGame.Presentation.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameOff2023.InGame.Installer
{
    public sealed class InGameInstaller : LifetimeScope
    {
        [SerializeField] private Transform stage = default;

        [SerializeField] private CellData cellData = default;
        [SerializeField] private PanelTable panelTable = default;

        protected override void Configure(IContainerBuilder builder)
        {
            // DataStore
            builder.RegisterInstance<CellData>(cellData);
            builder.RegisterInstance<PanelTable>(panelTable);

            // Entity
            builder.Register<StageEntity>(Lifetime.Scoped);
            builder.Register<StateEntity>(Lifetime.Scoped);

            // Repository
            builder.Register<StageRepository>(Lifetime.Scoped);

            // UseCase
            builder.Register<StageUseCase>(Lifetime.Scoped).WithParameter(stage);
            builder.Register<StateUseCase>(Lifetime.Scoped);

            // Controller
            builder.Register<StateController>(Lifetime.Scoped);
            builder.Register<BaseState, EditState>(Lifetime.Scoped);
            builder.Register<BaseState, MoveState>(Lifetime.Scoped);
            builder.Register<BaseState, SetUpState>(Lifetime.Scoped);

            // Presenter
            builder.UseEntryPoints(Lifetime.Singleton, entryPoints =>
            {
                entryPoints.Add<ModalPresenter>();
                entryPoints.Add<StatePresenter>();
            });

            // View
            builder.RegisterComponentInHierarchy<EditCompButtonView>();
            builder.RegisterComponentInHierarchy<GoalView>();
            builder.RegisterComponentInHierarchy<PlayerView>();
            builder.RegisterComponentInHierarchy<TopView>();
        }
    }
}