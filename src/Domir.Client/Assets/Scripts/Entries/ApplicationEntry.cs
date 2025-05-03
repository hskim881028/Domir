using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Core.Contract;
using Domir.Client.Common.UI.Core.Presenter;
using Domir.Client.Common.UI.Implementation.Presenter;
using Domir.Client.Contents.UI.Generated;
using Domir.Client.SceneManagement;
using Domir.Client.Services;
using VContainer.Unity;

namespace Domir.Client.Entries
{
    public class ApplicationEntry : IStartable
    {
        private readonly SceneLoader _sceneLoader;
        private readonly NetworkService _networkService;
        private readonly InputService _inputService;
        private readonly IUINavigation _navigation;

        public ApplicationEntry(
            SceneLoader sceneLoader,
            NetworkService networkService,
            InputService inputService,
            IUINavigation navigation)
        {
            _networkService = networkService;
            _inputService = inputService;
            _navigation = navigation;
            _sceneLoader = sceneLoader;
        }

        public void Start()
        {
            // _networkService.Connect();
            // _sceneLoader.LoadAsync("Lobby");
            _navigation.ShowAsync(SystemUIId.Popup, new PopupUIParam("t", "test", "ok", "no", true));
        }
    }
}