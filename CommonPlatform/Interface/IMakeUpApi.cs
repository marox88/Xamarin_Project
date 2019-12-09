using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonPlatform.Interface
{
    public interface IMakeUpApi
    {
        [Get("/api/v1/products.json?brand=maybelline")]
        Task<string> GetMakeUps();
        Task GetUser();
    }
}
