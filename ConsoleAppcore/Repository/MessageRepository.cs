using ConsoleAppcore.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleAppcore.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IOptionsMonitor<NewBookAlertConfig> _newBookAlterconfiguration;
        public MessageRepository(IOptionsMonitor<NewBookAlertConfig> newBookAlterconfiguration)
        {
            _newBookAlterconfiguration = newBookAlterconfiguration;
            //newBookAlterconfiguration.OnChange(config =>
            //{
            //    _newBookAlterconfiguration = config;
            //});
        }
        public string GetName()
        {
            return _newBookAlterconfiguration.CurrentValue.BookName;
        }
    }
}
