using SistemaCorporativo.Aplicacao.DTOs;
using System;
using System.Collections.Generic;

namespace SistemaCorporativo.Aplicacao.Interfaces
{
    public interface IFuncionarioService
    {
        FuncionarioRespostaDto Criar(FuncionarioCriarDto dto);
        IEnumerable<FuncionarioRespostaDto> Listar();
        FuncionarioRespostaDto ObterPorId(Guid id);
        void Atualizar(FuncionarioRespostaDto dto);
        void Deletar(Guid id);
    }
}
