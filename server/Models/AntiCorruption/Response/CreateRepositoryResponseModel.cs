using server.Models.AntiCorruption.Core;

namespace server.Models.AntiCorruption
{
    public class CreateRepositoryResponseModel
    {
        public CreateRepositoryResponse response { get; set; }
    }
    public class CreateRepositoryResponse : BaseResponse
    {
        public CreateRepositoryResponseData data { get; set; }

    }
    public class CreateRepositoryResponseData : SignatureResponseData
    {
        public string idRepositorio { get; set; }
    }
}