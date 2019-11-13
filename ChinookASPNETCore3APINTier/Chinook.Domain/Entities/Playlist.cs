﻿using Chinook.Domain.Converters;
using Chinook.Domain.ApiModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chinook.Domain.Entities
{
    public class Playlist : IConvertModel<Playlist, PlaylistApiModel>
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PlaylistId { get; set; }
        public string Name { get; set; }

        [NotMapped]
        [Newtonsoft.Json.JsonIgnore]
        public ICollection<PlaylistTrack> PlaylistTracks { get; set; } = new HashSet<PlaylistTrack>();

        [NotMapped]
        [Newtonsoft.Json.JsonIgnore]
        public PlaylistApiModel Convert => new PlaylistApiModel
        {
            PlaylistId = PlaylistId,
            Name = Name
        };
    }
}