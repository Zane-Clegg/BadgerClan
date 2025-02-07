using BadgerClanControls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgerClanControls.Services
{
    public interface IApiService
    {
        public Task<ResultPattern<bool, string>> SetApiAsync(string apiUrl, string path);
    }
}
