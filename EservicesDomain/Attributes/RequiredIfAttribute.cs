using System;


namespace EservicesDomain.Attributes
{

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class RequiredIfAttribute : Attribute
    {
        public String PropertyName { get; set; }
        public Object DesiredValue { get; set; }
        public string Condition { get; set; }
        private int ComparisionMethod { get; set; }
        public RequiredIfAttribute(String propertyName, Object desiredvalue, int comparisionMethod)
        {
            PropertyName = propertyName;
            DesiredValue = desiredvalue;

        }

        public RequiredIfAttribute(String propertyName, Object desiredvalue)
        {
            PropertyName = propertyName;
            DesiredValue = desiredvalue;
            ComparisionMethod = Operators.EQ;
        }



    }

    public class Operators
    {
        public const int EQ = 0;
        public const int NEQ = 1;
        public const int GEQ = 2;
        public const int LEQ = 3;
        public const int LT = 4;
        public const int GT = 5;
    }

}
