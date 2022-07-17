namespace FacturacionEMCSite.StringResources.Abstract
{
    public interface IResourceProvider
    {
        public object GetResource(string name, string culture);
    }
}
