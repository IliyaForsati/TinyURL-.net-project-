using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyURL.Domain.Models
{
    public class Link
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string OriginalURL { get; set; }
        public int ShortCutURLCode { get; set; }
    }
}
