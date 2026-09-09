namespace ProductShop.DTOs.Export;

using System.Xml.Serialization;

[XmlRoot("Users")]
public class ExportUserAndProductRootDto
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("users")]
    [XmlArrayItem("User")]
    public ExportUserWithProductsDto[] Users { get; set; } = null!;
}

public class ExportSoldProductsContainerDto
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("products")]
    [XmlArrayItem("Product")]
    public ExportProductDto[] Products { get; set; } = null!;
}
