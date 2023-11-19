using GameOff2023.InGame.Domain.UseCase;
using GameOff2023.InGame.Presentation.Presenter;
using GameOff2023.InGame.Presentation.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameOff2023.InGame.Installer
{
    public sealed class SelectInstaller : LifetimeScope
    {
        [SerializeField] private SelectSheetView selectSheetView = default;

        protected override void Configure(IContainerBuilder builder)
        {
            // UseCase
            builder.Register<SelectUseCase>(Lifetime.Scoped);

            // Presenter
            builder.UseEntryPoints(Lifetime.Transient, entryPoints =>
            {
                entryPoints.Add<SelectPresenter>();
            });

            // View
            builder.RegisterInstance<SelectSheetView>(selectSheetView);
        }
    }
}