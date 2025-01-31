using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgerClanControls.Services
{
    public interface IApiService
    {
        public Task SetApiAsync(string strategyChoice);
    }
}
