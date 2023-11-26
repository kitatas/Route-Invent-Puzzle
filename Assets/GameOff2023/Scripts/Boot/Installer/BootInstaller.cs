using GameOff2023.Boot.Domain.UseCase;
using GameOff2023.Boot.Presentation.Controller;
using GameOff2023.Boot.Presentation.Presenter;
using VContainer;
using VContainer.Unity;

namespace GameOff2023.Boot.Installer
{
    public sealed class BootInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // UseCase
            builder.Register<StateUseCase>(Lifetime.Scoped);

            // Controller
            builder.Register<StateController>(Lifetime.Scoped);

            // Presenter
            builder.UseEntryPoints(Lifetime.Transient, entryPoints =>
            {
                entryPoints.Add<BootPresenter>();
            });
        }
    }
}