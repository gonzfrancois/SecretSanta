using System;
using System.Collections.Generic;
using SecretSanta.Core.Model;

namespace SecretSanta.Core
{
	public static class MailSender
	{
		public static void SendMails(Dictionary<User,User> pairedUsers, string generalMessageText)
		{
			foreach (var pair in pairedUsers) {
				var str = $"Vous devez faire un cadeau à {pair.Value.Name}.";
				SendMail(pair.Key.MailAddress, str, generalMessageText);
			}
		}
		
		private static void SendMail(string to, string messageText, string generalText)
		{
			Console.WriteLine("Mail à {0} : {1}",to,messageText);
			
			//MailMessage message = new MailMessage();
			//message.From = new MailAddress("leprechaun@SecretSanta.com");
			// 
			//message.to.Add(new MailAddress(to));
			//			 
			//message.Subject = "Secret Santa";
			//message.Body = messageText + Environment.NewLine + generalText;
			// 
			//SmtpClient client = new SmtpClient();
			//client.Send(message);
		}
	}
}
