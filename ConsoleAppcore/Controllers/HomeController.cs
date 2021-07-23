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

namespace ConsoleAppcore.Controllers
{
        
    public class HomeController : Controller
    {
        private readonly NewBookAlertConfig _newBookAlterconfiguration;
        private readonly NewBookAlertConfig _thirdPartyBookconfiguration;
        private readonly IMessageRepository _messageRepository;
        public HomeController(IOptionsSnapshot<NewBookAlertConfig> newBookAlterconfiguration,IMessageRepository messageRepository)
        {
            _newBookAlterconfiguration = newBookAlterconfiguration.Get("Internal book");
            _thirdPartyBookconfiguration = newBookAlterconfiguration.Get("ThirdPartyBook");
            _messageRepository = messageRepository;
        }


       
        public ActionResult Index()
        {
           
            bool isDisplay = _newBookAlterconfiguration.DisplayNewBookAlert;
            bool isDisplay1 = _thirdPartyBookconfiguration.DisplayNewBookAlert;
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
        
        public ActionResult ContactUs()
        {
            return View();
        }

    }
}
