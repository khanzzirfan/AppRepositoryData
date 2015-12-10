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
    [ServiceBehavior(Namespace =Constants.Namespace)]
    public class RedPill : IRedPill
    {
        public long FibonacciNumber(long number)
        {
            Int64 a = 0;
            Int64 b = 1;

            for (Int64 i = 0; i < number; i++)
            {
                Int64 temp = a;
                a = b;
                b = temp + b;
            }

            return a;

        }

        public string ReverseWords(string inputSentence)
        {
            StringBuilder strb = new StringBuilder();
            string revStr = "";

            List<char> charlist = new List<char>();
            for (int c = 0; c < inputSentence.Length; c++)
            {

                if (inputSentence[c] == ' ' || c == inputSentence.Length - 1)
                {
                    if (c == inputSentence.Length - 1)
                        charlist.Add(inputSentence[c]);
                    for (int i = charlist.Count - 1; i >= 0; i--)
                        strb.Append(charlist[i]);

                    strb.Append(' ');
                    charlist = new List<char>();
                }
                else
                    charlist.Add(inputSentence[c]);
            }

            string output = strb.ToString();
            revStr = output.ToString();

            return revStr;

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
