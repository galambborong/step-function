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
            LambdaLogger.Log($"\n*** {DateTime.Now} *** \n Creating hash from input\n");
            try
            {
                var hashedObject = processedInput.CreateHash();
                var finalHash = PrintByteArray(hashedObject.Hash);
                LambdaLogger.Log($"\n*** {DateTime.Now} *** \n Success: Hash created! Your SHA256 is: {finalHash}\r");
                return finalHash;
            } catch (Exception e)
            {
                LambdaLogger.Log($"\n*** {DateTime.Now} *** \n Error {e} occurred.\nYou possibly did not pass in the expected parameters.\n");
                return "PROCESS FAILED";
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
