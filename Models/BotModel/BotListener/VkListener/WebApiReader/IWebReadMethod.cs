using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspMySite.Models.BotModel.BotListener.VkListener.WebApiReader
{
    interface IWebReadMethod
    {
        dynamic ReadWebMethod(string connectionStringWithArgs);
        Task<dynamic> ReadWebMethodAsync(string connectionStringWithArgs);
        dynamic TryReadWebMethod(string connectionStringWithArgs);
        Task<dynamic> TryReadWebMethodAsync(string connectionStringWithArgs);
    }
}
