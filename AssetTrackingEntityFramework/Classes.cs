using System.Globalization;

namespace AssetTrackingEntityFramework
{
    public class Column
    {
        public Column(string name = "", int width = 1, string propertyName = "")
        {
            Name = name;
            Width = Math.Max(width, name.Length);
            PropertyName = propertyName.Length != 0 ? propertyName : new CultureInfo("en-UK").TextInfo.ToTitleCase(name).Replace(" ", "");
        }
        public string Name { get; set; }
        public int Width { get; set; }
        public string PropertyName { get; set; }
    }

    public class Asset
    {
        public Asset(string type, string brand, string model, string office, DateTime purchaseDate, double localPrice)
        {

            Type = type;
            Brand = brand;
            Model = model;
            Office = office;
            PurchaseDate = purchaseDate;
            LocalPrice = localPrice;
            DefaultCurrency = "USD";
        }
        public int ID { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Office { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double LocalPrice { get; set; }
        public string DefaultCurrency { get; set; }
        public string Currency
        {
            get
            {
                switch (Office)
                {
                    case "Sweden":
                        return "SEK";
                    case "Denmark":
                        return "DKK";
                    case "Norway":
                        return "NOK";
                    case "United Kingdom":
                    case "UK":
                        return "GBP";
                    case "Austria" or "Belgium" or "Cyprus" or "Estonia" or "Finland" or
                         "France" or "Germany" or "Greece" or "Ireland" or "Italy" or
                         "Latvia" or "Lithuania" or "Luxembourg" or "Malta" or "the Netherlands" or
                         "Portugal" or "Slovakia" or "Slovenia" or "Spain":
                        return "EUR";
                    default:
                        return "USD";
                }
            }
        }
        public double PriceUSD
        {
            get
            {
                double rate = 1;
                switch (Currency)
                {
                    case "EUR": rate = 1.05; break;
                    case "GBP": rate = 1.23; break;
                    case "DKK": rate = 0.14; break;
                    case "SEK": rate = 0.1; break;
                }
                return LocalPrice * rate;
            }
        }
        public bool EndOfLife(int numberOfMonths = 3)
        {
            return PurchaseDate < DateTime.Now.AddYears(-3).AddMonths(numberOfMonths);
        }
    }

    public class MenuFunction
    {
        public MenuFunction(string description, Action action)
        {
            Description = description;
            Action = action;
        }
        public string Description { get; set; }
        public Action Action { get; set; }
    }
}
