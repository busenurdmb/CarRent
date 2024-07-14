namespace CarRent.Features.CQRS.Commands.BrandCommands
{
    public class UpdateBrandCommand
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
    }
}
