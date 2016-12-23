using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization;
using Amazon.EC2;
using Amazon.EC2.Model;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializerAttribute(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace test_lmbdaNetCore
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(string input, ILambdaContext context)
        {
            //var response = new SampleClass
            //{
            //    Str = input.Str?.ToUpper(),
            //    StrArray = input.StrArray.Select(x => x?.ToUpper()).ToArray(),
            //};
            var dt = DateTime.Now;

            Console.WriteLine("now time=" + dt.ToString());
            for (var i = 1;i <= 9; i++)
            {
                for (var j = 1; j <= 9; j++)
                {
                    Console.Write(i.ToString()+" * "+j.ToString() +" = " + i * j);
                }
                Console.WriteLine("----");
            }

            //EC2���X�g�̎擾
            var client = new Amazon.EC2.AmazonEC2Client();
            List<string> tags = new List<string>();
            var request = new DescribeInstancesRequest();
            CancellationToken source = new CancellationToken();
            var response = client.DescribeInstancesAsync(request, source);
            
            


                return input?.ToUpper();
            //return response;
        }
    }
    public class SampleClass
    {
        public string Str { get; set; }
        public string[] StrArray { get; set; }
    }

}
