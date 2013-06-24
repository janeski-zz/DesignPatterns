﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.ChainOfResponsibility;

namespace ChainOfResponsibilityPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger, logger1, logger2;
            logger = new ConsoleLogger(LogLevel.All);
            logger1 = logger.SetNext(new EmailLogger(LogLevel.FunctionalMessage | LogLevel.FunctionalError));
            logger2 = logger1.SetNext(new FileLogger(LogLevel.Warning | LogLevel.Error));

            // Handled by ConsoleLogger
            logger.Message("Entering function ProcessOrder().", LogLevel.Debug);
            logger.Message("Order record retrieved.", LogLevel.Info);

            // Handled by ConsoleLogger and FileLogger
            logger.Message("Customer Address details missing in Branch DataBase.", LogLevel.Warning);
            logger.Message("Customer Address details missing in Organization DataBase.", LogLevel.Error);

            // Handled by ConsoleLogger and EmailLogger
            logger.Message("Unable to Process Order ORD1 Dated D1 For Customer C1.", LogLevel.FunctionalError);

            // Handled by ConsoleLogger and EmailLogger
            logger.Message("Order Dispatched.", LogLevel.FunctionalMessage);
        }
    }
}
