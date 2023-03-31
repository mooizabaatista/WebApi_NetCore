using System;
using System.Collections.Generic;

namespace Manager.Services.Dtos
{
    public class CategoriaDtoFlat
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public CategoriaDtoFlat() { }

        public CategoriaDtoFlat(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}