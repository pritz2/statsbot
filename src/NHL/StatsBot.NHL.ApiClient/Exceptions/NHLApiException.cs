using System;
using System.Net;

namespace StatsBot.NHL.ApiClient.Exceptions
{
    public class NHLApiException : Exception
    {
        public NHLApiException(string path, HttpStatusCode statusCode)
            : base($"NHL Api request to {path} failed with {statusCode}")
        {
        }
    }
}
