using System;
using System.Collections.Generic;
using Conceptual.Polymorphism.DataTransferObjects.Person;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Conceptual.Polymorphism.Converters
{
    public class PersonConverter : JsonConverter
    {
        public override bool CanWrite { get; } = false;

        public override bool CanRead { get; } = true;

        private readonly Dictionary<string, Type> _types = new Dictionary<string, Type>
        {
            {"Student", typeof(Student)},
            {"Employee", typeof(Employee)},
        };

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }

        public Person Create(Type objectType, JObject jObject) {
            string role = jObject.GetValue("role").Value<string>();
            return (Person) jObject.ToObject(_types[role]); 
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Person) == objectType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            var target = Create(objectType, jObject);

            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }    
    }
}