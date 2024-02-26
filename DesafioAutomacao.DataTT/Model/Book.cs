using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioAutomacao.DataTT.Model
{
    //Classe criada para representar uma entidade no banco de dados que a aplicação manipula
    [DataContract(IsReference = true)]
    [Table("Book")]
    public class Book
    {
        [Key]
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBook { get; set; }

        [Required(ErrorMessage = "O campo title é obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo title deve conter no máximo 200 caracteres")]
        [DataMember]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo Teacher é obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo Teacher deve conter no máximo 200 caracteres")]
        [DataMember]
        public string Teacher { get; set; }

        [Required(ErrorMessage = "O campo Workload é obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo Workload deve conter no máximo 200 caracteres")]
        [DataMember]
        public string Workload { get; set; }

        [Required(ErrorMessage = "O campo Description é obrigatório")]
        [MaxLength(2000, ErrorMessage = "O campo Description deve conter no máximo 2000 caracteres")]
        [DataMember]
        public string Description { get; set; }
    }
}
