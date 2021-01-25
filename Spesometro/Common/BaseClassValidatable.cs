using System;
using System.ComponentModel;
using System.Linq;
using System.Xml;
using FatturaElettronica.Core;
using FluentValidation;

namespace Spesometro.Common
{
    public class BaseClassValidatable<T> : BaseClassSerializable, IDataErrorInfo
        where T : BaseClassValidatable<T>
    {
        public BaseClassValidatable() : base() { }
        public BaseClassValidatable(XmlReader r) : base(r) { }
        public string this[string columnName]
        {
            get
            {
                if (Validator == null) return string.Empty;
                var result = Validator.Validate((T)this, columnName);

                if (result.IsValid) return string.Empty;
                return string.Join(Environment.NewLine, result.Errors.Select(x => $"{x.ErrorCode}: {x.ErrorMessage}"));
            }
        }

        public IValidator<T> Validator { get; set; }

        public string Error
        {
            get
            {
                if (Validator == null) return string.Empty;
                var result = Validator.Validate((T)this);

                if (result.IsValid) return string.Empty;
                return string.Join(Environment.NewLine, result.Errors.Select(x => $"{x.ErrorCode}: {x.ErrorMessage}"));
            }
        }
    }
}
