namespace SistemaCorporativo.Aplicacao.DTOs;

public class FuncionarioRespostaDto
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public decimal Salario { get; set; }

    // Dados do cargo “achatados” para resposta
    public Guid CargoId { get; set; }
    public string CargoNome { get; set; } = string.Empty;

    public bool Ativo { get; set; }
    public DateTime DataAdmissao { get; set; }
}
