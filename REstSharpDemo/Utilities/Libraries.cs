using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REstSharpDemo.Utilities
{
    public static class Libraries
    {
        //Method to deserialize response and use it a non-async function
        public static Dictionary<string, string> deserializeResponse(this IRestResponse response) {
            //Remember when using global static methods Interfaces type parameters need to be passed
            var deserialize = new JsonDeserializer().Deserialize<Dictionary<string, string>>(response);
            return deserialize;
        }

        //General method to work with any Rest method in a Asynchronous way
        public static async Task<IRestResponse<T>> ExecuteAsyncRequest<T>(this RestClient client, IRestRequest request) where T:class, new() {
            //TaskCompletionSource turns something that is already asynchronous into a Task,
            //and is executed when a function is being executed
            //in this case ExecuteAsync, accessing through data/response when a callback 
            //within a function is executed
            var taskCompletion = new TaskCompletionSource<IRestResponse<T>>();
            client.ExecuteAsync<T>(request, response =>
            {
                if (response.ErrorException != null)
                {
                    const string message = "Error retrieving response";
                    throw new ApplicationException(message, response.ErrorException);
                }
                taskCompletion.SetResult(response);
            });
            return await taskCompletion.Task;
        }
    }
}
