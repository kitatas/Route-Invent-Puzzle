using GameOff2023.InGame.Data.DataStore;
using GameOff2023.InGame.Data.Entity;
using GameOff2023.InGame.Domain.Repository;
using GameOff2023.InGame.Presentation.Presenter;
using GameOff2023.InGame.Presentation.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameOff2023.InGame.Installer
{
    public sealed class InGameInstaller : LifetimeScope
    {
        [SerializeField] private CellData cellData = default;
        [SerializeField] private PanelTable panelTable = default;

        protected override void Configure(IContainerBuilder builder)
        {
            // DataStore
            builder.RegisterInstance<CellData>(cellData);
            builder.RegisterInstance<PanelTable>(panelTable);

            // Entity
            builder.Register<LevelEntity>(Lifetime.Scoped);

            // Repository
            builder.Register<StageRepository>(Lifetime.Scoped);

            // Presenter
            builder.UseEntryPoints(Lifetime.Singleton, entryPoints =>
            {
                entryPoints.Add<ModalPresenter>();
                entryPoints.Add<SheetPresenter>();
            });

            // View
            builder.RegisterComponentInHierarchy<GoalView>();
            builder.RegisterComponentInHierarchy<PlayerView>();
            builder.RegisterComponentInHierarchy<ModalView>();
        }
    }
}