using Amazon.Lambda.Core;
using System;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace ProcessMessageIntoHash
{

    public class Function
    { 
        public string FunctionHandler(ProcessedInput processedInput, ILambdaContext context)
        {
            LambdaLogger.Log($"\n*** {DateTime.Now} *** \nCreating hash from input\n");
            
            if (processedInput.ProcessedAt != null || processedInput.FirstName != null || processedInput.Surname != null || processedInput.Message != null)
            {
                var hashedObject = processedInput.CreateHash();
                var finalHash = PrintByteArray(hashedObject.Hash);
                LambdaLogger.Log($"\n*** {DateTime.Now} *** \nSuccess: Hash created! Your SHA256 is: {finalHash}\r\n");
                return finalHash;
            } 
            else 
            {
                LambdaLogger.Log($"\n*** {DateTime.Now} *** \nError: Incorrect input.\n");
                throw new ArgumentException();
            }

        }

        public static string PrintByteArray(byte[] array)
        {
            string str = "";
            for (int i = 0; i < array.Length; i++)
            {
                str += $"{array[i]:X2}";
            }
            return str;
        }
    }
}
