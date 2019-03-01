using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using webapplication.Models;
using MailKit.Net.Smtp;
using MimeKit;

namespace webapplication.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public AppSettings config;
        private readonly AppSettings connections;
        public ValuesController(IOptions<AppSettings> appsettings)
        {
            connections = appsettings.Value;
            config = appsettings.Value;

        }
        private AppSettings AppSettings { get; set; }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            string connectionString = connections.DBConnections.defaultDbConnection;
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var envelope = new MyEnvelope();
            envelope.password = "MyPassword!@#";
            envelope.body = "<b>Testing: </b> <span style=\"color:red;\">The mailkit system.</span>";
            envelope.fromAddress = "me@mymail.com";
            envelope.fromName = "Beyond Logical";
            envelope.port = 587;
            envelope.smtp = "mail.mysite.com";
            envelope.subject = "Final - Test email from myself to myself - Final";
            envelope.toAddress = "mybuddy@gmail.com";
            envelope.toName = "Bryan Maveric";
            envelope.username = "me@mysite.com";
            Send(envelope);
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        public void Send(MyEnvelope envelope)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(envelope.fromName, envelope.fromAddress));
            message.To.Add(new MailboxAddress(envelope.toName, envelope.toAddress));
            message.Subject = envelope.subject;

            message.Body = new TextPart("html")
            {
                Text = envelope.body
            };
            using (var client = new SmtpClient())
            {
                client.Connect(envelope.smtp, envelope.port);
                client.Authenticate(envelope.username, envelope.password);
                client.Send(message);
                client.Disconnect(true);
            }
        }
        public class MyEnvelope
        {
            public string toAddress { get; set; }
            public string toName { get; set; }
            public string fromAddress { get; set; }
            public string fromName { get; set; }
            public string subject { get; set; }
            public string body { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string smtp { get; set; }
            public int port { get; set; }
        }
    }
}

