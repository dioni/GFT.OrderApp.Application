using GFT.OrderApp.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFT.OrderApp.Service
{
    public interface IOrderMapper
    {
        Order MapToOrder(string input);
        string MapToOutput(Order order);
    }
}
