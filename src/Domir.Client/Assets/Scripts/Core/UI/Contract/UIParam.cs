namespace Domir.Client.Core.UI.Contract
{
    public record UIParam
    {
        public static UIParam Empty => new();
    }

    public record PopupUIParam(
        string TitleText,
        string ContentText,
        string ConfirmButtonText,
        string CancelButtonText,
        bool UseTwoButton) : UIParam;
}