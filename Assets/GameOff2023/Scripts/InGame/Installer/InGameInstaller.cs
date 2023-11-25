using GameOff2023.InGame.Data.Entity;
using GameOff2023.InGame.Domain.Repository;
using GameOff2023.InGame.Presentation.Presenter;
using GameOff2023.InGame.Presentation.View;
using VContainer;
using VContainer.Unity;

namespace GameOff2023.InGame.Installer
{
    public sealed class InGameInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // Entity
            builder.Register<LevelEntity>(Lifetime.Singleton);

            // Repository
            builder.Register<StageRepository>(Lifetime.Singleton);

            // Presenter
            builder.UseEntryPoints(Lifetime.Singleton, entryPoints =>
            {
                entryPoints.Add<ModalPresenter>();
                entryPoints.Add<PagePresenter>();
            });

            // View
            builder.RegisterComponentInHierarchy<ModalView>();
        }
    }
}