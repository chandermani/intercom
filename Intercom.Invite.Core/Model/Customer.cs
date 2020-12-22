using Newtonsoft.Json;

namespace Intercom.Invite
{
    public class Customer
    {
        public Customer(int id, string name, GPSCoordinate coordinate)
        {
            Id = id;
            Name = name;
            Coordinate = coordinate;
        }

        [JsonProperty("user_id")]
        public int Id { get; }

        [JsonProperty("name")]
        public string Name { get; }

        public GPSCoordinate Coordinate { get; }
    }
}