using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using wCyber.Helpers.Identity.Auth;

namespace RehabAid.Data
{
    partial class User : ISysUser
    {
        [NotMapped]
        public int RoleId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [NotMapped]
        public string PictureUrl { get => ""; set => throw new NotImplementedException(); }
    }
}
