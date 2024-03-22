﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.CRUD.Broker.Logging
{
    internal class LoggingBroker : ILoggingBroker
    {
        public void LogError(string userMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(userMessage);
            Console.ResetColor();
        }

        public void LogInformation(string message) => Console.WriteLine(message);
        
    }
}
