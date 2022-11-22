using System.Collections.Generic;

namespace server.Models;

public class EnvelopeModel
{
    public string id { get; set; }
    public string descricao { get; set; }

    public RepositoryModel Repositorio { get; set; }

    public FolderModel Pasta { get; set; }

    public string mensagem { get; set; }

    public string mensagemObservadores { get; set; }

    public string mensagemNotificacaoSMS { get; set; }

    public string dataExpiracao { get; set; }

    public string horaExpiracao { get; set; }

    public string usarOrdem { get; set; }

    public ConfigAuxModel ConfigAuxiliar { get; set; }

    public List<DocumentModel> listaDocumentos { get; set; }

    public string incluirHashTodasPaginas { get; set; }

    public string permitirDespachos { get; set; }

    public string ignorarNotificacoes { get; set; }

    public string ignorarNotificacoesPendentes { get; set; }

    public string qrCodePosLeft { get; set; }

    public string qrCodePosTop { get; set; }

    public string dataIniContrato { get; set; }

    public string dataFimContrato { get; set; }

    public string objetoContrato { get; set; }

    public string numContrato { get; set; }

    public string valorContrato { get; set; }

    public string descricaoContratante { get; set; }

    public string descricaoContratado { get; set; }

}
