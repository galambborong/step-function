using Amazon.Lambda.Core;
using System;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace HandleUserInput
{
    public class Function
    {
        public ProducedOutput FunctionHandler(ReceivedInput userInput, ILambdaContext context)
        {
            LambdaLogger.Log($"\n*** {DateTime.Now} ***\nProcessing message object from input\n");


            if (userInput.FirstName != null || userInput.Surname != null || userInput.Message != null)
            {
                var HandledInput = new ProducedOutput { FirstName = userInput.FirstName, Surname = userInput.Surname, Message = userInput.Message, ProcessedAt = DateTime.Now };
                LambdaLogger.Log($"\n*** {DateTime.Now} ***\nSuccess: Message created!\n");
                return HandledInput;
            }

            else
            {
                LambdaLogger.Log($"\n*** {DateTime.Now} ***\nError: Incorrect input!\n");
                throw new ArgumentNullException();
            }

        }
    }
}
