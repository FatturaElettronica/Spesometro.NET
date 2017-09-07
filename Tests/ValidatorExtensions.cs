using System;
using System.Linq;
using System.Linq.Expressions;
using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.TestHelper;
using FluentValidation.Validators;

namespace Tests
{
    public static class ValidatorExtensions
    {
        // TODO improve!

        public static void ShouldHaveDelegateChildValidator<T, TProperty>(this IValidator<T> validator, Expression<Func<T, TProperty>> expression, Type childValidatorType)
        {
            var descriptor = validator.CreateDescriptor();
            var expressionMemberName = expression.GetMember().Name;

            var matchingValidators = descriptor.GetValidatorsForMember(expressionMemberName).ToArray();

            var delegatingValidatorTypes = matchingValidators
                .OfType<DelegatingValidator>()
                .Where(x => x.InnerValidator.GetType() == typeof(ChildValidatorAdaptor))
                .Select(x=>x.InnerValidator)
                .ToList();

            foreach(var d in delegatingValidatorTypes)
            {
                var x = d as ChildValidatorAdaptor;
                if (d == null) continue;
                if (x.ValidatorType == childValidatorType) return;
            }

            throw new ValidationTestException(string.Format("Expected property '{0}' to have a delegate child validator of type '{1}'. ", expressionMemberName, childValidatorType.Name));
        }

    }
}
