using Microsoft.AspNetCore.Identity.UI.Services;
using NuGet.Configuration;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Net;
using System.Net.Mail;

namespace Tachyon.services
{
	public class EmailSender:IEmailSender
	{
		public EmailSender() { 
		}

		public async Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			string from = "i@gmail.com";
			string password = "";
			string senderName = "Admin";
			MailMessage  message = new MailMessage();
			message.From = new MailAddress(from);
			message.Subject = subject;
			message.Body = "<html><body>"+htmlMessage+ "</html></body>";
			message.To.Add(new MailAddress(email));
			message.IsBodyHtml = true;

			var stmpclient = new SmtpClient("smtp.gmail.com")
			{
				Port = 587,
				Credentials = new NetworkCredential(from, password),
				EnableSsl = true

			};
			stmpclient.Send(message);
		}
	}
}
