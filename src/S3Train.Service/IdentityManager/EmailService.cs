using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace S3Train.IdentityManager
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            if (message == null)
                return;

            await Task.Factory.StartNew(() => { });
        }
    }
}
