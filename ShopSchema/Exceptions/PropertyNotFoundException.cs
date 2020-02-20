using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSchema.Exceptions
{
    public class PropertyNotFoundException : BusinessException
    {
        public PropertyNotFoundException(string property) : base($"The property {property} you tried to reach was not found.", "property_not_found") { }
    }
}
