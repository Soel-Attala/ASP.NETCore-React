using SalesSystem.BLL.Interfaces;
using SalesSystem.DAL.Interfaces;
using SalesSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.BLL.Implementations
{
    public class MailServices : IMailServices
    {
        private readonly IGenericRepository<Configuration> _repository;
        public MailServices(IGenericRepository<Configuration> repository)
        {
            _repository = repository;
        }

        public async Task<bool> SendMail(string MailDestiny, string About, string Message)
        {
            try
            {

                IQueryable<Configuration> query = await _repository.GetAll(c => c.Resource.Equals("Email_Service"));

                Dictionary<string, string> Config = query.ToDictionary(keySelector: c => c.Property, elementSelector: c => c.Value);

                var credentials = new NetworkCredential(Config["email"], Config["password"]);

                var mail = new MailMessage()
                {
                    From = new MailAddress(Config["email"], Config["alias"]),
                    Subject = About,
                    Body = Message,
                    IsBodyHtml = true
                };

                mail.To.Add(new MailAddress(MailDestiny));

                var serverClient = new SmtpClient()
                {
                    Host = Config["host"],
                    Port = int.Parse(Config["port"]),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true
                };
                serverClient.Send(mail);
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}



