namespace server.Models
{
    public class CreateRepositoryDeserialize
    {
        public CreateRepositoryDeserializeResponse response { get; set; }   
    }
    public class CreateRepositoryDeserializeResponse{
        public string mensagem { get; set; }
        public CreateRepositoryDeserializeResponseData data { get; set; }

    }
    public class CreateRepositoryDeserializeResponseData{
        public string idRepositorio { get; set; }
        public CreateRepositoryDeserializeResponseDataListaAvisos listaAvisos { get; set; }
    }
     
    public class CreateRepositoryDeserializeResponseDataListaAvisos{
        public CreateRepositoryDeserializeResponseDataListaAvisosItem aviso { get; set; }

    }
    public class CreateRepositoryDeserializeResponseDataListaAvisosItem{
        public string tipo { get; set; }
        public string mensagem { get; set; }
    }
}