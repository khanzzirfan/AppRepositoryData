using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RedPill
{
    public class Constants
    {
        // Ensures consistency in the namespace declarations across services
        public const string Namespace = "http://khanzzirfan.com/Red/";
    }
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRedPill" in both code and config file together.
    [ServiceContract(Namespace =Constants.Namespace)]
    public interface IRedPill
    {
        [OperationContract]
        System.Guid WhatIsYourToken();

        [OperationContract]
        string ReverseWords(string inputSentence);

        [OperationContract]
        Int64 FibonacciNumber(Int64 number);
        
        [OperationContract]
        TriangleType WhatShapeIsThis(int a, int b, int c);

    }
    
    [DataContract(Namespace = Constants.Namespace)]
    public enum TriangleType
    {
        [EnumMember]
        Scalene = 1,
        [EnumMember]
        Isosceles = 2,
        [EnumMember]
        Equilateral = 3,
        [EnumMember]
        Error = 4,
    }


}
