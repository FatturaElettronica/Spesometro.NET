namespace Spesometro.Validators
{
    public class IdentificativiFiscaliCedentePrestatoreDTRValidator : IdentificativiFiscaliValidator
    {
        public IdentificativiFiscaliCedentePrestatoreDTRValidator()
        {
            RuleFor(x => x.IdFiscaleIVA)
                .SetValidator(new IdFiscaleIVAValidator());
        }
    }
}
