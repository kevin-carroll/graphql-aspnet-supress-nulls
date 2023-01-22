namespace SupressNulls
{
    using GraphQL.AspNet.Engine;
    using GraphQL.AspNet.Interfaces.Execution.Response;
    using GraphQL.AspNet.Interfaces.Schema;
    using System.Text.Json;

    public class NullSupressingResponseWriter<TSchema> : DefaultQueryResponseWriter<TSchema>
        where TSchema : class, ISchema
    {
        public NullSupressingResponseWriter(TSchema schema)
            : base(schema)
        {
        }


        protected override void WriteObjectCollection(Utf8JsonWriter writer, IQueryResponseFieldSet data)
        {
            // This method assumes a property name has already
            // been written and just the value
            // of the property is being serialized.
            // if null is provided, we MUST write it to the response stream
            if (data == null)
            {
                writer.WriteNullValue();
                return;
            }

            // begin writing out the field level data
            writer.WriteStartObject();


            foreach (var kvp in data.Fields)
            {
                // skip fields that have null values
                if (kvp.Value == null)
                    continue;

                writer.WritePropertyName(kvp.Key);
                this.WriteResponseItem(writer, kvp.Value);
            }

            // finish the object
            writer.WriteEndObject();
        }

        // ****************************
        // other overrideable methods for WriteList and WriteLeaf
        // can be modified as well if further customization is needed
        // ****************************
    }
}