using CP3.Domain.Interfaces.Dtos;
using FluentValidation;

namespace CP3.Application.Dtos
{
    public class BarcoDto : IBarcoDto
    {

        public string Nome { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int Ano { get; set; }
        public double Tamanho { get; set; }




        public void Validate()
        {
            var validator = new BarcoDtoValidation().Validate(this);
            if (!validator.IsValid)
            {
                throw new ValidationException(validator.Errors);
            }
            

        }
    }

        


    internal class BarcoDtoValidation : AbstractValidator<BarcoDto>
    {
        public BarcoDtoValidation()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(x => x.Modelo).NotEmpty().WithMessage("Modelo é obrigatório");
            RuleFor(x => x.Ano).GreaterThan(0).WithMessage("Ano deve ser maior que 0");
            RuleFor(x => x.Tamanho).GreaterThan(0).WithMessage("Tamanho deve ser maior que 0");

        }
    }

}
