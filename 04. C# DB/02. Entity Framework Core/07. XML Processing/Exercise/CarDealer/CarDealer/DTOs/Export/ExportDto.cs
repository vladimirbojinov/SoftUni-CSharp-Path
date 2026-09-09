namespace CarDealer.DTOs.Export;

using System.Xml.Serialization;

// --- Query 14 DTOs ---
[XmlType("car")]
public class ExportCarWithDistanceDto
{
    [XmlElement("make")]
    public string Make { get; set; } = null!;

    [XmlElement("model")]
    public string Model { get; set; } = null!;

    [XmlElement("traveled-distance")]
    public long TraveledDistance { get; set; }
}

// --- Query 15 DTOs ---
[XmlType("car")]
public class ExportBmwCarDto
{
    [XmlAttribute("id")]
    public int Id { get; set; }

    [XmlAttribute("model")]
    public string Model { get; set; } = null!;

    [XmlAttribute("traveled-distance")]
    public long TraveledDistance { get; set; }
}

// --- Query 16 DTOs ---
[XmlType("supplier")]
public class ExportLocalSupplierDto
{
    [XmlAttribute("id")]
    public int Id { get; set; }

    [XmlAttribute("name")]
    public string Name { get; set; } = null!;

    [XmlAttribute("parts-count")]
    public int PartsCount { get; set; }
}

// --- Query 17 DTOs ---
[XmlType("car")]
public class ExportCarWithPartsDto
{
    [XmlAttribute("make")]
    public string Make { get; set; } = null!;

    [XmlAttribute("model")]
    public string Model { get; set; } = null!;

    [XmlAttribute("traveled-distance")]
    public long TraveledDistance { get; set; }

    [XmlArray("parts")]
    [XmlArrayItem("part")]
    public ExportPartDto[] Parts { get; set; } = null!;
}

[XmlType("part")]
public class ExportPartDto
{
    [XmlAttribute("name")]
    public string Name { get; set; } = null!;

    [XmlAttribute("price")]
    public decimal Price { get; set; }
}

// --- Query 18 DTOs ---
[XmlType("customer")]
public class ExportCustomerSalesDto
{
    [XmlAttribute("full-name")]
    public string FullName { get; set; } = null!;

    [XmlAttribute("bought-cars")]
    public int BoughtCars { get; set; }

    [XmlAttribute("spent-money")]
    public decimal SpentMoney { get; set; }
}

// --- Query 19 DTOs ---
[XmlType("sale")]
public class ExportSaleDto
{
    [XmlElement("car")]
    public ExportSaleCarDto Car { get; set; } = null!;

    [XmlElement("discount")]
    public int Discount { get; set; }

    [XmlElement("customer-name")]
    public string CustomerName { get; set; } = null!;

    [XmlElement("price")]
    public decimal Price { get; set; }

    [XmlElement("price-with-discount")]
    public double PriceWithDiscount { get; set; } // Double helps match the decimal roundings cleanly
}

public class ExportSaleCarDto
{
    [XmlAttribute("make")]
    public string Make { get; set; } = null!;

    [XmlAttribute("model")]
    public string Model { get; set; } = null!;

    [XmlAttribute("traveled-distance")]
    public long TraveledDistance { get; set; }
}
