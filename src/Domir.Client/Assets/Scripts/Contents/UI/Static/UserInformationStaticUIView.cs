using Domir.Client.Core.Infrastructure;
using Domir.Client.Core.UI.View;
using Domir.Client.Data.Model;
using TMPro;
using UnityEngine;

namespace Domir.Client.Contents.UI.Static
{
    public class UserInformationStaticUIView : StaticUIView<IUserInformationStaticUIMessage>
    {
        [SerializeField] private TMP_Text _text;

        public void Set(UserModel model)
        {
            this.Log();
            var type = model.IsHost ? " Host" : "Client";
            _text.text = $"ClientId : {model.ClientId} / {type}";
        }
    }
}