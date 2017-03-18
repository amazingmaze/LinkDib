using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinkDib.Validation
{
    public class UrlValidation : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            // Check if value is a url
            //TODO: implement URL validation

            return true;
        }


    }
}