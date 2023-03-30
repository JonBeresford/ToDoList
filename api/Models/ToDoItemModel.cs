using api.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace api.Message
{
    public class ToDoItemModel : IToDoItem, IValidatableObject
    {
        [Required]
        public string ToPhoneNumber {get;set;}
        [Required]
        [MaxLength(160)]
        public string Message {get;set;}

        public string ToNumberStripped => ToPhoneNumber.StartsWith("0") ? ToPhoneNumber[1..] : ToPhoneNumber;

        public List<ValidationResult> ValidationErrors => _validationErrors;
        public bool IsValid => GetIsValid();

        private List<ValidationResult> _validationErrors;


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            var results = new List<ValidationResult>();

            // some other random test
            if (string.IsNullOrEmpty(ToPhoneNumber))
            {
                results.Add(new ValidationResult("ToPhoneNumber must be populated"));
            }

           
            if (!long.TryParse(ToPhoneNumber, out long _))
            {              
                results.Add(new ValidationResult("ToPhoneNumber must be a number"));
            }

            if (string.IsNullOrEmpty(Message))
            {
                results.Add(new ValidationResult("Message must be populated"));
            }

            if (Message.Length > 160)
            {
                results.Add(new ValidationResult("Message can only be 160 characters maximum"));
            }

            return results;
        }

        private bool GetIsValid()
        {
            _validationErrors = new List<ValidationResult>();

            return Validator.TryValidateObject(
                this,
                new ValidationContext(this, null, null),
                _validationErrors,
                false);
        }

    }
}