<<<<<<< HEAD
﻿namespace StockManagement.Api.Utility
{
    [AttributeUsage(AttributeTargets.Method)]
    public class FileResultContentTypeAttribute : Attribute
    {
        public FileResultContentTypeAttribute(string contentType)
        {
            ContentType = contentType;
        }

        public string ContentType { get; }
    }
}
=======
﻿using System;

namespace GloboTicket.TicketManagement.Api.Utility
{
    [AttributeUsage(AttributeTargets.Method)]
    public class FileResultContentTypeAttribute : Attribute
    {
        public FileResultContentTypeAttribute(string contentType)
        {
            ContentType = contentType;
        }

        public string ContentType { get; }
    }
}
>>>>>>> facfeb4d50bb811eabacaadcc911ea637ce309ba
