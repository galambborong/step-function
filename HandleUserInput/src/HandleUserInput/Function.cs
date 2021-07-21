using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace HandleUserInput
{
    public class Function
    {
        public ProducedOutput FunctionHandler(ReceivedInput userInput, ILambdaContext context)
        {
            var HandledInput = new ProducedOutput { FirstName = userInput.FirstName, Surname = userInput.Surname, Message = userInput.Message, ProcessedAt = System.DateTime.Now };
            return HandledInput;
        }
    }
}
