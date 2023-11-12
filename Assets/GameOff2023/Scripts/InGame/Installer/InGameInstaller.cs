using GameOff2023.InGame.Domain.UseCase;
using GameOff2023.InGame.Presentation.Controller;
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
            // UseCase
            builder.Register<StateUseCase>(Lifetime.Scoped);

            // Controller
            builder.Register<StateController>(Lifetime.Scoped);
            builder.Register<BaseState, EditState>(Lifetime.Scoped);

            // Presenter
            builder.UseEntryPoints(Lifetime.Singleton, entryPoints =>
            {
                entryPoints.Add<ModalPresenter>();
                entryPoints.Add<StatePresenter>();
            });

            // View
            builder.RegisterComponentInHierarchy<EditCompButtonView>();
            builder.RegisterComponentInHierarchy<TopView>();
        }
    }
}