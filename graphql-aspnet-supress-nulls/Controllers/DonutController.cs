namespace SupressNulls.Controllers
{
    using GraphQL.AspNet.Attributes;
    using GraphQL.AspNet.Controllers;
    using SupressNulls.Model;

    public class DonutController : GraphController
    {
        [QueryRoot]
        public Donut RetrieveDonut(string name)
        {
            var donut = new Donut()
            {
                Id = 3,
                Name = name,
                Shape = "round",
            };

            return donut;
        }
    }
}