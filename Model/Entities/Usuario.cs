namespace Model.Entities
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {

        public int ID { get; set; }
        public string Username  { get; set; }
        public string Password { get; set; }

    }

    public class UsuarioViewModel
    {

        public string CabeceraUsuario { get; set; }
        public string CabeceraPassword { get; set; }


        public Usuario ToModel()
        {
            var us = new Usuario();
            us.Username = CabeceraUsuario;
            us.Password = CabeceraPassword;

            return us;
        }
    }
}
