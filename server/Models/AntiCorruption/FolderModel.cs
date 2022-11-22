namespace server.Models;

public class FolderModel
{
    public string id { get; set; }
    public string nome { get; set; }
    public RepositoryModel Repositorio { get; set; }
}
