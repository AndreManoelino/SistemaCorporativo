using SistemaCorporativo.Aplicacao.DTOs;
using SistemaCorporativo.Aplicacao.Interfaces;
using SistemaCorporativo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaCorporativo.Aplicacao.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        // Simula um banco de dados em memória
        private readonly List<Funcionario> _funcionarios = new List<Funcionario>();
        private readonly List<Cargo> _cargos = new List<Cargo>();

        public FuncionarioService()
        {
            // Adiciona cargos de exemplo
            _cargos.Add(new Cargo("DEV", "Desenvolvedor"));
            _cargos.Add(new Cargo("ADM", "Administrador"));
        }

        public FuncionarioRespostaDto Criar(FuncionarioCriarDto dto)
        {
            var cargo = _cargos.FirstOrDefault(c => c.Id == dto.CargoId);
            if (cargo == null) throw new ArgumentException("Cargo inválido!");

            var funcionario = new Funcionario(dto.Nome, dto.Email, dto.Salario, cargo);
            _funcionarios.Add(funcionario);

            return MapToDto(funcionario);
        }

        public IEnumerable<FuncionarioRespostaDto> Listar()
        {
            return _funcionarios.Select(f => MapToDto(f));
        }

        public FuncionarioRespostaDto ObterPorId(Guid id)
        {
            var f = _funcionarios.FirstOrDefault(x => x.Id == id);
            return f == null ? null : MapToDto(f);
        }

        public void Atualizar(FuncionarioRespostaDto dto)
        {
            var f = _funcionarios.FirstOrDefault(x => x.Id == dto.Id);
            if (f == null) throw new ArgumentException("Funcionário não encontrado!");

            f.TrocarCargo(_cargos.First(c => c.Nome == dto.CargoNome));
            f.AtualizarSalario(dto.Salario);
        }

        public void Deletar(Guid id)
        {
            var f = _funcionarios.FirstOrDefault(x => x.Id == id);
            if (f != null)
                f.Desativar();
        }

        private FuncionarioRespostaDto MapToDto(Funcionario f)
        {
            return new FuncionarioRespostaDto
            {
                Id = f.Id,
                Nome = f.Nome,
                Email = f.Email,
                Salario = f.Salario,
                CargoNome = f.cargo.Nome,
                Ativo = f.Ativo
            };
        }
    }
}
