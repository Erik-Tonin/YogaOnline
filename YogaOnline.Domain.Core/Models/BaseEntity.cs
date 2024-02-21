using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace YogaOnline.Domain.Core.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public DateTimeOffset? DateDeleted { get; set; }
        [NotMapped]
        public ValidationResult ValidationResult { get; protected set; }

        protected BaseEntity()
        {
            ValidationResult = new ValidationResult();
        }

        public void AddValidationError(string error, string description)
        {
            ValidationResult.Errors.Add(new ValidationFailure(error, description));
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
