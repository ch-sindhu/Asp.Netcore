using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using ConsoleAppcore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ConsoleAppcore.Repository;
using ConsoleAppcore.Services;
using System.Net.Mail;
using Microsoft.AspNetCore.Authorization;

namespace ConsoleAppcore.Controllers
{
        
    public class HomeController : Controller
    {
        private readonly NewBookAlertConfig _newBookAlterconfiguration;
        private readonly NewBookAlertConfig _thirdPartyBookconfiguration;
        private readonly IMessageRepository _messageRepository;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public HomeController(IOptionsSnapshot<NewBookAlertConfig> newBookAlterconfiguration,
            IMessageRepository messageRepository,
             IUserService userService,
             IEmailService emailService)
        {
            _newBookAlterconfiguration = newBookAlterconfiguration.Get("Internal book");
            _thirdPartyBookconfiguration = newBookAlterconfiguration.Get("ThirdPartyBook");
            _messageRepository = messageRepository;
            _userService = userService;
            _emailService = emailService;
        }

        
       
        public ActionResult Index()
        {
            //UserEmailOptions options = new UserEmailOptions
            //{
            //    ToEmails = new List<string>() { "test@gmail.com" },
            //    PlaceHolders = new List<KeyValuePair<string, string>>()
            //    {
            //        new KeyValuePair<string, string>("{{UserName}}","Nitish")
            //    }
            //};
            // await _emailService.SendTestEmail(options);

            //  var userId = _userService.GetUserId();
            //var isLoggedIn = _userService.IsAuthenticated();
            //bool isDisplay = _newBookAlterconfiguration.DisplayNewBookAlert;
            //bool isDisplay1 = _thirdPartyBookconfiguration.DisplayNewBookAlert;
            //var value = _messageRepository.GetName();
            //var result = newbook.GetValue<bool>("DisplayNewBookAlert");
            //var bookname = newbook.GetValue<string>("BookName");
            //var result = configuration["AppName"];
            //var key1 = configuration["infoObj:key1"];
            //var key2 = configuration["infoObj:key2"];
            //var key3 = configuration["infoObj:key3:key3obj1"];
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        [Authorize(Roles ="Admin")]
        public ActionResult ContactUs()
        {
            return View();
        }

    }
}
