namespace server.Models;

public class RepositoryModel
{
    public string id { get; set; }
    public string nome { get; set; }
    public UserModel Usuario { get; set; }
    public string compartilharCriacaoDocs { get; set; }
    public string compartilharVisualizacaoDocs { get; set; }
    public string ocultarEmailSignatarios { get; set; }
    public string nomeRemetente { get; set; }
    public string opcaoValidCertICP { get; set; }
    public string opcaoValidDocFoto { get; set; }
    public string opcaoValidDocSelfie { get; set; }
    public string opcaoValidTokenSMS { get; set; }
    public string opcaoValidLogin { get; set; }
    public string opcaoValidReconhecFacial { get; set; }
    public string opcaoValidPix { get; set; }
    public string lembrarAssinPendentes { get; set; }
}