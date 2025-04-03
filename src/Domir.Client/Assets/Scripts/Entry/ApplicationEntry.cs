using Domir.Client.SceneManagement;
using Domir.Client.Service;
using VContainer.Unity;

namespace Domir.Client.Entry
{
    public class ApplicationEntry : IStartable
    {
        private readonly NetworkService _networkService;
        private readonly SceneLoader _sceneLoader;

        public ApplicationEntry(NetworkService networkService, SceneLoader sceneLoader)
        {
            _networkService = networkService;
            _sceneLoader = sceneLoader;
        }

        public void Start()
        {
            _networkService.Connect();
            _sceneLoader.LoadAsync("Lobby");
        }
    }
}