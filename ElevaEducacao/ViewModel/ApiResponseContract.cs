using ElevaEducacao.Infra.CrossCutting.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevaEducacao.ViewModel
{
    public class ApiResponseContract
    {
        public bool Success { get; private set; }
        public string[] Errors { get; private set; }

        public static ApiResponseContract From(IReadOnlyCollection<Notification> errors)
        {
            var success = errors == null || errors.Count == 0;

            return new ApiResponseContract
            {
                Success = success,
                Errors = errors?.Select(x => x.Message).ToArray()
            };
        }

        public object ToJson()
        {
            return new
            {
                success = Success,
                errors = Errors,
            };
        }
    }
}
