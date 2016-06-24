using System;
using Windows.Devices.Geolocation;
using Newtonsoft.Json;

namespace SimpleNotes.Models
{
	public class Note : IEquatable<Note>
	{
		public string TenantId { get; set; }

		public int Id { get; set; }

		public string Title { get; set; } = string.Empty;

		[JsonProperty("Content")]
		public string Text { get; set; }

		[JsonProperty("CreatedAt")]
		public DateTime CreationDate { get; set; }

		public double Latitude { get; set; }

		public double Longitude { get; set; }

		public Geopoint GeoPoint => new Geopoint(new BasicGeoposition() { Latitude = Latitude, Longitude = Longitude});

		// empty constructor for json decoding
		public Note()
		{
			
		}

		public Note(DateTime date, string text)
		{
			CreationDate = date;
			Text = text;
		}

		public bool Equals(Note other)
		{
			return Text.Equals(other.Text) && CreationDate.Equals(other.CreationDate);
		}
	}
}
