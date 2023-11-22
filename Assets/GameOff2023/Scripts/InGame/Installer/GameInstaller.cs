using GameOff2023.InGame.Data.Entity;
using GameOff2023.InGame.Domain.UseCase;
using GameOff2023.InGame.Presentation.Controller;
using GameOff2023.InGame.Presentation.Presenter;
using GameOff2023.InGame.Presentation.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameOff2023.InGame.Installer
{
    public sealed class GameInstaller : LifetimeScope
    {
        [SerializeField] private EditCompButtonView editCompButtonView = default;
        [SerializeField] private ResetButtonView resetButtonView = default;
        [SerializeField] private GamePageView gamePageView = default;

        protected override void Configure(IContainerBuilder builder)
        {
            // Entity
            builder.Register<StageEntity>(Lifetime.Scoped);
            builder.Register<StateEntity>(Lifetime.Scoped);

            // UseCase
            builder.Register<StageUseCase>(Lifetime.Scoped);
            builder.Register<StateUseCase>(Lifetime.Scoped);

            // Controller
            builder.Register<StateController>(Lifetime.Scoped);
            builder.Register<BaseState, BackState>(Lifetime.Scoped);
            builder.Register<BaseState, ClearState>(Lifetime.Scoped);
            builder.Register<BaseState, EditState>(Lifetime.Scoped);
            builder.Register<BaseState, FailState>(Lifetime.Scoped);
            builder.Register<BaseState, MoveState>(Lifetime.Scoped);
            builder.Register<BaseState, SetUpState>(Lifetime.Scoped);

            // Presenter
            builder.UseEntryPoints(Lifetime.Transient, entryPoints =>
            {
                entryPoints.Add<GamePresenter>();
                entryPoints.Add<StatePresenter>();
            });

            // View
            builder.RegisterInstance<EditCompButtonView>(editCompButtonView);
            builder.RegisterInstance<ResetButtonView>(resetButtonView);
            builder.RegisterInstance<GamePageView>(gamePageView);
        }
    }
}