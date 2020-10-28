using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazijnProject.Classes
{
    public class InvoicePosition
    {
        public int OrderNumber { get; set; }

        public double Price => Quantity * UnitPrice;

        public string PriceFormatted => Price.ToString("C");

        public double Quantity { get; set; }

        public string QuantityFormatted => Quantity.ToString("#.00");

        public string Title { get; set; }

        public string Unit { get; set; }

        public double UnitPrice { get; set; }

        public string UnitPriceFormatted => UnitPrice.ToString("C");
    }
}
