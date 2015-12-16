using RedPill.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RedPill
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RedPill" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RedPill.svc or RedPill.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(Namespace =Constants.Namespace, IncludeExceptionDetailInFaults = true)]
    public class RedPill : IRedPill
    {
        // The Readify token associated with the khanzz_irfan@hotmail.com.
        protected Guid token = new Guid("2ef05651-900d-4735-aaab-653e6937ab52");

        public long FibonacciNumber(long n)
        {
            long result = 0;

            try
            {
                result = new FibonacciService().Calculate(n);
            }
            catch (ArgumentOutOfRangeException)
            {
                // The ArgumentOutOfRangeException is expected, therefore re-throw it further.
                throw;
            }
            catch (Exception exception)
            {
               
            }

            return result;
            
        }

        public string ReverseWords(string s)
        {
            string result = string.Empty;

            try
            {
                result = new ReverseWordService().ReverseWords(s);
            }
            catch (ArgumentNullException)
            {
                // The ArgumentNullException is expected, therefore re-throw it further.
                throw;
            }
            catch (Exception exception)
            {
            }

            return result;
        }

        public Guid WhatIsYourToken()
        {
            string _myGuid = "2ef05651-900d-4735-aaab-653e6937ab52";
            Guid g = new Guid(_myGuid);

            return g;
        }

        public TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            TriangleType answer;
            if (a <= 0 || b <= 0 || c <= 0)
            {
                answer = TriangleType.Error;

            }
            else if ((a + b <= c) || (b + c <= a) || (a + c <= b))
            {
                answer = TriangleType.Error;
            }
            else if ((a == b) && (b == c))
            {
                answer = TriangleType.Equilateral;

            }
            else if ((a == b) || (b == c) || (a == c))
            {
                answer = TriangleType.Isosceles;
            }
            else
            {
                answer = TriangleType.Scalene;
            }
            return answer;
        }
    }
}
