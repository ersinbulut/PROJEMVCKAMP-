﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.Models
{
    public class ContactModel
    {
        [Key]
        public int ContactID { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string UserMail { get; set; }
        [StringLength(50)]
        public string Subject { get; set; }

        public string Mesaj { get; set; }

        public int İletisimSayisi { get; set; }

    }
}