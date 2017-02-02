namespace DataProxy.Entities
{
    public class Tax
    {
        public string TaxName { get; set; }
        public double TaxValue { get; set; }
        public Tax(DatabaseConnector.Tax tax)
        {
            TaxName = tax.tax_name;
            TaxValue = tax.tax_value;
        }
    }
}
