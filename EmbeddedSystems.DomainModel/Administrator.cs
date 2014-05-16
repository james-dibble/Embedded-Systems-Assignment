// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AudioFile.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
namespace EmbeddedSystems.DomainModel
{
    /// <summary>
    /// An object that represents an <see cref="Exhibit"/>'s audio file.
    /// </summary>
    public class Administrator : UniqueObject<int>
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Title { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

    }
}