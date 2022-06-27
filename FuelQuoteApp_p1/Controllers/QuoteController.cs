using FuelQuoteApp_p1.Models.Quote;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FuelQuoteApp_p1.Controllers
{
    public class QuoteController : Controller
    {
        [HttpGet]
        public IActionResult GetQuote()
        {
            FQuote quote = new FQuote();
            quote.DeliveryAddress = "8485 Kirby Drive";
            quote.PricePerGallon = 15;
            quote.TotalAmount = 9595;
            return View(quote);
        }


        [HttpGet]
        public IActionResult QuoteHistory()
        {
            FQuote quote = new FQuote()
            {
                DateRequested = DateTime.Now,
                GallonsRequested = 90,
                DeliveryAddress = "Kirby Drive",
                PricePerGallon = 5,
                TotalAmount = 1515
            };
            List<FQuote> quotes = new List<FQuote>();
            quotes.Add(quote);

            return View(quotes);
        }
    }
}
