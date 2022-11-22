namespace server.Models;

public class CreateEnvelopeModel
{
    public string UserId { get; set; }
    public string RepositoryName { get; set; }
    public string FolderName { get; set; }
    public string Descricao { get; set; }
    public List<DocumentEventopeModel> Documento { get; set; }
}

public class DocumentEventopeModel
{
    public string NomeArquivo { get; set; }
    public string MimeType { get; set; }
    public string Conteudo { get; set; }
}