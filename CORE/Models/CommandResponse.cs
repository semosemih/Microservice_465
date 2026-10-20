using CORE.Domain;
namespace CORE.Models
{
    public class CommandResponse : Record
    {
        public bool IsSuccessful{get; }

        public string Message {get;}

        public CommandResponse(bool IsSuccessful, string message, int id = 0) : base(id)
        {
            IsSuccessful = IsSuccessful;
            Message = message;
        }
    }
}