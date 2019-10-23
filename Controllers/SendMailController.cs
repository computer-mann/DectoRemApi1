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
        private readonly string apiKey="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";
        //private readonly string TEMPLATE_ID="d-28d226c381c843ca9639a86ea827dd28";

        public SendMailController(ILogger<SendMailController> logger)
        {
            _logger = logger;
        }

       [HttpPost]
       public async Task<IActionResult> Send([FromBody]MailData mail){
       	if(mail==null) return BadRequest();
            var msg =new SendGridMessage();
            var client = new SendGridClient(apiKey);
            msg.SetFrom( new EmailAddress("quarshie.wendyvi@gmail.com", "Sam TV"));
            msg.AddTo(new EmailAddress(mail.Email,mail.Email));
            msg.SetTemplateId("d-28d226c381c843ca9639a86ea827dd28");
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
