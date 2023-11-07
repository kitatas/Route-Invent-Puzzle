using GameOff2023.Common.Data.DataStore;
using GameOff2023.Common.Domain.Repository;
using GameOff2023.Common.Domain.UseCase;
using GameOff2023.Common.Presentation.Presenter;
using GameOff2023.Common.Presentation.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameOff2023.Common.Installer
{
    public sealed class CommonInstaller : LifetimeScope
    {
        [SerializeField] private BgmTable bgmTable = default;

        protected override void Configure(IContainerBuilder builder)
        {
            // DataStore
            builder.RegisterInstance<BgmTable>(bgmTable);

            // Repository
            builder.Register<SoundRepository>(Lifetime.Singleton);

            // UseCase
            builder.Register<SoundUseCase>(Lifetime.Singleton);

            // Presenter
            builder.UseEntryPoints(Lifetime.Singleton, entryPoints =>
            {
                entryPoints.Add<SoundPresenter>();
            });

            // View
            builder.RegisterInstance<SoundView>(FindObjectOfType<SoundView>());
        }
    }
}