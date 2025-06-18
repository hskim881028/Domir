using System.Collections.Generic;
using Domir.Client.Core.UI;
using Domir.Client.Core.UI.Navigation;
using Domir.Client.Core.UI.Presenter;
using Domir.Client.Data.Repository;

namespace Domir.Client.Contents.UI.Static
{
    public class UserInformationStaticUIPresenter : StaticUIPresenter<UserInformationStaticUIView, IUserInformationStaticUIMessage>, IUserInformationStaticUIMessage
    {
        private readonly UserInformationStaticUIView _view;
        private readonly UserRepository _userRepository;
        protected override HashSet<UILayer> Layer => UILayer.SetDefault;
        public override UIPriority Priority => UIPriority.UserInformation;

        public UserInformationStaticUIPresenter(
            UserInformationStaticUIView view,
            IUINavigation navigation,
            UserRepository userRepository)
            : base(view, navigation)
        {
            _view = view;
            _userRepository = userRepository;
        }

        public override void OnShowEnter()
        {
            _view.Set(_userRepository.Get("test"));
            base.OnShowEnter();
        }
    }
}