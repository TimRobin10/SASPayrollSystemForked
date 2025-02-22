using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.CommonServices
{
    public class ModelDataAnnotationCheck
    {
        public void ValidateModel<TDomainModel> (TDomainModel model)
        {
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();
            ValidationContext validationContext = new ValidationContext(model, null, null);

        }
    }
}
