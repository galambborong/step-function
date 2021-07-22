using System;
using System.Text;
using System.Security.Cryptography;

namespace ProcessMessageIntoHash
{
    public class ProcessedInput
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Message { get; set; }
        public DateTime ProcessedAt { get; set; }

        public SHA256 CreateHash()
        {
            var stringifiedPayload = $"{FirstName}::{Surname}::{Message}::{ProcessedAt}";

            byte[] bytes = Encoding.UTF8.GetBytes(stringifiedPayload);

            SHA256 hashedProperties = SHA256.Create();
            hashedProperties.ComputeHash(bytes);

            return hashedProperties;
        }
    }
}
