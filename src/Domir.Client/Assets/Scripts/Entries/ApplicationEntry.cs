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

        public ApplicationEntry(SceneLoader sceneLoader, NetworkService networkService, InputService inputService)
        {
            _networkService = networkService;
            _inputService = inputService;
            _sceneLoader = sceneLoader;
        }

        public void Start()
        {
            _networkService.Connect();
            _sceneLoader.LoadAsync("Lobby");
        }
    }
}