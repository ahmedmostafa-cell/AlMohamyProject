﻿using Microsoft.AspNetCore.Http;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailService
{
    public class EmailAddress
    {
      
        public string Address { get; set; }
        public string DisplayName { get; set; }
    }
    public class Message
    {
        public string id { get; set; }
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public IFormFileCollection Attachments { get; set; }

        public Message(IEnumerable<string> to, string subject, string content, IFormFileCollection attachments , string id)
        {
            To = new List<MailboxAddress>();

            To.AddRange(to.Select(x => new MailboxAddress(x , x)));
            Subject = subject;
            Content = content;
            Attachments = attachments;
        }
    }
}
