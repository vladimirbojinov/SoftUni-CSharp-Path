using System.Xml.Serialization;

namespace ProductShop.DTOs.Import;

[XmlType("CategoryProduct")]
public class ImportCategoriesProductsDto
{
    [XmlElement("ProductId")]
    public int ProductId { get; set; }

    [XmlElement("CategoryId")]
    public int CategoryId { get; set; }
}
