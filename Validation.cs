using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ShopBridge.Models
{
    public class Validation
    {

        public string Validate(Entity En)
        {
            string result = "";

            if (!string.IsNullOrEmpty(En.Name))
            {

            }
            else
            { //
              //Name is required
                result = result + "Name is required;";
            }

            if (!string.IsNullOrEmpty(En.Description))
            {

            }
            else
            { //
              //Description is required
                result = result + "Description is required;";
            }

            if (!string.IsNullOrEmpty(En.Price.ToString()))
            {
                if (En.Price == 0)
                    return result + "Enter Valid price";
                if (!Regex.IsMatch(En.Price.ToString(), @"[\d]{1,4}([.][\d]{1,2})?"))
                    result = result + "Enter Valid price";

            }
            else
            { //
              //Price is required

                result = result + "Price is required";
            }


            return result;
        }
    }
}