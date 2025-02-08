namespace maten_backend.Endpoints
{
    public static class Endpoints
    {
        public static void ConfigureEndpoints(this WebApplication app)
        {
            app.RegisterRecipeEndpoints();
            app.RegisterIngredientEndpoints();
        }
    }
}
