using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using BestPrice.Services;

namespace BestPrice.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            /*
            return emailSender.SendEmailAsync(email, "TechPG - Verify your email",
                $"" +
                $"<h1>Thanks for joining TechPG!</h1> <br/>" +
                $"Please confirm your account by clicking this link: <a type='button' href='{HtmlEncoder.Default.Encode(link)}'>Email confirmation link</a>" +
                $"");
            */
            return emailSender.SendEmailByMailKitAsync2(email, "TechPG - Verify your email",
                $"<img src='https://i.ibb.co/QQYMWZQ/logo.jpg' style='width:200px;height:150px' alt='TechPG logo'>" +
                $"<h1>Thanks for joining TechPG!</h1> <br/>" +
                $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>Email confirmation link</a>" +
                $"");
        }
    }
}
