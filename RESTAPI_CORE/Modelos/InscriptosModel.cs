using System.ComponentModel.DataAnnotations;

namespace RESTAPI_CORE.Modelos
{
    public class InscriptosModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? Apellido { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? DNI { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? Edad { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? Correo { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? Carrera { get; set; }

    }
}
