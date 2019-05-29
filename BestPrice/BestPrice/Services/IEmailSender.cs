using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestPrice.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
        //Task SendEmailAsync(string email, string subject, string message, string temp_id, string link, string button_text);
        Task SendEmailByMailKitAsync(string email, string subject, string message);
    }
}
