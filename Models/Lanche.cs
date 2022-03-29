using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LanchesMac.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int Id { get; set; }
        [StringLength(80,MinimumLength = 10, ErrorMessage ="O {0} deve ter no minimo {1} e no máximo 80 caracteres")]
        [Required(ErrorMessage ="Campo obrigatório")]
        [Display(Name ="Nome do Lanche")]

        public string Nome { get; set; }
        [MinLength(10,ErrorMessage ="O tamanho máximo é {0} caracteres")]
        [MaxLength(200, ErrorMessage ="Descrição não pode exceder {0} caracteres")]
        [Required(ErrorMessage ="Campo obrigatório")]
        [Display(Name ="Descrição do Lanche")]

        public string DescricaoCurta { get; set; }
        [MinLength(10,ErrorMessage ="O tamanho máximo é {0} caracteres")]
        [MaxLength(200, ErrorMessage ="Descrição não pode exceder {0} caracteres")]
        [Required(ErrorMessage ="Campo obrigatório")]
        [Display(Name ="Descrição do Lanche")]


        public string DescricaoDetalhada { get; set; }
        [Required(ErrorMessage ="Informe o Preço do lanche")]
        [Display(Name ="Preço do Lanche")]
        [Column(TypeName ="decimal(10,2)")]
        [Range(1,999.99,ErrorMessage ="Valor do Lanche inválido")]
        public decimal Preco { get; set; }
        public string imagemUrl { get; set; }
        public string imagemThumbNailUrl { get; set; }
        public bool LanchePreferido { get; set; }
        public bool EmEstoque { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}