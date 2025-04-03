using MessagePack;

namespace Domir.Shared.Response
{
    [MessagePackObject]
    public class LoginResponse : IResponse
    {
        [Key(0)]
        public ushort ResponseCode { get; set; }
        
        [Key(1)]
        public int TEST { get; set; }
        
        [Key(2)]
        public string TESTTTTTTT { get; set; }
    }
}