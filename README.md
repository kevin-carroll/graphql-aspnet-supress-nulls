# graphql-aspnet-supress-nulls

This sample project shows how to register a custom response writer that will inspect an object's fields and discard any that have a `null` value.

### Key Take aways:
* `Program.cs` shows how to register the custom response writer
* `NullSupressingResponseWriter.cs` shows how to skip null fields


Sample Query:
```graphql
query {
    donutWithName:  retrieveDonut(name: "glazed"){
        id
        name
        shape
    }

    # 'name' will be null and the response writer will supress it
    donutWithoutName : retrieveDonut(name: null){
        id
        name
        shape
    }
}

```

Response:
```json
{
  "data": {
    "donutWithName": {
      "id": 3,
      "name": "glazed",
      "shape": "round"
    },
    "donutWithoutName": {
      "id": 3,
      "shape": "round"
    }
  }
}
```

Note: I don't believe this is a spec compliant implementation. The user requested a nullable field that produced a valid `null` value, yet it was not returned. The query is also indeterminate since the structure of the output is dependent on variable input parameters and not the query text as provided.
