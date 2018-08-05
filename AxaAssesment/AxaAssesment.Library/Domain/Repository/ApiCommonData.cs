using System;
using System.Collections.Generic;
using System.Net.Http;

namespace AxaAssesment.Library.Domain.Repository
{
    public class ApiCommonData
    {
        private string _serviceDataUrl;
        static HttpClient client = new HttpClient();

        public ApiCommonData(string urlData){
            this._serviceDataUrl = urlData;
        }

        public async System.Threading.Tasks.Task<T> GetModelAsync<T>(){
            T result = default(T);
            HttpResponseMessage response = await client.GetAsync(this._serviceDataUrl);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<T>();
            }
            return result;
        }
    }
}
