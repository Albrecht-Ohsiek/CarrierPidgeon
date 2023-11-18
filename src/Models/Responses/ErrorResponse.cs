namespace CarrierPidgeon.Models{
    public class ErrorResponse{
        public IEnumerable<string> ErrorMessage{get; set;}

        public ErrorResponse(string errorMessage) : this(new List<string> { errorMessage })
        {
            
        }

        public ErrorResponse(IEnumerable<string> errorMessages)
        {
            ErrorMessage = errorMessages;
        }
    }
}