using server.Models.AntiCorruption.Core;

namespace server.Models.AntiCorruption
{
    public class CreateEnvelopeResponseModel
    {
        public CreateEnvelopeResponse response { get; set; }
    }
    public class CreateEnvelopeResponse : BaseResponse
    {
        public CreateEnvelopeResponseData data { get; set; }

    }
    public class CreateEnvelopeResponseData : SignatureResponseData
    {
        public string idEnvelope { get; set; }
        public string hashSHA256 { get; set; }
    }
}