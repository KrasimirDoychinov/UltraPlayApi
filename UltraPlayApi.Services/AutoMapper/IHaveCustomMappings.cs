namespace UltraPlayApi.Services.AutoMapper
{
    using AutoMapper;
    using global::AutoMapper;

    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
