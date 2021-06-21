﻿using System;
using System.ComponentModel.DataAnnotations;

namespace NerdStore.WebApp.API.DTOs
{
    public class CategoriaDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Codigo { get; set; }
    }
}