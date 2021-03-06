﻿using Newtonsoft.Json;

namespace OneDrive_Cloud_Player.Models.GraphData
{
	/// <summary>
	/// This class represents a cached drive item. This can either be a folder or a file.
	/// </summary>
	public class CachedDriveItem
	{
		/// <summary>
		/// This id is used to uniquely identidy an item.
		/// </summary>
		[JsonProperty("itemId")]
		public string ItemId { get; set; }

		/// <summary>
		/// This id will reference the id of another item in case this item has a parent. If this item does not have a parent,
		/// this id will reference the Id (not DriveId) of the drive it resides in.
		/// </summary>
		[JsonProperty("parentItemId")]
		public string ParentItemId { get; set; }

		/// <summary>
		/// This boolean indicates whether or not this item is a folder.
		/// </summary>
		[JsonProperty("isFolder")]
		public bool IsFolder { get; set; }

		/// <summary>
		/// This is the name of the item. In case of a folder, it will be the folder name. In case of a file, it will be the file name.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Size of the file or folder in Bytes
		/// </summary>
		[JsonProperty("size")]
		public long? Size { get; set; }

		/// <summary>
		/// In case this is a folder, this represents the amount of children this folder has
		/// </summary>
		[JsonProperty("childCount")]
		public int? ChildCount { get; set; }

		/// <summary>
		/// In case this is a file, this represents the mime type
		/// </summary>
		[JsonProperty("mimeType")]
		public string MimeType { get; set; }
	}
}
