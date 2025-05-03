namespace Domir.Client.Common.UI.Core.Contract
{
    public record UIParam;

    public record PopupUIParam(
        string TitleText,
        string ContentText,
        string ConfirmButtonText,
        string CancelButtonText,
        bool UseTwoButton) : UIParam;
}