using FluentValidation;

namespace ComunicazioneFattureCorrispettivi.Validators
{
    public class IdFiscaleIVAItaliaValidator : IdFiscaleIVAValidator
    {
        public IdFiscaleIVAItaliaValidator() : base()
        {
            RuleFor(id => id.IdPaese)
                .NotEmpty()
                .Equal("IT");
        }
    }
}
