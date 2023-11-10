using GameOff2023.InGame.Presentation.Presenter;
using GameOff2023.InGame.Presentation.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameOff2023.InGame.Installer
{
    public sealed class OptionInstaller : LifetimeScope
    {
        [SerializeField] private OptionModalView optionModalView = default;
        [SerializeField] private VolumeView volumeView = default;

        protected override void Configure(IContainerBuilder builder)
        {
            // Presenter
            builder.UseEntryPoints(Lifetime.Transient, entryPoints =>
            {
                entryPoints.Add<OptionPresenter>();
            });

            // View
            builder.RegisterInstance<OptionModalView>(optionModalView);
            builder.RegisterInstance<VolumeView>(volumeView);
        }
    }
}