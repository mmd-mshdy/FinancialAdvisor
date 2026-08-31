using System.ComponentModel.DataAnnotations;

namespace FinAdvisor.BuildingBlocks.Application.Validation;

public interface IValidator<in T>
{
    ValidationResult Validate(T instance);
}