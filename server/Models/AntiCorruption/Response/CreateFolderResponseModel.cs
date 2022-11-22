using server.Models.AntiCorruption.Core;

namespace server.Models.AntiCorruption
{
    public class CreateFolderResponseModel
    {
        public CreateFolderResponseResponse response { get; set; }
    }
    public class CreateFolderResponseResponse : BaseResponse
    {
        public CreateFolderResponseResponseData data { get; set; }

    }
    public class CreateFolderResponseResponseData : SignatureResponseData
    {
        public string idPasta { get; set; }
    }
}