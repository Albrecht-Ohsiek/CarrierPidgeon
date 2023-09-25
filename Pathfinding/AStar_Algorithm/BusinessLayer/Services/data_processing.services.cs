namespace AStart_Algorithm
{
    public static class data_processing_services
    {
        private static Dictionary<string, Action<int, int>> commandMapping = new Dictionary<string, Action<int, int>>{
           // {"init", //command here}
        };

        public static List<string> processResponseToList(string client_response){
            return new List<string>(client_response.Split('\n'));
        }


    }

}