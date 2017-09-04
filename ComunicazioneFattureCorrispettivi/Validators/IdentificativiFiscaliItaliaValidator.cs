namespace ComunicazioneFattureCorrispettivi.Validators
{
    public class IdentificativiFiscaliItaliaValidator : IdentificativiFiscaliValidator
    {
        public IdentificativiFiscaliItaliaValidator()
        {
            RuleFor(x => x.IdFiscaleIVA)
                .SetValidator(new IdFiscaleIVAItaliaValidator());
        }
    }
}
