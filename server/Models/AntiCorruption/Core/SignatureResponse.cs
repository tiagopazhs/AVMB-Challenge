namespace server.Models.AntiCorruption.Core
{
    public class SignatureResponse
    {
        public BaseResponse response { get; set; }   
    }
    public class BaseResponse{
        public string mensagem { get; set; } 

    }
    public class SignatureResponseData{
        public SignatureResponseListaAvisos listaAvisos { get; set; }
    }
     
    public class SignatureResponseListaAvisos{
        public SignatureResponseAviso aviso { get; set; }

    }
    public class SignatureResponseAviso{
        public string tipo { get; set; }
        public string mensagem { get; set; }
    }
}