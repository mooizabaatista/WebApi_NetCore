using System;
using System.Collections.Generic;

namespace Manager.Services.Dtos
{
    public class CategoriaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public CategoriaDto() { }

        public CategoriaDto(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}