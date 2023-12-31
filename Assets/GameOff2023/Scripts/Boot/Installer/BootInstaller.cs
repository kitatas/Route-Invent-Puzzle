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
            builder.Register<AppVersionUseCase>(Lifetime.Scoped);
            builder.Register<LoginUseCase>(Lifetime.Scoped);
            builder.Register<StateUseCase>(Lifetime.Scoped);

            // Controller
            builder.Register<StateController>(Lifetime.Scoped);
            builder.Register<BaseState, CheckState>(Lifetime.Scoped);
            builder.Register<BaseState, LoadState>(Lifetime.Scoped);
            builder.Register<BaseState, LoginState>(Lifetime.Scoped);

            // Presenter
            builder.UseEntryPoints(Lifetime.Transient, entryPoints =>
            {
                entryPoints.Add<BootPresenter>();
            });
        }
    }
}