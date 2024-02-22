using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace YogaOnline.Domain.Core.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }
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
