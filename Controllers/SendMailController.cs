using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DecToRem.Models;
using DecToRem.Helpers;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace DecToRem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SendMailController : ControllerBase
    {
        

        private readonly ILogger<SendMailController> _logger;
        private readonly string apiKey="";
        //private readonly string TEMPLATE_ID="";

        public SendMailController(ILogger<SendMailController> logger)
        {
            _logger = logger;
        }

       [HttpPost]
       public async Task<IActionResult> Send([FromBody]MailData mail){
       	if(mail==null) return BadRequest();
            var msg =new SendGridMessage();
            var client = new SendGridClient(apiKey);
            msg.SetFrom( new EmailAddress("", "Sam TV"));
            msg.AddTo(new EmailAddress(mail.Email,mail.Email));
            msg.SetTemplateId("");
            var dynamicTemplateData = new TemplateData()
            {
               Name=mail.FirstName,
               Code=mail.Code
            };
            msg.SetTemplateData(dynamicTemplateData);
            var response = await client.SendEmailAsync(msg);
       	return Ok(new {Status = response.StatusCode});
       }
    }
   
}
